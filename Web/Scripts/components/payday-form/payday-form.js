var html = require("html-loader!./payday-form.html");

module.exports = {
    template: html,
    props: ["showForm", "payday"],
    data: getData,
    computed: {
        paydayName: function () {
            return formatNth(this.payday);
        }
    },
    methods: {
        select: function (event) {
            event.preventDefault();
            this.$dispatch("select-payday", this.frequency);
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
        paydays.push({ id: i, name: formatNth(i) });
    }
    return paydays;
}

function formatNth(n)
{
    if (shouldFormatsAsFirst(n))
        return n + "st";
    if (shouldFormatsAsSecond(n))
        return n + "nd";
    if (shouldFormatsAsThird(n))
        return n + "rd";
    return n + "th";
}

function shouldFormatsAsFirst(n) {
    return endsWith(n, "1") && !endsWith(n, "11");
}

function shouldFormatsAsSecond(n) {
    return endsWith(n, "2") && !endsWith(n, "12");
}
        
function shouldFormatsAsThird(n) {
    return endsWith(n, "3") && !endsWith(n, "13");
}

function endsWith(n, lookFor) {
    return lastChar(n) === lookFor;
}

function lastChar(n) {
    return n.toString().slice(-1);
}