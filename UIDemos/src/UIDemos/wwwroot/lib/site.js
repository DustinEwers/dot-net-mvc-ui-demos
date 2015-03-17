$(document).ready(function () {
	$("input[data-val-datepicker]").each(function () {
		$(this).datetimepicker({
			format: "MM/DD/YYYY"
		});
	});
});