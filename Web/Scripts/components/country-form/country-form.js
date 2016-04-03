var html = require("html-loader!./country-form.html");

module.exports = {
    template: html,
    props: ["showForm", "country", "countries"],
    computed: {
        countryName: function() {
            var i;
            for (i = 0; i < this.countries.length; i++) {
                var c = this.countries[i];
                if (c.id === this.country) {
                    return c.name;
                }
            }
            return "";
        }
    },
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