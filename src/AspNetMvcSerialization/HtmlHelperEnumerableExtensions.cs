namespace AspNetMvcSerialization
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web.Mvc;

    /// <summary>
    /// Extensions to the <see cref="HtmlHelper"/> class. These extensions all work on IEnumerable&lt;T&gt; instances.
    /// </summary>
    public static class HtmlHelperEnumerableExtensions
    {
        public static MvcHtmlString EditorIndexed<TIn>(this HtmlHelper htmlHelper, string name, TIn value, int index)
        {
            return EditorIndexed(htmlHelper, name, value, index, htmlAttributes: null);
        }

        public static MvcHtmlString EditorIndexed<TIn>(this HtmlHelper htmlHelper, string name, TIn value, int index, object htmlAttributes)
        {
            return EditorIndexed(htmlHelper, name, value, index, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString EditorIndexed<TIn>(this HtmlHelper htmlHelper, string name, TIn value, int index, IDictionary<string, object> htmlAttributes)
        {
            return EditorHelperIndexed(htmlHelper,
                metadata: null,
                value: value,
                index: index,
                expression: name,
                htmlAttributes: htmlAttributes);
        }

        public static MvcHtmlString Editor<TIn>(this HtmlHelper htmlHelper, string name, IEnumerable<TIn> value)
        {
            return Editor(htmlHelper, name, value, htmlAttributes: null);
        }

        public static MvcHtmlString Editor<TIn>(this HtmlHelper htmlHelper, string name, IEnumerable<TIn> value, object htmlAttributes)
        {
            return Editor(htmlHelper, name, value, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString Editor<TIn>(this HtmlHelper htmlHelper, string name, IEnumerable<TIn> value, IDictionary<string, object> htmlAttributes)
        {
            return EditorHelper(htmlHelper,
                metadata: null,
                value: value,
                expression: name,
                htmlAttributes: htmlAttributes);
        }

        public static MvcHtmlString EditorForIndexed<TModel, TIn>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IEnumerable<TIn>>> expression, int index)
        {
            return EditorForIndexed(htmlHelper, expression, index, null);
        }

        public static MvcHtmlString EditorForIndexed<TModel, TIn>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IEnumerable<TIn>>> expression, int index, object htmlAttributes)
        {
            return EditorForIndexed(htmlHelper, expression, index, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString EditorForIndexed<TModel, TIn>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IEnumerable<TIn>>> expression, int index, IDictionary<string, object> htmlAttributes)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            return EditorHelperIndexed(htmlHelper,
                metadata,
                ((IEnumerable<TIn>)metadata.Model).ElementAt(index),
                index, 
                ExpressionHelper.GetExpressionText(expression),
                htmlAttributes);
        }

        public static MvcHtmlString EditorFor<TModel, TIn>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IEnumerable<TIn>>> expression)
        {
            return EditorFor(htmlHelper, expression, null);
        }

        public static MvcHtmlString EditorFor<TModel, TIn>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IEnumerable<TIn>>> expression, object htmlAttributes)
        {
            return EditorFor(htmlHelper, expression, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString EditorFor<TModel, TIn>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IEnumerable<TIn>>> expression, IDictionary<string, object> htmlAttributes)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            return EditorHelper(htmlHelper,
                metadata,
                (IEnumerable<TIn>)metadata.Model,
                ExpressionHelper.GetExpressionText(expression),
                htmlAttributes);
        }

        internal static MvcHtmlString EditorHelperIndexed<TIn>(HtmlHelper htmlHelper, ModelMetadata metadata, TIn value, int index, string expression, IDictionary<string, object> htmlAttributes)
        {
            return InputHelperIndexed(htmlHelper, metadata, InputType.Text, value, index, expression, htmlAttributes);
        }

        internal static MvcHtmlString EditorHelper<TIn>(HtmlHelper htmlHelper, ModelMetadata metadata, IEnumerable<TIn> value, string expression, IDictionary<string, object> htmlAttributes)
        {
            return InputHelper(htmlHelper, metadata, InputType.Text, value, expression, htmlAttributes);
        }

        public static MvcHtmlString HiddenIndexed<TIn>(this HtmlHelper htmlHelper, string name, TIn value, int index)
        {
            return HiddenIndexed(htmlHelper, name, value, index, htmlAttributes: null);
        }

        public static MvcHtmlString HiddenIndexed<TIn>(this HtmlHelper htmlHelper, string name, TIn value, int index, object htmlAttributes)
        {
            return HiddenIndexed(htmlHelper, name, value, index, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString HiddenIndexed<TIn>(this HtmlHelper htmlHelper, string name, TIn value, int index, IDictionary<string, object> htmlAttributes)
        {
            return HiddenHelperIndexed(htmlHelper,
                metadata: null,
                value: value,
                index: index,
                expression: name,
                htmlAttributes: htmlAttributes);
        }

        public static MvcHtmlString Hidden<TIn>(this HtmlHelper htmlHelper, string name, IEnumerable<TIn> value)
        {
            return Hidden(htmlHelper, name, value, htmlAttributes: null);
        }

        public static MvcHtmlString Hidden<TIn>(this HtmlHelper htmlHelper, string name, IEnumerable<TIn> value, object htmlAttributes)
        {
            return Hidden(htmlHelper, name, value, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString Hidden<TIn>(this HtmlHelper htmlHelper, string name, IEnumerable<TIn> value, IDictionary<string, object> htmlAttributes)
        {
            return HiddenHelper(htmlHelper,
                metadata: null,
                value: value,
                expression: name,
                htmlAttributes: htmlAttributes);
        }

        public static MvcHtmlString HiddenForIndexed<TModel, TIn>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IEnumerable<TIn>>> expression, int index)
        {
            return HiddenForIndexed(htmlHelper, expression, index, null);
        }

        public static MvcHtmlString HiddenForIndexed<TModel, TIn>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IEnumerable<TIn>>> expression, int index, object htmlAttributes)
        {
            return HiddenForIndexed(htmlHelper, expression, index, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString HiddenForIndexed<TModel, TIn>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IEnumerable<TIn>>> expression, int index, IDictionary<string, object> htmlAttributes)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            return HiddenHelperIndexed(htmlHelper,
                metadata,
                ((IEnumerable<TIn>)metadata.Model).ElementAt(index),
                index,
                ExpressionHelper.GetExpressionText(expression),
                htmlAttributes);
        }

        public static MvcHtmlString HiddenFor<TModel, TIn>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IEnumerable<TIn>>> expression)
        {
            return HiddenFor(htmlHelper, expression, null);
        }

        public static MvcHtmlString HiddenFor<TModel, TIn>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IEnumerable<TIn>>> expression, object htmlAttributes)
        {
            return HiddenFor(htmlHelper, expression, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString HiddenFor<TModel, TIn>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IEnumerable<TIn>>> expression, IDictionary<string, object> htmlAttributes)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            return HiddenHelper(htmlHelper,
                metadata,
                (IEnumerable<TIn>)metadata.Model,
                ExpressionHelper.GetExpressionText(expression),
                htmlAttributes);
        }

        internal static MvcHtmlString HiddenHelper<TIn>(HtmlHelper htmlHelper, ModelMetadata metadata, IEnumerable<TIn> value, string expression, IDictionary<string, object> htmlAttributes)
        {
            return InputHelper(htmlHelper, metadata, InputType.Hidden, value, expression, htmlAttributes);
        }

        internal static MvcHtmlString HiddenHelperIndexed<TIn>(HtmlHelper htmlHelper, ModelMetadata metadata, TIn value, int index, string expression, IDictionary<string, object> htmlAttributes)
        {
            return InputHelperIndexed(htmlHelper, metadata, InputType.Hidden, value, index, expression, htmlAttributes);
        }

        private static MvcHtmlString InputHelperIndexed<TIn>(HtmlHelper htmlHelper, ModelMetadata metadata, InputType inputType, TIn value, int index, string expression, IDictionary<string, object> htmlAttributes)
        {
            var fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(expression);
            if (String.IsNullOrEmpty(fullName))
            {
                throw new ArgumentException("Field name is null or empty.");
            }

            if (value.IsSimpleType())
            {
                var inputHelperForValue = InputTagHelper(htmlHelper, metadata, inputType, expression, htmlAttributes, fullName, index, string.Empty, value.ToString(), true);

                return new MvcHtmlString(inputHelperForValue);
            }

            var strings = new List<string>();

            foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(value))
            {
                var inputHelperForValue = InputTagHelper(htmlHelper, metadata, inputType, expression, htmlAttributes, fullName, index, prop.Name, prop.GetValue(value).ToString(), false);
                strings.Add(inputHelperForValue);
            }

            return new MvcHtmlString(string.Join("\n", strings));
        }

        private static MvcHtmlString InputHelper<TIn>(HtmlHelper htmlHelper, ModelMetadata metadata, InputType inputType, IEnumerable<TIn> value, string expression, IDictionary<string, object> htmlAttributes)
        {
            return new MvcHtmlString(string.Join("\n", value.Select((kv, i) => InputHelperIndexed(htmlHelper, metadata, inputType, kv, i, expression, htmlAttributes).ToHtmlString())));
        }

        private static string InputTagHelper(HtmlHelper htmlHelper, ModelMetadata metadata, InputType inputType, string expression, IDictionary<string, object> htmlAttributes, string fullName, int index, string key, string val, bool isSimpleType)
        {
            var tagBuilder = new TagBuilder("input");
            tagBuilder.MergeAttributes(htmlAttributes);
            tagBuilder.MergeAttribute("type", HtmlHelper.GetInputTypeString(inputType));
            tagBuilder.MergeAttribute("name", GetElementName(fullName, index, key, isSimpleType), true);
            tagBuilder.MergeAttribute("value", val);

            tagBuilder.GenerateId(GetElementId(fullName, index, key));
            
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

        private static string GetElementId(string fullName, int index, string key)
        {
            return string.Format("{0}_{1}{2}", fullName, index, string.IsNullOrEmpty(key) ? null : "_" + key);
        }

        private static string GetElementName(string fullName, int index, string key, bool isSimpleType)
        {
            return isSimpleType ? fullName : string.Format("{0}[{1}]{2}", fullName, index, string.IsNullOrEmpty(key) ? null : "." + key);
        }

        private static bool IsSimpleType(this object val)
        {
            return val == null || val is string || val.GetType().IsValueType;
        }
    }
}