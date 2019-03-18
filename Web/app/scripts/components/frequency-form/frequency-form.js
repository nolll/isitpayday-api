import html from './frequency-form.html';
import frequencies from '../../frequencies';
import { mapGetters } from 'vuex';

export default {
    template: html,
    data: function() {
        return {
            showForm: false,
            frequencies: [
                { id: frequencies.monthly, name: 'Monthly' },
                { id: frequencies.weekly, name: 'Weekly' }
            ]
        };
    },
    computed: {
        ...mapGetters(['frequency']),
        frequencyName: function() {
            var i;
            for (i = 0; i < this.frequencies.length; i++) {
                var f = this.frequencies[i];
                if (f.id === this.frequency) {
                    return f.name;
                }
            }
            return "";
        }
    },
    methods: {
        select: function (event) {
            event.preventDefault();
            this.$store.dispatch('selectFrequency', this.frequency);
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
