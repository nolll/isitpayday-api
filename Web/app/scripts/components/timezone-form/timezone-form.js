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
        ...mapGetters(['timezone', 'timezones'])
    },
    methods: {
        select: function (event) {
            event.preventDefault();
            this.$store.dispatch('selectTimezone', this.timezone);
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