import html from './country-form.html';
import { mapGetters } from 'vuex';

export default {
    template: html,
    computed: {
        ...mapGetters([
            'country',
            'countries'
        ]),
        countryName: function() {
            var i;
            for (i = 0; i < this.countries.length; i++) {
                var c = this.countries[i];
                if (c.id === this.country) {
                    return c.name;
                }
            }
            return "";
        }
    },
    methods: {
        select: function (event) {
            event.preventDefault();
            this.$store.dispatch('selectCountry', this.country);
            this.close();
        },
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
