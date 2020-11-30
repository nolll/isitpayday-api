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
        _isPayday: false,
        _payday: defaults.payday,
        _timezone: defaults.timezone,
        _frequency: defaults.frequency,
        _country: defaults.country,
        _localTime: null,
        _isPaydayError: false
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
        localTime(state) {
            return state._localTime;
        },
        isReady(state) {
            return state._isPaydayReady;
        },
        isError(state) {
            return state._isPaydayError;
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
        setIsPaydayReady(state, isPaydayReady) {
            state._isPaydayReady = isPaydayReady;
        },
        setIsPaydayError(state, isPaydayError) {
            state._isPaydayError = isPaydayError;
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
    _isPayday: boolean,
    _payday: number,
    _timezone: string,
    _frequency: string,
    _country: string,
    _localTime: Date | null,
    _isPaydayError: boolean
}