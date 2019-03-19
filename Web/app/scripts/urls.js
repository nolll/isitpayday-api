export default {
    getMonthlyUrl: function(payday, timezone, country) {
        return `/api/monthly?payday=${payday}&country=${country}&timezone=${timezone}`;
    },
    getWeeklyUrl: function(payday, timezone, country) {
        return `/api/weekly?payday=${payday}&country=${country}&timezone=${timezone}`;
    },
    getOptionsUrl: function() {
        return '/api/options';
    }
};
