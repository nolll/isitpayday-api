import vue from 'vue';
import store from './store';
import moment from 'moment';
import { mapGetters } from 'vuex';
import Settings from './components/settings/settings';

function init() {
    const appElement = document.getElementById('app');
    const options = {
        el: appElement,
        store: store,
        mounted: function () {
            this.$store.dispatch('loadSettings');
            this.$store.dispatch('loadPayday');
            this.$store.dispatch('loadOptions');
        },
        computed: {
            ...mapGetters([
                'isReady',
                'isPayday',
                'localTime'
            ]),
            message: function () {
                return this.isPayday ? 'YES!!1!' : 'No =(';
            },
            formattedLocalTime: function () {
                if (this.localTime)
                    return moment(this.localTime).format('MMMM Do YYYY, HH:mm:ss');
                return '';
            }
        },
        components: {
            Settings
        }
    };
    new vue(options);
}

export default {
    init
};
