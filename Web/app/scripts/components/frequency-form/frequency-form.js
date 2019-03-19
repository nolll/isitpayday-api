import html from './frequency-form.html';
import frequencies from '../../frequencies';

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
        frequency: {
            get() {
                return this.$store.getters.frequency;
            },
            set(value) {
                this.$store.commit('selectFrequency', value);
                this.close();
            }
        },
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
        open: function () {
            this.showForm = true;
        },
        close: function () {
            this.showForm = false;
        }
    }
};
