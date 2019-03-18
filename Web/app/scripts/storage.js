var cookie = require("js-cookie");
var frequencies = require("./frequencies");

var defaultPayday = 25;
var defaultTimezone = "W. Europe Standard Time";
var defaultFrequency = "monthly";
var defaultCountry = "SE";

function getPayday() {
    var payday = cookie.get("payday");
    return payday ? payday : defaultPayday;
}

function savePayday(payday) {
    setCookie("payday", payday);
}

function getTimezone() {
    var timezone = cookie.get("timezone");
    return timezone ? timezone : defaultTimezone;
}

function saveTimezone(timezone) {
    setCookie("timezone", timezone);
}

function getFrequency() {
    var frequency = cookie.get("frequency");
    if (frequency) {
        if (frequency === "1")
            return frequencies.monthly;
        if (frequency === "2")
            return frequencies.weekly;
        return frequency;
    }
    return defaultFrequency;
}

function saveFrequency(frequency) {
    setCookie("frequency", frequency);
}

function getCountry() {
    var country = cookie.get("country");
    return country ? country : defaultCountry;
}

function saveCountry(country) {
    setCookie("country", country);
}

function setCookie(name, value) {
    cookie.set(name, value, { expires: 3650 });
}

module.exports = {
    getPayday: getPayday,
    getTimezone: getTimezone,
    getFrequency: getFrequency,
    getCountry: getCountry,
    savePayday: savePayday,
    saveTimezone: saveTimezone,
    saveFrequency: saveFrequency,
    saveCountry: saveCountry
}