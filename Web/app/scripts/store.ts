import { StoreOptions } from 'vuex';
import ajax from './ajax';
import urls from './urls';
import frequencies from './frequencies';
import { PaydayRequest } from './types/PaydayRequest';

export default {
    strict: true,
    state: {
        _isPaydayReady: false,
        _isPayday: false,
        _localTime: null
    },
    getters: {
        isPayday(state) {
            return state._isPayday;
        },
        localTime(state) {
            return state._localTime;
        },
        isReady(state) {
            return state._isPaydayReady;
        }
    },
    actions: {
        async loadPayday(context, data: PaydayRequest) {
            const url = getPaydayUrl(data.payday, data.frequency, data.timezone, data.country);
            try{
                const response = await ajax.get(url);
                context.commit('setIsPayday', response.data.isPayDay);
                context.commit('setLocalTime', response.data.localTime);
                context.commit('setIsPaydayReady', true);
            }
            catch(error){
            }
        }
    },
    mutations: {
        setIsPayday(state, isPayday) {
            state._isPayday = isPayday;
        },
        setLocalTime(state, localTime) {
            state._localTime = localTime;
        },
        setIsPaydayReady(state, isPaydayReady) {
            state._isPaydayReady = isPaydayReady;
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
    _localTime: Date | null,
}