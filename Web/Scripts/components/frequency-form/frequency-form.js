var html = require("html-loader!./frequency-form.html");
var frequencies = require("frequencies");

module.exports = {
    template: html,
    props: ["showForm", "frequency"],
    data: getData,
    computed: {
        frequencyName: function() {
            var i;
            for (i = 0; i < this.frequencies.length; i++) {
                var f = this.frequencies[i];
                if (f.id === this.frequency) {
                    return f.name;
                }
            }
            return "";
        }
    },
    methods: {
        select: function (event) {
            event.preventDefault();
            this.$dispatch("select-frequency", this.frequency);
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

function getData() {
    return {
        frequencies: getFrequencies()
    }
}

function getFrequencies() {
    return [
        { id: frequencies.monthly, name: "Monthly" },
        { id: frequencies.weekly, name: "Weekly" }
    ];
}