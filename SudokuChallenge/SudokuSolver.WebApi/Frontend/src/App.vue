<template>
  <v-app>
    <v-main>
      <div class="maindiv">
        <div class="puzzle">
          <h1>Puzzle</h1>
          <Puzzle @gridUpdated="setGridArray" :solvedGridArray="solvedGridArray"></Puzzle>
        </div>
        <div class="sidebar">
          <h1>Vue Sudoku Solver</h1>
          <p>This online sudoku solver uses an recursive backtracking algorithm to solve standard 9x9 sudoku puzzles</p>
          <p>To solve your sudoku puzzle, enter in all the given numbers in the grid on the left and then press the
            'Solve' button below
            to get a complete solution to your puzzle!</p>
          <v-btn id="solvebtn" class="ma-2 mb-8" :loading="loader" :disabled="loader" color="info"
            @click="solveAlgoActivated">
            Solve puzzle
            <template v-slot:loader>
              <span>Loading...</span>
            </template>
          </v-btn>
          <v-btn v-if="solved" id="clearbtn" class="ma-2 mb-8" :loading="loader1" :disabled="loader1" color="info"
            @click="clearPuzzle">
            Clear puzzle
            <template v-slot:loader>
              <span>Loading...</span>
            </template>
          </v-btn>
          <v-snackbar v-model="snackbar" :multi-line="multiLine">
            There is no solution to this sudoku :(
            <template v-slot:action="{ attrs }">
              <v-btn color="red" text v-bind="attrs" @click="snackbar = false">
                Close
              </v-btn>
            </template>
          </v-snackbar>
          <h1>Solved Puzzle Table</h1>
          <DxDataGrid :data-source="solvers" key-expr="Id" :column-auto-width="true" v-show="showPuzzleTable">
            <DxColumn data-field="Result"></DxColumn>
            <DxColumn data-field="CreatedDate" data-type="date"></DxColumn>
          </DxDataGrid>
        </div>
      </div>
    </v-main>
  </v-app>
</template>

<script>
import Puzzle from './components/Puzzle.vue';
import { solvePuzzle, preSolveLegalCheck } from './Solver';
import axios from 'axios';
import { DxDataGrid, DxColumn } from 'devextreme-vue/data-grid';

const Base_URL = 'http://localhost:5090/api/'

export default {
  name: 'App',
  components: {
    Puzzle,
    DxDataGrid,
    DxColumn
  },
  data: () => ({
    gridArray: [[0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0]],
    loader: false,
    solved: false,
    loader1: false,
    snackbar: false,
    multiLine: true,
    solvedGridArray: [[0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0]],
    solvers: [],
    showPuzzleTable: false
  }),
  async created() {
    await this.getSolvers();
  },
  methods: {
    setGridArray(grid) {
      this.gridArray = grid;
    },
    async solveAlgoActivated() {
      this.loader = true;
      if (preSolveLegalCheck(this.gridArray) == false) {
        this.noSoln();
      } else {
        let soln = solvePuzzle(this.gridArray);
        if (soln.solvable) {
          this.solvedGridArray = soln.arr;
          this.solved = true;
          await this.addSolver();
        } else {
          this.noSoln();
        }
      }
      this.loader = false;
    },
    noSoln() {
      this.snackbar = true;
    },
    clearPuzzle() {
      window.location.reload();
    },
    async getSolvers() {
      await axios
        .get(Base_URL + 'Solver')
        .then((response) => {
          if (response.data != null && response.data.length > 0) {
            this.solvers = response.data;
            this.showPuzzleTable = true;
          }
        })
    },
    async addSolver() {
      await axios
        .post(Base_URL + 'Solver/Add', this.solvedGridArray)
        .then((response) => {
          console.log(response.data);
          alert("Add this sodoku successfully!");
          this.getSolvers();
        })
    }
  }
};
</script>

<style scoped>
.maindiv {
  display: flex;
}

.puzzle {
  margin: 10px 0 0 10px;
}

.sidebar {
  margin-top: 10px;
  margin-left: 40px;
}

#solvebtn {
  width: 50%;
  margin: 0 auto;
}
</style>
