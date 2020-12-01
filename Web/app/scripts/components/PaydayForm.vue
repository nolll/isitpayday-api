<template>
    <div>
        <h3>Payday</h3>
        <div class="payday-info">
            <p v-show="isFormVisible">
                <select :value="value" v-on:input="updateValue">
                    <option v-for="p in paydays" :value="p.id" :key="p.id">{{p.name}}</option>
                </select>
                <a href="#" @click.prevent="close">Cancel</a>
            </p>
            <p v-show="!isFormVisible">
                {{paydayName}}
                <a href="#" @click.prevent="open">Change</a>
            </p>
        </div>
    </div>
</template>

<script lang="ts">
    import frequencies from '@/frequencies';
    import nthFormatter from '@/nth-formatter';
    import weekdays from '@/weekdays';
    import { Payday } from '@/types/Payday';
    import { Component, Mixins, Prop } from 'vue-property-decorator';
    import { StoreMixin} from '@/StoreMixin';

    @Component
    export default class PaydayForm extends Mixins(
        StoreMixin
    ) {
        @Prop() value!: number;
        @Prop() readonly frequencyId!: string;
        isFormVisible = false;

        get paydayName() {
            return this.format(this.frequencyId, this.value);
        }

        get paydays() {
            return this.getPayDays(this.frequencyId);
        }

        updateValue(event: any){
            this.close();
            this.$emit('input', event.target.value);
        }

        open() {
            this.isFormVisible = true;
        }

        close() {
            this.isFormVisible = false;
        }

        private getPayDays(frequencyId: string) {
            if (frequencyId === frequencies.weekly)
                return this.getWeeklyPaydays(frequencyId);
            return this.getMonthlyPaydays(frequencyId);
        }

        private getWeeklyPaydays(frequencyId: string) {
            return this.getPaydaysArray(frequencyId, 7);
        }

        private getMonthlyPaydays(frequencyId: string) {
            return this.getPaydaysArray(frequencyId, 31);
        }

        private getPaydaysArray(frequencyId: string, upperBound: number): Payday[] {
            const paydays: Payday[] = [];

            for (let i = 1; i <= upperBound; i++) {
                paydays.push({ id: i, name: this.format(frequencyId, i) });
            }
            return paydays;
        }

        private format(frequencyId: string, payday: number) {
            if (frequencyId === frequencies.weekly)
                return weekdays.getName(payday);
            return nthFormatter.format(payday);
        }
    }
</script>