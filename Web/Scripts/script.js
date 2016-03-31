function countryClick() {
    var url = $(this).attr("href");
    $(".country-info").load(url + " .country-info select", setupCountryChange);
    return false;
}

function setupCountryChange(){
    $("#input_country").change(function () {
        $("form").submit();
	});
}

function timezoneClick() {
    var url = $(this).attr("href");
    $(".timezone-info").load(url + " .timezone-info select", setupTimezoneChange);
    return false;
}

function setupTimezoneChange(){
    $("#input_timezone").change(function () {
        $("form").submit();
    });
}

function frequencyClick() {
    var url = $(this).attr("href");
    $(".frequency-info").load(url + " .frequency-info select", setupFrequencyChange);
    return false;
}

function setupFrequencyChange() {
    $("#input_frequency").change(function () {
        $("form").submit();
    });
}

function paydayClick() {
    var url = $(this).attr("href");
    $(".payday-info").load(url + " .payday-info select", setupPaydayChange);
    return false;
}

function setupPaydayChange() {
    $("#input_payday").change(function () {
        $("form").submit();
    });
}

$(document).ready(function(){
    $(".change-country").click(countryClick);
    $(".change-timezone").click(timezoneClick);
    $(".change-frequency").click(frequencyClick);
    $(".change-payday").click(paydayClick);
});