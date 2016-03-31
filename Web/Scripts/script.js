var Vue = require("vue");
var ajax = require("./ajax");

var app = new Vue({
    el: "#app",
    ready: function() {
        this.initialized = true;
    },
    data: function () {
        return {
            initialized: false,
            isPayDay: false,
            payday: 25,
            timezone: "W. Europe Standard Time",
            frequency: "weekly",
            country: "SE"
        }
    },
    computed: {
        message: function() {
            return this.isPayDay ? "YES!!1!" : "No =(";
        }
    }
})