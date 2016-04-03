var Vue = require("vue");
var cookie = require("js-cookie");
var moment = require("moment");
var ajax = require("./ajax");

var app = new Vue({
    el: "#app",
    ready: function () {
        this.initData();
    },
    data: defaultData,
    computed: {
        message: function() {
            return this.isPayday ? "YES!!1!" : "No =(";
        },
        formattedLocalTime: function() {
            if (this.localTime)
                return moment(this.localTime).format("MMMM Do YYYY, HH:mm:ss");
            return "";
        }
    },
    methods: {
        initData: function () {
            this.loadSettings();
            this.loadPayday();
            this.loadOptions();
        },
        updatePayday: function() {
            this.loadPayday();
        },
        loadPayday: function() {
            ajax.load(this.getPaydayUrl(), this.loadedPayday, this.loadError);
        },
        loadedPayday: function (data) {
            this.isPayday = data.isPayday;
            this.localTime = data.localTime;
            this.initialized = true;
        },
        loadOptions: function () {
            ajax.load(this.getOptionsUrl(), this.loadedOptions, this.loadError);
        },
        loadedOptions: function (data) {
            this.countries = data.countries;
            this.timezones = data.timezones;
            this.initialized = true;
        },
        loadError: function () {
        },
        loadSettings: function () {
            this.payday = this.getPayday();
            this.timezone = this.getTimezone();
            this.frequency = this.getFrequency();
            this.country = this.getCountry();
        },
        getPayday: function () {
            var payday = cookie.get("payday");
            return payday ? payday : this.payday;
        },
        getTimezone: function () {
            var timezone = cookie.get("timezone");
            return timezone ? timezone : this.timezone;
        },
        getFrequency: function () {
            var frequency = cookie.get("frequency");
            if (frequency) {
                if (frequency === "1")
                    return "monthly";
                if (frequency === "2")
                    return "weekly";
                return frequency;
            }
            return this.frequency;
        },
        getCountry: function () {
            var country = cookie.get("country");
            return country ? country : this.country;
        },
        getPaydayUrl: function () {
            if (this.frequency === "weekly")
                return this.getWeeklyPaydayUrl();
            return this.getMonthlyPaydayUrl();
        },
        getMonthlyPaydayUrl: function () {
            var template = "/api/monthly?payday={payday}&country={country}&timezone={timezone}";
            return template
                .replace("{payday}", this.payday)
                .replace("{timezone}", this.timezone)
                .replace("{country}", this.country);
        },
        getWeeklyPaydayUrl: function () {
            var template = "/api/weekly?payday={payday}&country={country}&timezone={timezone}";
            return template
                .replace("{payday}", this.payday)
                .replace("{timezone}", this.timezone)
                .replace("{country}", this.country);
        },
        getOptionsUrl: function () {
            return "/api/options";
        },
        setCountry: function (country) {
            if (country !== this.country) {
                this.country = country;
                this.saveCountry(country);
                this.updatePayday();
            }
        },
        setFrequency: function (frequency) {
            if (frequency !== this.frequency) {
                this.frequency = frequency;
                this.saveFrequency(frequency);
                var payday = frequency === "weekly" ? 5 : 25;
                this.payday = payday;
                this.savePayday(payday);
                this.updatePayday();
            }
        },
        setTimezone: function (timezone) {
            if (timezone !== this.timezone) {
                this.timezone = timezone;
                this.saveTimezone(timezone);
                this.updatePayday();
            }
        },
        setPayday: function (payday) {
            if (payday !== this.payday) {
                this.payday = payday;
                this.savePayday(payday);
                this.updatePayday();
            }
        },
        saveCountry: function (country) {
            this.setCookie("country", country);
        },
        saveFrequency: function (frequency) {
            this.setCookie("frequency", frequency);
        },
        saveTimezone: function (timezone) {
            this.setCookie("timezone", timezone);
        },
        savePayday: function (payday) {
            this.setCookie("payday", payday);
        },
        setCookie(name, value) {
            cookie.set(name, value, { expires: 3650 });
        }
    },
    components: {
        "settings": require("./components/settings/settings")
    },
    events: {
        "select-country": function (country) {
            this.setCountry(country);
        },
        "select-frequency": function (frequency) {
            this.setFrequency(frequency);
        },
        "select-timezone": function (timezone) {
            this.setTimezone(timezone);
        },
        "select-payday": function (payday) {
            this.setPayday(payday);
        }
    }
});

function defaultData() {
    return {
        initialized: false,
        isPayday: false,
        payday: 25,
        timezone: "W. Europe Standard Time",
        frequency: "weekly",
        country: "SE",
        countries: [],
        timezones: [],
        localTime: null
    };
}