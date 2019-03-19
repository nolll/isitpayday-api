import html from './country-form.html';
import { mapGetters } from 'vuex';

export default {
    template: html,
    computed: {
        ...mapGetters([
            'countries'
        ]),
        country: {
            get() {
                return this.$store.getters.country;
            },
            set(value) {
                this.$store.dispatch('selectCountry', value);
                this.close();
            }
        },
        countryName: function() {
            var i;
            for (i = 0; i < this.countries.length; i++) {
                const c = this.countries[i];
                if (c.id === this.country) {
                    return c.name;
                }
            }
            return '';
        }
    },
    methods: {
        open: function () {
            this.showForm = true;
        },
        close: function () {
            this.showForm = false;
        }
    },
    data: function() {
        return {
            showForm: false
        };
    }
};
