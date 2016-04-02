var Vue = require("vue");
var ajax = require("./ajax");

var app = new Vue({
    el: "#app",
    ready: function () {
        this.initData(getUrl());
    },
    data: defaultData,
    computed: {
        message: function() {
            return this.isPayDay ? "YES!!1!" : "No =(";
        }
    },
    methods: {
        initData: function (url) {
            ajax.load(url, this.loadComplete, this.loadError);
        },
        loadComplete: function (data) {
            this.isPayDay = data.isPayDay;
            this.initialized = true;
        },
        loadError: function () {
        }
    }
});

function getUrl() {
    return "/api/data/get";
}

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