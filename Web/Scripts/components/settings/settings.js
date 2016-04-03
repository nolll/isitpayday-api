var html = require("html-loader!./settings.html");

module.exports = {
    template: html,
    props: ["frequency", "payday", "country", "timezone", "countries"],
    computed: {
    },
    watch: {
    },
    methods: {
    },
    components: {
        "country-form": require("../country-form/country-form"),
        "timezone-form": require("../timezone-form/timezone-form"),
        "frequency-form": require("../frequency-form/frequency-form"),
        "payday-form": require("../payday-form/payday-form")
    }
};