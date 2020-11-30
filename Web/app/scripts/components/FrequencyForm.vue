<template>
    <div>
        <h3>Frequency</h3>
        <div class="frequency-info">
            <p v-show="showForm">
                <select v-model="frequencyId">
                    <option v-for="f in frequencies" :value="f.id" :key="f.id">{{f.name}}</option>
                </select>
                <a href="#" @click.prevent="close">Cancel</a>
            </p>
            <p v-show="!showForm">
                {{frequencyName}}
                <a href="#" @click.prevent="open">Change</a>
            </p>
        </div>
    </div>
</template>

<script lang="ts">
    import { Component, Mixins } from 'vue-property-decorator';
    import { StoreMixin} from '../StoreMixin';
    import frequencies from '../frequencies';

    @Component
    export default class FrequencyForm extends Mixins(
        StoreMixin
    ) {
        showForm = false;
        frequencies = [
            { id: frequencies.monthly, name: 'Monthly' },
            { id: frequencies.weekly, name: 'Weekly' }
        ];

        get frequencyId() {
            return this.$_frequencyId;
        }

        set frequencyId(id: string) {
            this.$_selectFrequency(id);
            this.close();
        }

        get frequencyName() {
            var i;
            for (i = 0; i < this.frequencies.length; i++) {
                var f = this.frequencies[i];
                if (f.id === this.frequencyId) {
                    return f.name;
                }
            }
            return "";
        }

        open() {
            this.showForm = true;
        }

        close() {
            this.showForm = false;
        }
    }
</script>