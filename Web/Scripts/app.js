var Vue = require("vue");
var cookie = require("js-cookie");
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
        }
    },
    methods: {
        initData: function () {
            this.getSettings();
            ajax.load(this.getUrl(), this.loadComplete, this.loadError);
        },
        loadComplete: function (data) {
            this.isPayDay = data.isPayDay;
            this.initialized = true;
        },
        loadError: function () {
        },
        getSettings: function () {
            var payDay = cookie.get("payday");
            this.payDay = payDay ? payDay : this.payDay;

            var timezone = cookie.get("timezone");
            this.timezone = timezone ? timezone : this.timezone;

            var frequency = cookie.get("frequency");
            this.frequency = frequency ? frequency : this.frequency;

            var country = cookie.get("country");
            this.country = country ? country : this.country;
        },
        getUrl: function() {
            var template = "/api/data/get?frequency={frequency}&payday={payday}&country={country}&timezone={timezone}";
            return template
                .replace("{payday}", this.payDay)
                .replace("{timezone}", this.timezone)
                .replace("{frequency}", this.frequency)
                .replace("{country}", this.country);
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
        country: "SE"
    };
}