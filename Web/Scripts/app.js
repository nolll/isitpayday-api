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
            return this.isPayDay ? "YES!!1!" : "No =(";
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
            this.loadPayDay();
            this.loadOptions();
        },
        updatePayDay: function() {
            this.loadPayDay();
        },
        loadPayDay: function() {
            ajax.load(this.getPaydayUrl(), this.loadedPayDay, this.loadError);
        },
        loadedPayDay: function (data) {
            this.isPayDay = data.isPayDay;
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
            this.payDay = this.getPayDay();
            this.timezone = this.getTimezone();
            this.frequency = this.getFrequency();
            this.country = this.getCountry();
        },
        getPayDay: function () {
            var payDay = cookie.get("payday");
            return payDay ? payDay : this.payDay;
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
            var template = "/api/data/get?frequency={frequency}&payday={payday}&country={country}&timezone={timezone}";
            return template
                .replace("{payday}", this.payDay)
                .replace("{timezone}", this.timezone)
                .replace("{frequency}", this.frequency)
                .replace("{country}", this.country);
        },
        getOptionsUrl: function () {
            return "/api/data/options";
        }
    },
    components: {
        "settings": require("./components/settings/settings")
    },
    events: {
        "select-country": function (country) {
            this.country = country;
            this.updatePayDay();
        }
    }
});

function defaultData() {
    return {
        initialized: false,
        isPayDay: false,
        payday: 25,
        timezone: "W. Europe Standard Time",
        frequency: "weekly",
        country: "SE",
        countries: [],
        timezones: [],
        localTime: null
    };
}