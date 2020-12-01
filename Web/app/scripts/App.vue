<template>
    <div v-if="isReady">
        <p class="status"><span>{{message}}</span></p>
        <div class="settings">
            <h2>Settings</h2>
            <CountryForm v-model="country" :countries="countries" />
            <FrequencyForm />
            <TimezoneForm :timezones="timezones" />
            <PaydayForm />
        </div>
        <p class="footer">{{formattedLocalTime}}</p>
    </div>
</template>

<script lang="ts">
    import { Component, Mixins, Watch } from 'vue-property-decorator';
    import { StoreMixin} from './StoreMixin';
    import moment from 'moment';
    import { mapGetters } from 'vuex';
    import CountryForm from './components/CountryForm.vue';
    import TimezoneForm from './components/TimezoneForm.vue';
    import FrequencyForm from './components/FrequencyForm.vue';
    import PaydayForm from './components/PaydayForm.vue';
    import { Country } from '@/types/Country';
    import { Timezone } from '@/types/Timezone';
    import ajax from './ajax';
    import urls from './urls';
    import defaults from './defaults';
    import storage from './storage';

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
        private payday = defaults.payday;
        private timezone = defaults.timezone;
        private frequency = defaults.frequency;
        private country = defaults.country;
        private countries: Country[] = [];
        private timezones: Timezone[] = [];

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

        private loadSettings(){
            this.payday = storage.getPayday();
            this.timezone = storage.getTimezone();
            this.frequency = storage.getFrequency();
            this.country = storage.getCountry();
        }

        private async loadOptions(){
            try{
                const response = await ajax.get(urls.getOptionsUrl());
                this.countries = response.data.countries;
                this.timezones = response.data.timezones;
            } catch(error) {
                
            }
        }

        @Watch('country')
        countryChanged(){
            storage.saveCountry(this.country);
            this.loadPayday();
        }

        loadPayday(){
            this.$_loadPayday();
        }

        mounted() {
            this.loadSettings();
            this.loadPayday();
            this.loadOptions();
        }
    }
</script>