import html from './timezone-form.html';
import { mapGetters } from 'vuex';

export default {
    template: html,
    data: function() {
        return {
            showForm: false
        };
    },
    computed: {
        ...mapGetters(['timezones']),
        timezone: {
            get() {
                return this.$store.getters.timezone;
            },
            set(value) {
                this.$store.commit('selectTimezone', value);
                this.close();
            }
        },
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