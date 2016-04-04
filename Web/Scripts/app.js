var Vue = require("vue"),
    cookie = require("js-cookie"),
    moment = require("moment"),
    ajax = require("ajax"),
    storage = require("storage"),
    frequencies = require("frequencies"),
    urls = require("urls");

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
            ajax.load(urls.getOptionsUrl(), this.loadedOptions, this.loadError);
        },
        loadedOptions: function (data) {
            this.countries = data.countries;
            this.timezones = data.timezones;
            this.initialized = true;
        },
        loadError: function () {
        },
        getPaydayUrl: function () {
            if (this.frequency === frequencies.weekly)
                return urls.getWeeklyUrl(this.payday, this.timezone, this.country);
            return urls.getMonthlyUrl(this.payday, this.timezone, this.country);
        },
        setCountry: function (country) {
            if (country !== this.country) {
                this.country = country;
                storage.saveCountry(country);
                this.updatePayday();
            }
        },
        setFrequency: function (frequency) {
            if (frequency !== this.frequency) {
                this.frequency = frequency;
                storage.saveFrequency(frequency);
                var payday = frequency === frequencies.weekly ? 5 : 25;
                this.payday = payday;
                storage.savePayday(payday);
                this.updatePayday();
            }
        },
        setTimezone: function (timezone) {
            if (timezone !== this.timezone) {
                this.timezone = timezone;
                storage.saveTimezone(timezone);
                this.updatePayday();
            }
        },
        setPayday: function (payday) {
            if (payday !== this.payday) {
                this.payday = payday;
                storage.savePayday(payday);
                this.updatePayday();
            }
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
        payday: storage.getPayday(),
        timezone: storage.getTimezone(),
        frequency: storage.getFrequency(),
        country: storage.getCountry(),
        countries: [],
        timezones: [],
        localTime: null
    };
}