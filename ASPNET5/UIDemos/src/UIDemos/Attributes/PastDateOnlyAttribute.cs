using Microsoft.AspNet.Mvc.ModelBinding;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace UIDemos.Attributes
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class PastDateOnlyAttribute : ValidationAttribute, IClientModelValidator
	{
		private const string DefaultErrorMessage = "Date must be earlier than today.";

		public override string FormatErrorMessage(string name)
		{
			return DefaultErrorMessage;
		}

		public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ClientModelValidationContext context)
		{
			var rule = new ModelClientValidationPastDateOnlyRule(FormatErrorMessage(context.ModelMetadata.GetDisplayName()));
			
			return new[] { rule };
		}

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if (value != null)
			{
				var now = DateTime.Now.Date;
				var dte = (DateTime)value;

				if (now <= dte) {
					return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
				}
			}

			return ValidationResult.Success;
		}
	}
	
	public class ModelClientValidationPastDateOnlyRule : ModelClientValidationRule
	{
		private const string PastOnlyValidateType = "pastdateonly";
		private const string MaxDate = "maxdate";

		public ModelClientValidationPastDateOnlyRule(
				string errorMessage)
			: base(validationType: PastOnlyValidateType, errorMessage: errorMessage)
		{	
			ValidationParameters.Add(MaxDate, DateTime.Now.Date);
		}
	}

	public class PastDateOnlyAttributeAttributeAdapter : DataAnnotationsModelValidator<PastDateOnlyAttribute>
	{
		public PastDateOnlyAttributeAttributeAdapter(PastDateOnlyAttribute attribute)
			: base(attribute)
		{
		}

		public override IEnumerable<ModelClientValidationRule> GetClientValidationRules(
			ClientModelValidationContext context)
		{
			var errorMessage = GetErrorMessage(context.ModelMetadata);
			yield return new ModelClientValidationPastDateOnlyRule(errorMessage);
		}
	}
}