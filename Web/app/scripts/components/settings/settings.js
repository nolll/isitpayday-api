import html from './settings.html';
import CountryForm from '../country-form/country-form';
import TimezoneForm from '../timezone-form/timezone-form';
import FrequencyForm from '../frequency-form/frequency-form';
import PaydayForm from '../payday-form/payday-form';

export default {
    template: html,
    components: {
        CountryForm,
        TimezoneForm,
        FrequencyForm,
        PaydayForm
    },
    computed: {
        test() {
            return this.$store.state._isPaydayReady;
        }
    }
};