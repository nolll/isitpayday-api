var html = require("html-loader!./settings.html");

module.exports = {
    template: html,
    props: ["frequency", "payday", "country", "timezone"],
    computed: {
    },
    watch: {
    },
    methods: {
    }
};