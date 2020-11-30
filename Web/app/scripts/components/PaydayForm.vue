<template>
    <div>
        <h3>Payday</h3>
        <div class="payday-info">
            <p v-show="showForm">
                <select v-model.number="payday">
                    <option v-for="p in paydays" :value="p.id" :key="p.id">{{p.name}}</option>
                </select>
                <a href="#" @click.prevent="close">Cancel</a>
            </p>
            <p v-show="!showForm">
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
    import { Component, Mixins } from 'vue-property-decorator';
    import { StoreMixin} from '@/StoreMixin';

    @Component
    export default class PaydayForm extends Mixins(
        StoreMixin
    ) {
        showForm = false;
        frequencies = [
            { id: frequencies.monthly, name: 'Monthly' },
            { id: frequencies.weekly, name: 'Weekly' }
        ];

        get paydayName() {
            return this.format(this.frequencyId, this.payday);
        }

        get paydays() {
            return this.getPayDays(this.frequencyId);
        }

        get payday(){
            return this.$_payday;
        }

        set payday(value) {
            this.$_selectPayday(value);
            this.close();
        }

        get frequencyId(){
            return this.$_frequencyId;
        }

        open() {
            this.showForm = true;
        }

        close() {
            this.showForm = false;
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