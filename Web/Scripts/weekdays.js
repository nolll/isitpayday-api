function getName(payday) {
    if (payday === weekdays.monday)
        return "Monday";
    if (payday === weekdays.tuesday)
        return "Tuesday";
    if (payday === weekdays.wednesday)
        return "Wednesday";
    if (payday === weekdays.thursday)
        return "Thursday";
    if (payday === weekdays.friday)
        return "Friday";
    if (payday === weekdays.saturday)
        return "Saturday";
    return "Sunday";
}

module.exports = {
    monday: "1",
    tuesday: "2",
    wednesday: "3",
    thursday: "4",
    friday: "5",
    saturday: "6",
    sunday: "7",
    getName: getName
}