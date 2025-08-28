<template>
  <div>
    <FirstRow @rowUpdated="setGridArray(0, $event)" :solvedRow="solvedGridArray[0]"></FirstRow>
    <Row @rowUpdated="setGridArray(1, $event)" :solvedRow="solvedGridArray[1]"></Row>
    <Row @rowUpdated="setGridArray(2, $event)" :solvedRow="solvedGridArray[2]"></Row>
    <FirstRow @rowUpdated="setGridArray(3, $event)" :solvedRow="solvedGridArray[3]"></FirstRow>
    <Row @rowUpdated="setGridArray(4, $event)" :solvedRow="solvedGridArray[4]"></Row>
    <Row @rowUpdated="setGridArray(5, $event)" :solvedRow="solvedGridArray[5]"></Row>
    <FirstRow @rowUpdated="setGridArray(6, $event)" :solvedRow="solvedGridArray[6]"></FirstRow>
    <Row @rowUpdated="setGridArray(7, $event)" :solvedRow="solvedGridArray[7]"></Row>
    <BottomRow @rowUpdated="setGridArray(8, $event)" :solvedRow="solvedGridArray[8]"></BottomRow>
  </div> 
</template>

<script>
import Row from './Row.vue';
import FirstRow from './FirstRow.vue';
import BottomRow from './BottomRow.vue'

export default {
    name: 'Puzzle',
    components: {
        Row,
        FirstRow,
        BottomRow,
    }, 
    props: ['solvedGridArray'],
    data() {
        return {
            gridArray: [[0, 0, 0, 0, 0, 0, 0, 0, 0], 
                        [0, 0, 0, 0, 0, 0, 0, 0, 0], 
                        [0, 0, 0, 0, 0, 0, 0, 0, 0], 
                        [0, 0, 0, 0, 0, 0, 0, 0, 0], 
                        [0, 0, 0, 0, 0, 0, 0, 0, 0], 
                        [0, 0, 0, 0, 0, 0, 0, 0, 0],
                        [0, 0, 0, 0, 0, 0, 0, 0, 0], 
                        [0, 0, 0, 0, 0, 0, 0, 0, 0], 
                        [0, 0, 0, 0, 0, 0, 0, 0, 0]],
        }
    }, 
    methods: {
      setGridArray(index, row) {
        this.gridArray[index] = row.slice();
        this.$emit('gridUpdated', this.gridArray);
      }
    }
}

</script>

<style scoped>

</style>


