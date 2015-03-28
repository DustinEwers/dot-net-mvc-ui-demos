$(document).ready(function () {
	$("input[data-val-datepicker]").each(function () {
		$(this).datetimepicker({
			format: "MM/DD/YYYY"
		});
	});
});


jQuery.validator.addMethod("pastdateonly", function (val, element, params) {
	var value = $.trim($(element).val());
	if (value === '') return true;

	var maxDate = params.maxdate;

	return Date(value) < Date(maxDate);
});

jQuery.validator.unobtrusive.adapters.add("pastdateonly", ["maxdate"],
  function (options) {
  	options.rules["pastdateonly"] = {
  		maxdate: options.params.maxdate
  	};
  	options.messages["pastdateonly"] = options.message;
  }
);