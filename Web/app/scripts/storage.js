import cookie from 'js-cookie';
import frequencies from './frequencies';

var defaultPayday = 25;
var defaultTimezone = 'W. Europe Standard Time';
var defaultFrequency = frequencies.monthly;
var defaultCountry = 'SE';

function getPayday() {
    const payday = cookie.get('payday');
    return payday ? Number(payday) : defaultPayday;
}

function savePayday(payday) {
    setCookie('payday', payday);
}

function getTimezone() {
    const timezone = cookie.get('timezone');
    return timezone ? timezone : defaultTimezone;
}

function saveTimezone(timezone) {
    setCookie('timezone', timezone);
}

function getFrequency() {
    const frequency = cookie.get('frequency');
    if (frequency) {
        return frequency;
    }
    return defaultFrequency;
}

function saveFrequency(frequency) {
    setCookie('frequency', frequency);
}

function getCountry() {
    const country = cookie.get('country');
    return country ? country : defaultCountry;
}

function saveCountry(country) {
    setCookie('country', country);
}

function setCookie(name, value) {
    cookie.set(name, value, { expires: 3650 });
}

export default {
    getPayday: getPayday,
    getTimezone: getTimezone,
    getFrequency: getFrequency,
    getCountry: getCountry,
    savePayday: savePayday,
    saveTimezone: saveTimezone,
    saveFrequency: saveFrequency,
    saveCountry: saveCountry
};
