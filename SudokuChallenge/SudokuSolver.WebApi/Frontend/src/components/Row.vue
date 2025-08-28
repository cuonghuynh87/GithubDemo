<template>
    <div class="row">
        <Square class="firstCol" @charEntered="setRowArray(0, $event)" :solvedSquare="solvedRow[0]"></Square>
        <Square @charEntered="setRowArray(1, $event)" :solvedSquare="solvedRow[1]"></Square>
        <Square class="thirdCol" @charEntered="setRowArray(2, $event)" :solvedSquare="solvedRow[2]"></Square>
        <Square @charEntered="setRowArray(3, $event)" :solvedSquare="solvedRow[3]"></Square>
        <Square @charEntered="setRowArray(4, $event)" :solvedSquare="solvedRow[4]"></Square>
        <Square class="thirdCol" @charEntered="setRowArray(5, $event)" :solvedSquare="solvedRow[5]"></Square>
        <Square @charEntered="setRowArray(6, $event)" :solvedSquare="solvedRow[6]"></Square>
        <Square @charEntered="setRowArray(7, $event)" :solvedSquare="solvedRow[7]"></Square>
        <Square class="thirdCol" @charEntered="setRowArray(8, $event)" :solvedSquare="solvedRow[8]"></Square>
    </div>
</template>

<script>
import Square from './Square.vue'

export default {
    name: 'Row',
    components: {
        Square,
    },
    props: ['solvedRow'],
    data() {
        return {
            rowArray: [0, 0, 0, 0, 0, 0, 0, 0, 0],
        }
    }, 
    methods: {
        setRowArray(index, char) {
            this.rowArray[index] = parseInt(char);
            this.$emit('rowUpdated', this.rowArray);
        }
    }

}

</script>

<style scoped>

.row {
    display: flex;
}

.firstCol {
    border-left: 3px solid black;
}

.thirdCol {
    border-right: 3px solid black;
}

</style>
