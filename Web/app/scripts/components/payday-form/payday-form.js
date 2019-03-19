import html from './payday-form.html';
import frequencies from '../../frequencies';
import weekdays from '../../weekdays';
import nthFormatter from '../../nth-formatter';
import { mapGetters } from 'vuex';

export default {
    template: html,
    data: function() {
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
                this.$store.commit('selectPayday', value);
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
    }
};

function getPayDays(frequency) {
    var paydays = [],
        i;

    for (i = 1; i <= 31; i++) {
        paydays.push({ id: i, name: format(frequency, i) });
    }
    return paydays;
}

function format(frequency, payday) {
    if (frequency === frequencies.weekly)
        return weekdays.getName(payday);
    return nthFormatter.format(payday);
}