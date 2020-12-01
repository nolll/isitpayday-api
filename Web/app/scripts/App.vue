<template>
    <div v-if="isReady">
        <p class="status"><span>{{message}}</span></p>
        <div class="settings">
            <h2>Settings</h2>
            <CountryForm v-model="country" :countries="countries" />
            <FrequencyForm v-model="frequency" :frequencies="frequencies" />
            <TimezoneForm v-model="timezone" :timezones="timezones" />
            <PaydayForm v-model="payday" :frequencyId="frequency" />
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
    import { Frequency } from '@/types/Frequency';
    import { Timezone } from '@/types/Timezone';
    import ajax from './ajax';
    import urls from './urls';
    import defaults from './defaults';
    import storage from './storage';
    import frequencies from './frequencies';

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
        private isLocalReady = false;
        private payday = defaults.payday;
        private timezone = defaults.timezone;
        private frequency = defaults.frequency;
        private country = defaults.country;
        private countries: Country[] = [];
        private timezones: Timezone[] = [];
        private frequencies: Frequency[] = [];

        get isReady(){
            return this.$_isReady && this.isLocalReady;
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
            this.country = storage.getCountry();
            this.frequency = storage.getFrequency();
            this.timezone = storage.getTimezone();
            this.payday = storage.getPayday();
        }

        private async loadOptions(){
            try{
                const response = await ajax.get(urls.getOptionsUrl());
                this.countries = response.data.countries;
                this.timezones = response.data.timezones;
                this.frequencies = [
                    { id: frequencies.monthly, name: 'Monthly' },
                    { id: frequencies.weekly, name: 'Weekly' }
                ];
                this.isLocalReady = true;
            } catch(error) {
                
            }
        }

        @Watch('country')
        countryChanged(){
            storage.saveCountry(this.country);
            this.loadPayday();
        }

        @Watch('frequency')
        frequencyChanged(){
            storage.saveFrequency(this.frequency);
            this.payday = this.frequency === frequencies.weekly ? 5 : 25;
            this.loadPayday();
        }

        @Watch('timezone')
        timezoneChanged(){
            storage.saveTimezone(this.timezone);
            this.loadPayday();
        }

        @Watch('payday')
        paydayChanged(){
            storage.savePayday(this.payday);
            this.loadPayday();
        }

        loadPayday(){
            this.$_loadPayday({country: this.country, frequency: this.frequency, timezone: this.timezone, payday: this.payday});
        }

        mounted() {
            this.loadSettings();
            this.loadPayday();
            this.loadOptions();
        }
    }
</script>