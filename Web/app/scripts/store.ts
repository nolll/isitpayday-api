import { StoreOptions } from 'vuex';
import ajax from './ajax';
import urls from './urls';
import frequencies from './frequencies';
import storage from './storage';
import defaults from './defaults';

export default {
    strict: true,
    state: {
        _isPaydayReady: false,
        _isOptionsReady: false,
        _isPayday: false,
        _payday: defaults.payday,
        _timezone: defaults.timezone,
        _frequency: defaults.frequency,
        _country: defaults.country,
        _countries: [],
        _timezones: [],
        _localTime: null,
        _isPaydayError: false,
        _isOptionsError: false
    },
    getters: {
        isPayday(state) {
            return state._isPayday;
        },
        payday(state) {
            return state._payday;
        },
        timezone(state) {
            return state._timezone;
        },
        frequency(state) {
            return state._frequency;
        },
        country(state) {
            return state._country;
        },
        countries(state) {
            return state._countries;
        },
        timezones(state) {
            return state._timezones;
        },
        localTime(state) {
            return state._localTime;
        },
        isReady(state) {
            return state._isPaydayReady || state._isOptionsReady;
        },
        isError(state) {
            return state._isPaydayError || state._isOptionsError;
        }
    },
    actions: {
        loadSettings(context) {
            context.commit('setPayday', storage.getPayday());
            context.commit('setTimezone', storage.getTimezone());
            context.commit('setFrequency', storage.getFrequency());
            context.commit('setCountry', storage.getCountry());
        },
        async loadPayday(context) {
            const url = getPaydayUrl(context.state._payday, context.state._frequency, context.state._timezone, context.state._country);
            try{
                const response = await ajax.get(url);
                context.commit('setIsPayday', response.data.isPayDay);
                context.commit('setLocalTime', response.data.localTime);
                context.commit('setIsPaydayReady', true);
                context.commit('setIsPaydayError', false);
            }
            catch(error){
                context.commit('setIsPaydayReady', true);
                context.commit('setIsPaydayError', true);
            }
        },
        async loadOptions(context) {
            try{
                const response = await ajax.get(urls.getOptionsUrl())
                context.commit('setCountries', response.data.countries);
                context.commit('setTimezones', response.data.timezones);
                context.commit('setIsOptionsReady', true);
                context.commit('setIsOptionsError', false);
            } catch(error){
                context.commit('setIsOptionsReady', true);
                context.commit('setIsOptionsError', true);
            }
        },
        selectCountry(context, country) {
            context.commit('setCountry', country);
            storage.saveCountry(country);
            context.dispatch('loadPayday');
        },
        selectFrequency(context, frequency) {
            context.commit('setFrequency', frequency);
            storage.saveFrequency(frequency);
            const payday = frequency === frequencies.weekly ? 5 : 25;
            context.commit('setPayday', payday);
            storage.savePayday(payday);
            context.dispatch('loadPayday');
        },
        selectTimezone(context, timezone) {
            context.commit('setTimezone', timezone);
            storage.saveTimezone(timezone);
            context.dispatch('loadPayday');
        },
        selectPayday(context, payday) {
            context.commit('setPayday', payday);
            storage.savePayday(payday);
            context.dispatch('loadPayday');
        }
    },
    mutations: {
        setPayday(state, payday) {
            state._payday = payday;
        },
        setTimezone(state, timezone) {
            state._timezone = timezone;
        },
        setFrequency(state, frequency) {
            state._frequency = frequency;
        },
        setCountry(state, country) {
            state._country = country;
        },
        setIsPayday(state, isPayday) {
            state._isPayday = isPayday;
        },
        setLocalTime(state, localTime) {
            state._localTime = localTime;
        },
        setCountries(state, countries) {
            state._countries = countries;
        },
        setTimezones(state, timezones) {
            state._timezones = timezones;
        },
        setIsPaydayReady(state, isPaydayReady) {
            state._isPaydayReady = isPaydayReady;
        },
        setIsOptionsReady(state, isOptionsReady) {
            state._isOptionsReady = isOptionsReady;
        },
        setIsPaydayError(state, isPaydayError) {
            state._isPaydayError = isPaydayError;
        },
        setIsOptionsError(state, isOptionsError) {
            state._isOptionsError = isOptionsError;
        }
    }
} as StoreOptions<StoreState>;

function getPaydayUrl (payday: number, frequency: string, timezone: string, country: string) {
    if (frequency === frequencies.weekly)
        return urls.getWeeklyUrl(payday, timezone, country);
    return urls.getMonthlyUrl(payday, timezone, country);
}

export interface StoreState{
    _isPaydayReady: boolean,
    _isOptionsReady: boolean,
    _isPayday: boolean,
    _payday: number,
    _timezone: string,
    _frequency: string,
    _country: string,
    _countries: string[],
    _timezones: string[],
    _localTime: Date | null,
    _isPaydayError: boolean,
    _isOptionsError: boolean
}