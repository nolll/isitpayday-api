<template>
    <div v-if="isReady">
        <p class="message"><span>{{message}}</span></p>
        <p class="error" v-if="hasError"><span>{{error}}</span></p>
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
    import dayjs from 'dayjs';
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
    import advancedFormat from 'dayjs/plugin/advancedFormat';
    dayjs.extend(advancedFormat);

    @Component({
        components: {
            CountryForm,
            TimezoneForm,
            FrequencyForm,
            PaydayForm
        }
    })
    export default class App extends Vue {
        private error = '';
        private isOptionsReady = false;
        private isPaydayReady = false;
        private isPayday = false;
        private localTime = '';
        private payday = defaults.payday;
        private timezone = defaults.timezone;
        private frequency = defaults.frequency;
        private country = defaults.country;
        private countries: Country[] = [];
        private timezones: Timezone[] = [];
        private frequencies: Frequency[] = [];

        private get isReady(){
            return this.isPaydayReady && this.isOptionsReady;
        }

        private get message() {
            if(this.error)
                return 'Error';

            return this.isPayday ? 'YES!!1!___' : 'No =(';
        }

        private get formattedLocalTime() {
            if (this.localTime)
                return dayjs(this.localTime).format('MMMM Do YYYY, HH:mm:ss');
            return '';
        }

        private get hasError(){
            return !!this.error;
        }

        private loadSettings(){
            this.country = storage.getCountry();
            this.frequency = storage.getFrequency();
            this.timezone = storage.getTimezone();
            this.payday = storage.getPayday();
        }

        @Watch('country')
        private countryChanged(){
            storage.saveCountry(this.country);
            this.loadPayday();
        }

        @Watch('frequency')
        private frequencyChanged(){
            storage.saveFrequency(this.frequency);
            this.payday = this.frequency === frequencies.weekly ? defaults.weeklyPayday : defaults.monthlyPayday;
            this.loadPayday();
        }

        @Watch('timezone')
        private timezoneChanged(){
            storage.saveTimezone(this.timezone);
            this.loadPayday();
        }

        @Watch('payday')
        private paydayChanged(){
            storage.savePayday(this.payday);
            this.loadPayday();
        }

        private async loadPayday(){
            try{
                const response = await ajax.get(this.paydayUrl);
                this.isPayday = response.data.isPayDay;
                this.localTime = response.data.localTime;
                this.isPaydayReady = true;
            }
            catch(error){
                this.error = 'Error loading payday';
            }
        }

        private async loadOptions(){
            try{
                const response = await ajax.get(urls.optionsUrl);
                this.countries = response.data.countries;
                this.timezones = response.data.timezones;
                this.frequencies = [
                    { id: frequencies.monthly, name: 'Monthly' },
                    { id: frequencies.weekly, name: 'Weekly' }
                ];
                this.isOptionsReady = true;
            } catch(error) {
                this.error = 'Error loading options';
            }
        }

        private get paydayUrl() {
            return (this.frequency === frequencies.weekly)
                ? urls.weeklyUrl(this.payday, this.timezone, this.country)
                : urls.monthlyUrl(this.payday, this.timezone, this.country);
        }

        private mounted() {
            this.loadSettings();
            this.loadPayday();
            this.loadOptions();
        }
    }
</script>