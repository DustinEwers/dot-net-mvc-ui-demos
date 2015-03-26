﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

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
		public static HtmlHelper<T> TextEditBlockFor<T, TValue>(this HtmlHelper<T> helper,
										  Expression<Func<T, TValue>> prop,
										  string containerClass)
		{
			var modelData = ModelMetadata.FromLambdaExpression(prop, helper.ViewData);
			var writer = helper.ViewContext.Writer;

			var container = new TagBuilder("div");
			container.AddCssClass("form-group");
			container.AddCssClass(containerClass);

			var label = helper.LabelFor(prop);

			var text = (modelData.ModelType == typeof(DateTime) || modelData.ModelType == typeof(DateTime?)) ? helper.EditorFor(prop) : helper.TextBoxFor(prop, new { @class = "form-control" });
			var validation = helper.ValidationMessageFor(prop);

			container.InnerHtml = string.Format("{0} {1} {2}", label, text, validation);

			writer.Write(container.ToString(TagRenderMode.Normal));

			return helper;
		}

		/// <summary>
		/// Creates a Bootstrap Form Field with a container, label, editor, and validation message
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <typeparam name="TValue"></typeparam>
		/// <param name="helper"></param>
		/// <param name="prop"></param>
		/// <param name="items"></param>
		/// <param name="containerClass"></param>
		/// <returns></returns>
		public static HtmlHelper<T> DropDownBlockFor<T, TValue>(this HtmlHelper<T> helper,
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

			container.InnerHtml = string.Format("{0} {1} {2}", label, text, validation);

			writer.Write(container.ToString(TagRenderMode.Normal));

			return helper;
		}

		private class RowContainer : IDisposable
		{
			private readonly TextWriter _writer;

			public RowContainer(TextWriter writer)
			{
				_writer = writer;
			}

			public void Dispose()
			{
				_writer.Write("</div>");
			}
		}

		public static IDisposable BeginRow(this HtmlHelper htmlHelper, string cssClass = "")
		{
			var writer = htmlHelper.ViewContext.Writer;
			writer.WriteLine("<div class='row {0}'>", cssClass);
			return new RowContainer(writer);
		}
	}
}