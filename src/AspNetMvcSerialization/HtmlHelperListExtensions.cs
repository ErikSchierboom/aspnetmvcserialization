namespace AspNetMvcSerialization
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web.Mvc;

    /// <summary>
    /// Extensions to the <see cref="HtmlHelper"/> class. These extensions all work on IList&lt;T&gt; instances.
    /// </summary>
    public static class HtmlHelperListExtensions
    {
        public static MvcHtmlString Editor<TIn>(this HtmlHelper htmlHelper, string name, IList<TIn> value)
        {
            return HtmlHelperEnumerableExtensions.Editor(htmlHelper, name, value);
        }

        public static MvcHtmlString Editor<TIn>(this HtmlHelper htmlHelper, string name, IList<TIn> value, object htmlAttributes)
        {
            return HtmlHelperEnumerableExtensions.Editor(htmlHelper, name, value, htmlAttributes);
        }

        public static MvcHtmlString Editor<TIn>(this HtmlHelper htmlHelper, string name, IList<TIn> value, IDictionary<string, object> htmlAttributes)
        {
            return HtmlHelperEnumerableExtensions.Editor(htmlHelper, name, value, htmlAttributes);
        }

        public static MvcHtmlString EditorForIndexed<TModel, TIn>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IList<TIn>>> expression, int index)
        {
            return EditorForIndexed(htmlHelper, expression, index, null);
        }

        public static MvcHtmlString EditorForIndexed<TModel, TIn>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IList<TIn>>> expression, int index, object htmlAttributes)
        {
            return EditorForIndexed(htmlHelper, expression, index, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString EditorForIndexed<TModel, TIn>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IList<TIn>>> expression, int index, IDictionary<string, object> htmlAttributes)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            return HtmlHelperEnumerableExtensions.EditorHelperIndexed(htmlHelper,
                metadata,
                ((IEnumerable<TIn>)metadata.Model).ElementAt(index),
                index,
                ExpressionHelper.GetExpressionText(expression),
                htmlAttributes);
        }

        public static MvcHtmlString EditorFor<TModel, TIn>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IList<TIn>>> expression)
        {
            return EditorFor(htmlHelper, expression, null);
        }

        public static MvcHtmlString EditorFor<TModel, TIn>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IList<TIn>>> expression, object htmlAttributes)
        {
            return EditorFor(htmlHelper, expression, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString EditorFor<TModel, TIn>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IList<TIn>>> expression, IDictionary<string, object> htmlAttributes)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            return HtmlHelperEnumerableExtensions.EditorHelper(htmlHelper,
                metadata,
                (IEnumerable<TIn>)metadata.Model,
                ExpressionHelper.GetExpressionText(expression),
                htmlAttributes);
        }

        public static MvcHtmlString Hidden<TIn>(this HtmlHelper htmlHelper, string name, IList<TIn> value)
        {
            return Hidden(htmlHelper, name, value, htmlAttributes: null);
        }

        public static MvcHtmlString Hidden<TIn>(this HtmlHelper htmlHelper, string name, IList<TIn> value, object htmlAttributes)
        {
            return Hidden(htmlHelper, name, value, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString Hidden<TIn>(this HtmlHelper htmlHelper, string name, IList<TIn> value, IDictionary<string, object> htmlAttributes)
        {
            return HtmlHelperEnumerableExtensions.HiddenHelper(htmlHelper,
                metadata: null,
                value: value,
                expression: name,
                htmlAttributes: htmlAttributes);
        }

        public static MvcHtmlString HiddenForIndexed<TModel, TIn>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IList<TIn>>> expression, int index)
        {
            return HiddenForIndexed(htmlHelper, expression, index, null);
        }

        public static MvcHtmlString HiddenForIndexed<TModel, TIn>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IList<TIn>>> expression, int index, object htmlAttributes)
        {
            return HiddenForIndexed(htmlHelper, expression, index, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString HiddenForIndexed<TModel, TIn>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IList<TIn>>> expression, int index, IDictionary<string, object> htmlAttributes)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            return HtmlHelperEnumerableExtensions.HiddenHelperIndexed(htmlHelper,
                metadata,
                ((IEnumerable<TIn>)metadata.Model).ElementAt(index),
                index,
                ExpressionHelper.GetExpressionText(expression),
                htmlAttributes);
        }

        public static MvcHtmlString HiddenFor<TModel, TIn>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IList<TIn>>> expression)
        {
            return HiddenFor(htmlHelper, expression, null);
        }

        public static MvcHtmlString HiddenFor<TModel, TIn>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IList<TIn>>> expression, object htmlAttributes)
        {
            return HiddenFor(htmlHelper, expression, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString HiddenFor<TModel, TIn>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IList<TIn>>> expression, IDictionary<string, object> htmlAttributes)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            return HtmlHelperEnumerableExtensions.HiddenHelper(htmlHelper,
                metadata,
                (IEnumerable<TIn>)metadata.Model,
                ExpressionHelper.GetExpressionText(expression),
                htmlAttributes);
        }
    }
}