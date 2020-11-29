<template>
    <div v-if="isReady">
        <p class="status"><span>{{message}}</span></p>
        <div class="settings">
            <h2>Settings</h2>
            <CountryForm />
            <FrequencyForm />
            <TimezoneForm />
            <PaydayForm />
        </div>
        <p class="footer">{{formattedLocalTime}}</p>
    </div>
</template>

<script lang="ts">
    import { Component, Mixins } from 'vue-property-decorator';
    import { StoreMixin} from './StoreMixin';
    import moment from 'moment';
    import { mapGetters } from 'vuex';
    import CountryForm from './components/CountryForm.vue';
    import TimezoneForm from './components/TimezoneForm.vue';
    import FrequencyForm from './components/FrequencyForm.vue';
    import PaydayForm from './components/PaydayForm.vue';

    @Component({
        components: {
            CountryForm,
            TimezoneForm,
            FrequencyForm,
            PaydayForm
        }
    })
    export default class App extends Mixins(
        StoreMixin
    ) {
        
        get isReady(){
            return this.$_isReady;
        }

        get isPayday(){
            return this.$_isPayday;
        }

        get localTime(){
            return this.$_localTime;
        }

        get message() {
            return this.isPayday ? 'YES!!1!' : 'No =(';
        }

        get formattedLocalTime() {
            if (this.localTime)
                return moment(this.localTime).format('MMMM Do YYYY, HH:mm:ss');
            return '';
        }

        mounted() {
            this.$_loadSettings();
            this.$_loadPayday();
            this.$_loadOptions();
        }
    }
</script>