<template>
    <div>
        <h3>Payday</h3>
        <div class="payday-info">
            <p v-show="showForm">
                <select v-model.number="payday">
                    <option v-for="p in paydays" :value="p.id">{{p.name}}</option>
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

<script>
    import frequencies from '../frequencies';
    import weekdays from '../weekdays';
    import nthFormatter from '../nth-formatter';
    import { mapGetters } from 'vuex';

    export default {
        data: function () {
            return {
                showForm: false
            };
        },
        computed: {
            ...mapGetters([
                'frequency'
            ]),
            payday: {
                get() {
                    return this.$store.getters.payday;
                },
                set(value) {
                    this.$store.dispatch('selectPayday', value);
                    this.close();
                }
            },
            paydayName() {
                return format(this.frequency, this.payday);
            },
            paydays() {
                return getPayDays(this.frequency);
            }
        },
        methods: {
            open() {
                this.showForm = true;
            },
            close() {
                this.showForm = false;
            }
        },
        mounted() {
            var x = 0;
        }
    };

    function getPayDays(frequency) {
        if (frequency === frequencies.weekly)
            return getWeeklyPaydays(frequency);
        return getMonthlyPaydays(frequency);
    }

    function getWeeklyPaydays(frequency) {
        return getPaydaysArray(frequency, 7);
    }

    function getMonthlyPaydays(frequency) {
        return getPaydaysArray(frequency, 31);
    }

    function getPaydaysArray(frequency, upperBound) {
        var paydays = [],
            i;

        for (i = 1; i <= upperBound; i++) {
            paydays.push({ id: i, name: format(frequency, i) });
        }
        return paydays;
    }

    function format(frequency, payday) {
        if (frequency === frequencies.weekly)
            return weekdays.getName(payday);
        return nthFormatter.format(payday);
    }
</script>