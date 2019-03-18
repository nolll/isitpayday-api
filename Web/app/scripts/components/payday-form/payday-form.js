import html from './payday-form.html';
import frequencies from '../../frequencies';
import weekdays from '../../weekdays';
import nthFormatter from '../../nth-formatter';
import { mapGetters } from 'vuex';

export default {
    template: html,
    data: function() {
        return {
            showForm: false,
            paydays: getPayDays()
        };
    },
    computed: {
        ...mapGetters([
            'payday',
            'frequency'
        ]),
        paydayName: function () {
            return format(this.payday);
        }
    },
    methods: {
        select: function (event) {
            event.preventDefault();
            this.$store.dispatch('selectPayday', this.payday);
            this.close();
        },
        open: function () {
            this.showForm = true;
        },
        close: function () { 
            this.showForm = false;
        }
    }
};

function getPayDays() {
    var paydays = [],
        i;

    for (i = 1; i <= 31; i++) {
        paydays.push({ id: i, name: format(i) });
    }
    return paydays;
}

function format(n) {
    if (this.frequency === frequencies.weekly)
        return weekdays.getName(n);
    return nthFormatter.format(n);
}