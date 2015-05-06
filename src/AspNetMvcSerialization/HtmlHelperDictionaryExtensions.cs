namespace AspNetMvcSerialization
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web.Mvc;

    /// <summary>
    /// Extensions to the <see cref="HtmlHelper"/> class. These extensions all work on IDictionary&lt;TIn, TOut&gt; instances.
    /// </summary>
    public static class HtmlHelperDictionaryExtensions
    {
        public static MvcHtmlString Editor<TIn, TOut>(this HtmlHelper htmlHelper, string name, KeyValuePair<TIn, TOut> value, int index)
        {
            return Editor(htmlHelper, name, value, index, htmlAttributes: null);
        }

        public static MvcHtmlString Editor<TIn, TOut>(this HtmlHelper htmlHelper, string name, KeyValuePair<TIn, TOut> value, int index, object htmlAttributes)
        {
            return Editor(htmlHelper, name, value, index, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString Editor<TIn, TOut>(this HtmlHelper htmlHelper, string name, KeyValuePair<TIn, TOut> value, int index, IDictionary<string, object> htmlAttributes)
        {
            return EditorHelper(htmlHelper,
                metadata: null,
                value: value,
                index: index,
                expression: name,
                htmlAttributes: htmlAttributes);
        }

        public static MvcHtmlString Editor<TIn, TOut>(this HtmlHelper htmlHelper, string name, IDictionary<TIn, TOut> value)
        {
            return Editor(htmlHelper, name, value, htmlAttributes: null);
        }

        public static MvcHtmlString Editor<TIn, TOut>(this HtmlHelper htmlHelper, string name, IDictionary<TIn, TOut> value, object htmlAttributes)
        {
            return Editor(htmlHelper, name, value, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString Editor<TIn, TOut>(this HtmlHelper htmlHelper, string name, IDictionary<TIn, TOut> value, IDictionary<string, object> htmlAttributes)
        {
            return EditorHelper(htmlHelper,
                metadata: null,
                value: value,
                expression: name,
                htmlAttributes: htmlAttributes);
        }

        public static MvcHtmlString EditorFor<TModel, TIn, TOut>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IDictionary<TIn, TOut>>> expression, int index)
        {
            return EditorFor(htmlHelper, expression, index, null);
        }

        public static MvcHtmlString EditorFor<TModel, TIn, TOut>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IDictionary<TIn, TOut>>> expression, int index, object htmlAttributes)
        {
            return EditorFor(htmlHelper, expression, index, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString EditorFor<TModel, TIn, TOut>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IDictionary<TIn, TOut>>> expression, int index, IDictionary<string, object> htmlAttributes)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            return EditorHelper(htmlHelper,
                metadata,
                ((IDictionary<TIn, TOut>)metadata.Model).ElementAt(index),
                index, 
                ExpressionHelper.GetExpressionText(expression),
                htmlAttributes);
        }

        public static MvcHtmlString EditorFor<TModel, TIn, TOut>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IDictionary<TIn, TOut>>> expression)
        {
            return EditorFor(htmlHelper, expression, null);
        }

        public static MvcHtmlString EditorFor<TModel, TIn, TOut>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IDictionary<TIn, TOut>>> expression, object htmlAttributes)
        {
            return EditorFor(htmlHelper, expression, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString EditorFor<TModel, TIn, TOut>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IDictionary<TIn, TOut>>> expression, IDictionary<string, object> htmlAttributes)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            return EditorHelper(htmlHelper,
                metadata,
                (IDictionary<TIn, TOut>)metadata.Model,
                ExpressionHelper.GetExpressionText(expression),
                htmlAttributes);
        }

        private static MvcHtmlString EditorHelper<TIn, TOut>(HtmlHelper htmlHelper, ModelMetadata metadata, KeyValuePair<TIn, TOut> value, int index, string expression, IDictionary<string, object> htmlAttributes)
        {
            return InputHelper(htmlHelper, metadata, InputType.Text, value, index, expression, htmlAttributes);
        }

        private static MvcHtmlString EditorHelper<TIn, TOut>(HtmlHelper htmlHelper, ModelMetadata metadata, IDictionary<TIn, TOut> value, string expression, IDictionary<string, object> htmlAttributes)
        {
            return InputHelper(htmlHelper, metadata, InputType.Text, value, expression, htmlAttributes);
        }

        public static MvcHtmlString Hidden<TIn, TOut>(this HtmlHelper htmlHelper, string name, KeyValuePair<TIn, TOut> value, int index)
        {
            return Hidden(htmlHelper, name, value, index, htmlAttributes: null);
        }

        public static MvcHtmlString Hidden<TIn, TOut>(this HtmlHelper htmlHelper, string name, KeyValuePair<TIn, TOut> value, int index, object htmlAttributes)
        {
            return Hidden(htmlHelper, name, value, index, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString Hidden<TIn, TOut>(this HtmlHelper htmlHelper, string name, KeyValuePair<TIn, TOut> value, int index, IDictionary<string, object> htmlAttributes)
        {
            return HiddenHelper(htmlHelper,
                metadata: null,
                value: value,
                index: index,
                expression: name,
                htmlAttributes: htmlAttributes);
        }

        public static MvcHtmlString Hidden<TIn, TOut>(this HtmlHelper htmlHelper, string name, IDictionary<TIn, TOut> value)
        {
            return Hidden(htmlHelper, name, value, htmlAttributes: null);
        }

        public static MvcHtmlString Hidden<TIn, TOut>(this HtmlHelper htmlHelper, string name, IDictionary<TIn, TOut> value, object htmlAttributes)
        {
            return Hidden(htmlHelper, name, value, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString Hidden<TIn, TOut>(this HtmlHelper htmlHelper, string name, IDictionary<TIn, TOut> value, IDictionary<string, object> htmlAttributes)
        {
            return HiddenHelper(htmlHelper,
                metadata: null,
                value: value,
                expression: name,
                htmlAttributes: htmlAttributes);
        }

        public static MvcHtmlString HiddenFor<TModel, TIn, TOut>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IDictionary<TIn, TOut>>> expression, int index)
        {
            return HiddenFor(htmlHelper, expression, index, null);
        }

        public static MvcHtmlString HiddenFor<TModel, TIn, TOut>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IDictionary<TIn, TOut>>> expression, int index, object htmlAttributes)
        {
            return HiddenFor(htmlHelper, expression, index, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString HiddenFor<TModel, TIn, TOut>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IDictionary<TIn, TOut>>> expression, int index, IDictionary<string, object> htmlAttributes)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            return HiddenHelper(htmlHelper,
                metadata,
                ((IDictionary<TIn, TOut>)metadata.Model).ElementAt(index),
                index,
                ExpressionHelper.GetExpressionText(expression),
                htmlAttributes);
        }

        public static MvcHtmlString HiddenFor<TModel, TIn, TOut>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IDictionary<TIn, TOut>>> expression)
        {
            return HiddenFor(htmlHelper, expression, null);
        }

        public static MvcHtmlString HiddenFor<TModel, TIn, TOut>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IDictionary<TIn, TOut>>> expression, object htmlAttributes)
        {
            return HiddenFor(htmlHelper, expression, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString HiddenFor<TModel, TIn, TOut>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IDictionary<TIn, TOut>>> expression, IDictionary<string, object> htmlAttributes)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            return HiddenHelper(htmlHelper,
                metadata,
                (IDictionary<TIn, TOut>)metadata.Model,
                ExpressionHelper.GetExpressionText(expression),
                htmlAttributes);
        }

        private static MvcHtmlString HiddenHelper<TIn, TOut>(HtmlHelper htmlHelper, ModelMetadata metadata, KeyValuePair<TIn, TOut> value, int index, string expression, IDictionary<string, object> htmlAttributes)
        {
            return InputHelper(htmlHelper, metadata, InputType.Hidden, value, index, expression, htmlAttributes);
        }

        private static MvcHtmlString HiddenHelper<TIn, TOut>(HtmlHelper htmlHelper, ModelMetadata metadata, IDictionary<TIn, TOut> value, string expression, IDictionary<string, object> htmlAttributes)
        {
            return InputHelper(htmlHelper, metadata, InputType.Hidden, value, expression, htmlAttributes);
        }

        private static MvcHtmlString InputHelper<TIn, TOut>(HtmlHelper htmlHelper, ModelMetadata metadata, InputType inputType, KeyValuePair<TIn, TOut> value, int index, string expression, IDictionary<string, object> htmlAttributes)
        {
            var fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(expression);
            if (String.IsNullOrEmpty(fullName))
            {
                throw new ArgumentException("Field name is null or empty.");
            }

            var strings = new List<string>(2);
            strings.Add(InputHelperForKey(htmlHelper, metadata, expression, fullName, index, value.Key));
            strings.Add(InputHelperForValue(htmlHelper, metadata, inputType, expression, htmlAttributes, fullName, index, value.Value));

            return new MvcHtmlString(string.Join("\n", strings));
        }

        private static MvcHtmlString InputHelper<TIn, TOut>(HtmlHelper htmlHelper, ModelMetadata metadata, InputType inputType, IDictionary<TIn, TOut> value, string expression, IDictionary<string, object> htmlAttributes)
        {
            return new MvcHtmlString(string.Join("\n", value.Select((kv, i) => InputHelper(htmlHelper, metadata, inputType, kv, i, expression, htmlAttributes).ToHtmlString())));
        }

        private static string InputHelperForKey<TIn>(HtmlHelper htmlHelper, ModelMetadata metadata, string expression, string fullName, int index, TIn key)
        {
            return InputTagHelper(htmlHelper, metadata, InputType.Hidden, expression, null, fullName, index, "Key", key.ToString());
        }

        private static string InputHelperForValue<TOut>(HtmlHelper htmlHelper, ModelMetadata metadata, InputType inputType, string expression, IDictionary<string, object> htmlAttributes, string fullName, int index, TOut value)
        {
            return InputTagHelper(htmlHelper, metadata, inputType, expression, htmlAttributes, fullName, index, "Value", value.ToString());
        }

        private static string InputTagHelper(HtmlHelper htmlHelper, ModelMetadata metadata, InputType inputType, string expression, IDictionary<string, object> htmlAttributes, string fullName, int index, string fieldType, string val)
        {
            var tagBuilder = new TagBuilder("input");
            tagBuilder.MergeAttributes(htmlAttributes);
            tagBuilder.MergeAttribute("type", HtmlHelper.GetInputTypeString(inputType));
            tagBuilder.MergeAttribute("name", string.Format("{0}[{1}].{2}", fullName, index, fieldType), true);
            tagBuilder.MergeAttribute("value", val);

            tagBuilder.GenerateId(string.Format("{0}_{1}_{2}", fullName, index, fieldType));
            
            ModelState modelState;

            if (htmlHelper.ViewData.ModelState.TryGetValue(fullName, out modelState))
            {
                if (modelState.Errors.Count > 0)
                {
                    tagBuilder.AddCssClass(HtmlHelper.ValidationInputCssClassName);
                }
            }

            if (metadata != null)
            {
                tagBuilder.MergeAttributes(htmlHelper.GetUnobtrusiveValidationAttributes(expression, metadata));    
            }

            return tagBuilder.ToString(TagRenderMode.SelfClosing);
        }
    }
}