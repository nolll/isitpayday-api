function setupCountryClick(){
	$(".change-country").click(function(){
		var url = $(this).attr("href");
		$(".country-info").load(url + " .country-info select", function(){
			setupCountryChange();
		});
		return false;
	});
}

function setupCountryChange(){
    $("#input_country").change(function () {
        $("form").submit();
        /*
		var val = $("option:selected", this).val();
		var url = "/?country=" + val;
		$("p.status").load(url + " p.status span", function(responseText, textStatus, XMLHttpRequest){
			$(".country-info").load("/" + " .country-info p", function(responseText, textStatus, XMLHttpRequest){
				setupCountryClick();
			});
		});
        */
	});
}

function setupTimezoneClick(){
	$(".change-timezone").click(function(){
		var url = $(this).attr("href");
		$(".timezone-info").load(url + " .timezone-info select", function(){
			setupTimezoneChange();
		});
		return false;
	});
}

function setupTimezoneChange(){
    $("#input_timezone").change(function () {
        $("form").submit();
        /*
		var val = $("option:selected", this).val();
		var url = "/?timezone=" + val;
		$("p.status").load(url + " p.status span", function(responseText, textStatus, XMLHttpRequest){
			$(".timezone-info").load("/" + " .timezone-info p", function(responseText, textStatus, XMLHttpRequest){
				setupTimezoneClick();
			});
		});
        */
    });
}

function setupPaydayClick(){
	$(".change-payday").click(function(){
		var url = $(this).attr("href");
		$(".payday-info").load(url + " .payday-info select", function(){
			setupPaydayChange();
		});
		return false;
	});
}

function setupPaydayChange(){
	$("#input_payday").change(function(){
	    $("form").submit();
	    /*
        var val = $("option:selected", this).val();
		var url = "/?payday=" + val;
		$("p.status").load(url + " p.status span", function(responseText, textStatus, XMLHttpRequest){
			$(".payday-info").load("/" + " .payday-info p", function(responseText, textStatus, XMLHttpRequest){
				setupPaydayClick();
			});
		});
        */
	});
}

$(document).ready(function(){
	setupCountryClick();
	setupTimezoneClick();
	setupPaydayClick();
});