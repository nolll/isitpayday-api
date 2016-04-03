var html = require("html-loader!./timezone-form.html");

module.exports = {
    template: html,
    props: ["showForm", "timezone", "timezones"],
    methods: {
        select: function (event) {
            event.preventDefault();
            this.$dispatch("select-timezone", this.timezone);
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