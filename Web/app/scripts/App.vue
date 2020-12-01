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
    import { Component, Vue, Watch } from 'vue-property-decorator';
    import moment from 'moment';
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
    export default class App extends Vue {
        private isOptionsReady = false;
        private isPaydayReady = false;
        private isPayday = false;
        private localTime = new Date();
        private payday = defaults.payday;
        private timezone = defaults.timezone;
        private frequency = defaults.frequency;
        private country = defaults.country;
        private countries: Country[] = [];
        private timezones: Timezone[] = [];
        private frequencies: Frequency[] = [];

        get isReady(){
            return this.isPaydayReady && this.isOptionsReady;
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
                this.isOptionsReady = true;
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

        async loadPayday(){
            try{
                const response = await ajax.get(this.paydayUrl);
                this.isPayday = response.data.isPayDay;
                this.localTime = response.data.localTime;
                this.isPaydayReady = true;
            }
            catch(error){
            }
        }

        private get paydayUrl() {
            if (this.frequency === frequencies.weekly)
                return urls.getWeeklyUrl(this.payday, this.timezone, this.country);
            return urls.getMonthlyUrl(this.payday, this.timezone, this.country);
        }

        mounted() {
            this.loadSettings();
            this.loadPayday();
            this.loadOptions();
        }
    }
</script>