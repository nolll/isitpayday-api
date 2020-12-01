import frequencies from './frequencies';

const monthlyPayday = 25;
const weeklyPayday = 25;

export default {
    monthlyPayday: monthlyPayday,
    weeklyPayday: weeklyPayday,
    payday: monthlyPayday,
    timezone: 'W. Europe Standard Time',
    frequency: frequencies.monthly,
    country: 'SE',
};
