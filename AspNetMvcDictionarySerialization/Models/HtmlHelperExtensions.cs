namespace AspNetMvcDictionarySerialization.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web.Mvc;

    /// <summary>
    /// Extensions to the <see cref="HtmlHelper"/> class. These extensions all work on IDictionary string, string instances.
    /// </summary>
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString Editor(this HtmlHelper htmlHelper, string name, IDictionary<string, string> value)
        {
            return Editor(htmlHelper, name, value, htmlAttributes: null);
        }

        public static MvcHtmlString Editor(this HtmlHelper htmlHelper, string name, IDictionary<string, string> value, object htmlAttributes)
        {
            return Editor(htmlHelper, name, value, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString Editor(this HtmlHelper htmlHelper, string name, IDictionary<string, string> value, IDictionary<string, object> htmlAttributes)
        {
            return EditorHelper(htmlHelper,
                metadata: null,
                value: value,
                expression: name,
                htmlAttributes: htmlAttributes);
        }

        public static MvcHtmlString EditorFor<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IDictionary<string, string>>> expression)
        {
            return EditorFor(htmlHelper, expression, null);
        }

        public static MvcHtmlString EditorFor<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IDictionary<string, string>>> expression, object htmlAttributes)
        {
            return EditorFor(htmlHelper, expression, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString EditorFor<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IDictionary<string, string>>> expression, IDictionary<string, object> htmlAttributes)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            return EditorHelper(htmlHelper,
                metadata,
                (IDictionary<string, string>)metadata.Model,
                ExpressionHelper.GetExpressionText(expression),
                htmlAttributes);
        }

        private static MvcHtmlString EditorHelper(HtmlHelper htmlHelper, ModelMetadata metadata, IDictionary<string, string> value, string expression, IDictionary<string, object> htmlAttributes)
        {
            return InputHelper(htmlHelper, metadata, InputType.Text, value, expression, htmlAttributes);
        }

        public static MvcHtmlString Hidden(this HtmlHelper htmlHelper, string name, IDictionary<string, string> value)
        {
            return Hidden(htmlHelper, name, value, htmlAttributes: null);
        }

        public static MvcHtmlString Hidden(this HtmlHelper htmlHelper, string name, IDictionary<string, string> value, object htmlAttributes)
        {
            return Hidden(htmlHelper, name, value, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString Hidden(this HtmlHelper htmlHelper, string name, IDictionary<string, string> value, IDictionary<string, object> htmlAttributes)
        {
            return HiddenHelper(htmlHelper,
                metadata: null,
                value: value,
                expression: name,
                htmlAttributes: htmlAttributes);
        }

        public static MvcHtmlString HiddenFor<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IDictionary<string, string>>> expression)
        {
            return HiddenFor(htmlHelper, expression, null);
        }

        public static MvcHtmlString HiddenFor<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IDictionary<string, string>>> expression, object htmlAttributes)
        {
            return HiddenFor(htmlHelper, expression, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString HiddenFor<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IDictionary<string, string>>> expression, IDictionary<string, object> htmlAttributes)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            return HiddenHelper(htmlHelper,
                metadata,
                (IDictionary<string, string>)metadata.Model,
                ExpressionHelper.GetExpressionText(expression),
                htmlAttributes);
        }

        private static MvcHtmlString HiddenHelper(HtmlHelper htmlHelper, ModelMetadata metadata, IDictionary<string, string> value, string expression, IDictionary<string, object> htmlAttributes)
        {
            return InputHelper(htmlHelper, metadata, InputType.Hidden, value, expression, htmlAttributes);
        }

        private static MvcHtmlString InputHelper(HtmlHelper htmlHelper, ModelMetadata metadata, InputType inputType, IDictionary<string, string> value, string expression, IDictionary<string, object> htmlAttributes)
        {
            var fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(expression);
            if (String.IsNullOrEmpty(fullName))
            {
                throw new ArgumentException("Field name is null or empty.", "name");
            }

            var strings = new List<string>(value.Count * 2);

            // For every element in the dictionary, we will create an input field for the key and one for the value
            for (var i = 0; i < value.Count; i++)
            {
                strings.Add(InputHelperForKey(htmlHelper, metadata, inputType, value, expression, htmlAttributes, fullName, i));
                strings.Add(InputHelperForValue(htmlHelper, metadata, inputType, value, expression, htmlAttributes, fullName, i));
            }

            return new MvcHtmlString(string.Join("\n", strings));
        }

        private static string InputHelperForKey(HtmlHelper htmlHelper, ModelMetadata metadata, InputType inputType, IDictionary<string, string> value, string expression, IDictionary<string, object> htmlAttributes, string fullName, int index)
        {
            return InputTagHelper(htmlHelper, metadata, inputType, expression, htmlAttributes, fullName, index, "Key", value.Keys.ElementAt(index));
        }

        private static string InputHelperForValue(HtmlHelper htmlHelper, ModelMetadata metadata, InputType inputType, IDictionary<string, string> value, string expression, IDictionary<string, object> htmlAttributes, string fullName, int index)
        {
            return InputTagHelper(htmlHelper, metadata, inputType, expression, htmlAttributes, fullName, index, "Value", value.Values.ElementAt(index));
        }

        private static string InputTagHelper(HtmlHelper htmlHelper, ModelMetadata metadata, InputType inputType, string expression, IDictionary<string, object> htmlAttributes, string fullName, int index, string fieldType, string val)
        {
            var tagBuilder = new TagBuilder("input");
            tagBuilder.MergeAttributes(htmlAttributes);
            tagBuilder.MergeAttribute("type", HtmlHelper.GetInputTypeString(inputType));
            tagBuilder.MergeAttribute("name", string.Format("{0}[{1}].{2}", fullName, index, fieldType), true);
            tagBuilder.MergeAttribute("value", val);

            tagBuilder.GenerateId(fullName);

            // If there are any errors for the named field, we add the css attribute.
            ModelState modelState;
            if (htmlHelper.ViewData.ModelState.TryGetValue(fullName, out modelState))
            {
                if (modelState.Errors.Count > 0)
                {
                    tagBuilder.AddCssClass(HtmlHelper.ValidationInputCssClassName);
                }
            }

            tagBuilder.MergeAttributes(htmlHelper.GetUnobtrusiveValidationAttributes(expression, metadata));

            return tagBuilder.ToString(TagRenderMode.SelfClosing);
        }
    }
}