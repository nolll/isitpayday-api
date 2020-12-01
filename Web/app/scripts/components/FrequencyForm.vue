<template>
    <div>
        <h3>Frequency</h3>
        <div class="frequency-info">
            <p v-show="isFormVisible">
                <select :value="value" v-on:input="updateValue">
                    <option v-for="f in frequencies" :value="f.id" :key="f.id">{{f.name}}</option>
                </select>
                <a href="#" @click.prevent="close">Cancel</a>
            </p>
            <p v-show="!isFormVisible">
                {{frequencyName}}
                <a href="#" @click.prevent="open">Change</a>
            </p>
        </div>
    </div>
</template>

<script lang="ts">
    import { Component, Mixins, Prop } from 'vue-property-decorator';
    import { StoreMixin} from '../StoreMixin';
    import frequencies from '../frequencies';
    import { Frequency } from '@/types/Frequency';

    @Component
    export default class FrequencyForm extends Mixins(
        StoreMixin
    ) {
        @Prop() value!: string;
        @Prop() readonly frequencies!: Frequency[];
        isFormVisible = false;

        updateValue(event: any){
            this.close();
            this.$emit('input', event.target.value);
        }

        get frequencyName() {
            for (let i = 0; i < this.frequencies.length; i++) {
                var f = this.frequencies[i];
                if (f.id === this.value) {
                    return f.name;
                }
            }
            return "";
        }

        open() {
            this.isFormVisible = true;
        }

        close() {
            this.isFormVisible = false;
        }
    }
</script>