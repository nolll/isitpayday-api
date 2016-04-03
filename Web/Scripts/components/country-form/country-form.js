var html = require("html-loader!./country-form.html");

module.exports = {
    template: html,
    props: ["showForm", "country", "countries"],
    methods: {
        select: function (event) {
            event.preventDefault();
            this.$dispatch("select-country", this.country);
            this.close();
        },
        open: function () {
            this.showForm = true;
        },
        close: function () {
            this.showForm = false;
        }
    }
};