var html = require("html-loader!./payday-form.html");
var frequencies = require("frequencies");
var weekdays = require("weekdays");
var nthFormatter = require("nth-formatter");

module.exports = {
    template: html,
    props: ["showForm", "payday", "frequency"],
    data: getData,
    computed: {
        paydayName: function () {
            return format(this.payday);
        }
    },
    methods: {
        select: function (event) {
            event.preventDefault();
            this.$dispatch("select-payday", this.payday);
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
        paydays: getPayDays()
    }
}

function getPayDays() {
    var paydays = [],
        i;

    for (i = 1; i <= 31; i++) {
        paydays.push({ id: i, name: format(i) });
    }
    return paydays;
}

function format(n) {
    if (this.frequency === frequencies.weekly)
        return weekdays.getName(n);
    return nthFormatter.format(n);
}