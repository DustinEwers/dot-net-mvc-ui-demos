using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace UIDemos.Attributes
{
	[AttributeUsage(AttributeTargets.Property)]
	public class PastDateOnlyAttribute : ValidationAttribute, IClientValidatable
	{
		private const string DefaultErrorMessage = "Date must be earlier than today.";

		public override string FormatErrorMessage(string name)
		{
			return DefaultErrorMessage;
		}

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if (value == null) return ValidationResult.Success;

			var now = DateTime.Now.Date;
			var dte = (DateTime)value;

			return now <= dte ? new ValidationResult(FormatErrorMessage(validationContext.DisplayName)) : ValidationResult.Success;
		}

		public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
		{
			var rule = new ModelClientValidationPastDateOnlyRule(FormatErrorMessage(metadata.GetDisplayName()));

			yield return rule;
		}
	}

	public class ModelClientValidationPastDateOnlyRule : ModelClientValidationRule
	{
		private const string PastOnlyValidateType = "pastdateonly";
		private const string MaxDate = "maxdate";

		public ModelClientValidationPastDateOnlyRule(
				string errorMessage)
		{
			ValidationType = PastOnlyValidateType;
			ErrorMessage = errorMessage;
			ValidationParameters.Add(MaxDate, DateTime.Now.Date.ToShortDateString());
		}
	}
}
