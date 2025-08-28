<template>
    <div>
        <input
        class="inputSquare"
        ref="inputSquare"
        type="text"
        min="1"
        max="9"
        @input="emitter"
        />
    </div>
</template>

<script>

export default {
    name: 'Square',
    data() {
        return {
            char: '',
        }
    },
    props: ['solvedSquare'],
    watch: {
        'solvedSquare': function(newVal, oldVal) {
            console.log('Prop changed: ', newVal, ' | was: ', oldVal);
            if (newVal == '') {
                this.$refs.inputSquare.style.color = 'black';
            }
            this.$refs.inputSquare.value = newVal;
            this.$refs.inputSquare.style.color = 'blue';
        }
    },
    methods: {
        emitter(e) {
            this.$emit('charEntered', Number(e.target.value));
        }
    }
}

</script>

<style>

/* Chrome, Safari, Edge, Opera */
input::-webkit-outer-spin-button,
input::-webkit-inner-spin-button {
  -webkit-appearance: none;
  margin: 0;
}

/* Firefox */
input[type=number] {
  -moz-appearance: textfield;
}

.inputSquare {
    border: 1px dashed black;
    text-align: center;
    height: 5vw;
    width: 5vw;
    padding: 0;
}

</style>
