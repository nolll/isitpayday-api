export default {
    getMonthlyUrl(payday: number, timezone: string, country: string) {
        return `/api/monthly?payday=${payday}&country=${country}&timezone=${timezone}`;
    },
    getWeeklyUrl(payday: number, timezone: string, country: string) {
        return `/api/weekly?payday=${payday}&country=${country}&timezone=${timezone}`;
    },
    getOptionsUrl() {
        return '/api/options';
    }
};
