<template>
    <div v-if="isReady">
        <p class="status"><span v-text="message"></span></p>
        <settings />
        <p class="footer" v-text="formattedLocalTime"></p>
    </div>
</template>

<script>
    import moment from 'moment';
    import { mapGetters } from 'vuex';
    import Settings from './components/Settings';

    export default {
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
    }
</script>