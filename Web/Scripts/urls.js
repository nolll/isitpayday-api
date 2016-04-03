module.exports = {
    getMonthlyUrl: function (payday, timezone, country) {
        var template = "/api/monthly?payday={payday}&country={country}&timezone={timezone}";
        return template
            .replace("{payday}", payday)
            .replace("{timezone}", timezone)
            .replace("{country}", country);
    },
    getWeeklyUrl: function (payday, timezone, country) {
        var template = "/api/weekly?payday={payday}&country={country}&timezone={timezone}";
        return template
            .replace("{payday}", payday)
            .replace("{timezone}", timezone)
            .replace("{country}", country);
    },
    getOptionsUrl: function () {
        return "/api/options";
    },
}