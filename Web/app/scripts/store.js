import vue from 'vue';
import vuex from 'vuex';
import ajax from './ajax';
import urls from './urls';
import frequencies from './frequencies';
import storage from './storage';

vue.use(vuex);

export default new vuex.Store({
    strict: true,
    state: {
        _isPaydayReady: false,
        _isOptionsReady: false,
        _isPayday: false,
        _payday: null,
        _timezone: null,
        _frequency: null,
        _country: null,
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
        loadPayday(context) {
            const url = getPaydayUrl(context.state._payday, context.state._frequency, context.state._timezone, context.state._country);
            ajax.load(
                url,
                function (data) {
                    context.commit('setIsPayday', data.isPayday);
                    context.commit('setLocalTime', data.localTime);
                    context.commit('setIsPaydayReady', true);
                    context.commit('setIsPaydayError', false);
                },
                function() {
                    context.commit('setIsPaydayReady', true);
                    context.commit('setIsPaydayError', true);
                });
        },
        loadOptions(context) {
            ajax.load(
                urls.getOptionsUrl(),
                function (data) {
                    context.commit('setCountries', data.countries);
                    context.commit('setTimezones', data.timezones);
                    context.commit('setIsOptionsReady', true);
                    context.commit('setIsOptionsError', false);
                },
                function () {
                    context.commit('setIsOptionsReady', true);
                    context.commit('setIsOptionsError', true);
                });
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
});

function getPaydayUrl (payday, frequency, timezone, country) {
    if (frequency === frequencies.weekly)
        return urls.getWeeklyUrl(payday, timezone, country);
    return urls.getMonthlyUrl(payday, timezone, country);
}
