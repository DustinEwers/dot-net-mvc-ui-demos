using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Mvc.Rendering.Expressions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;

namespace UIDemos.Helpers
{
    public static class HtmlHelperExtentions
    {
		/// <summary>
		/// Creates a Bootstrap Form Field with a container, label, editor, and validation message
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <typeparam name="TValue"></typeparam>
		/// <param name="helper"></param>
		/// <param name="prop"></param>
		/// <param name="containerClass"></param>
		/// <returns></returns>
		public static IHtmlHelper<T> TextEditBlockFor<T, TValue>(this IHtmlHelper<T> helper,
										  Expression<System.Func<T, TValue>> prop,
										  string containerClass)
		{
			var modelData = ExpressionMetadataProvider.FromLambdaExpression(prop, helper.ViewData, helper.MetadataProvider);
			var writer = helper.ViewContext.Writer;
			
            var container = new TagBuilder("div");
			container.AddCssClass("form-group");
			container.AddCssClass(containerClass);
			
			var label = helper.LabelFor(prop);
			
			var text =  (modelData.ModelType == typeof(DateTime) || modelData.ModelType == typeof(DateTime?)) ? helper.EditorFor(prop) :  helper.TextBoxFor(prop, new { @class="form-control"});
			var validation = helper.ValidationMessageFor(prop);

			container.InnerHtml = string.Format("{0} {1} {2}", label, text, validation);

			writer.Write(container.ToHtmlString(TagRenderMode.Normal));
			
			return helper;
		}

		/// <summary>
		/// Creates a Bootstrap Form Field with a container, label, editor, and validation message
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <typeparam name="TValue"></typeparam>
		/// <param name="helper"></param>
		/// <param name="prop"></param>
		/// <param name="containerClass"></param>
		/// <returns></returns>
		public static IHtmlHelper<T> DropDownBlockFor<T, TValue>(this IHtmlHelper<T> helper,
										  Expression<Func<T, TValue>> prop,
										  IEnumerable<SelectListItem> items,
										  string containerClass)
		{
			var writer = helper.ViewContext.Writer;

			var container = new TagBuilder("div");
			container.AddCssClass("form-group");
			container.AddCssClass(containerClass);

			var label = helper.LabelFor(prop);
			var text = helper.DropDownListFor(prop, items, new { @class = "form-control" });
			var validation = helper.ValidationMessageFor(prop);

			container.InnerHtml = string.Format("{0} {1} {2}", label.ToString(), text.ToString(), validation.ToString());

			writer.Write(container.ToHtmlString(TagRenderMode.Normal));

			return helper;
		}
		
		private class RowContainer : IDisposable {
			private readonly TextWriter _writer;

			public RowContainer(TextWriter writer) {
				_writer = writer;
			}

			public void Dispose()
			{
				_writer.Write("</div>");
            }
		}

		public static IDisposable BeginRow(this IHtmlHelper htmlHelper, string cssClass = "") {
			var writer = htmlHelper.ViewContext.Writer;
			writer.WriteLine(string.Format("<div class='row {0}'>", cssClass));
			return new RowContainer(writer);
		}
	}
}