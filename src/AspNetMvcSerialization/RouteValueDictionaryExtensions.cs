namespace AspNetMvcSerialization
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Web.Routing;

    public static class RouteValueDictionaryExtensions
    {
        /// <summary>
        /// Create a new <see cref="RouteValueDictionary"/> in which complex types, such as classes, <see cref="IEnumerable"/> and
        /// <see cref="IDictionary"/> instances are correctly serialized.
        /// </summary>
        /// <param name="routeValues">The route values.</param>
        /// <returns>The <see cref="RouteValueDictionary"/> with correctly serialized complex type.</returns>
        public static RouteValueDictionary ToExtendedRouteValueDictionary(this RouteValueDictionary routeValues)
        {
            if (routeValues == null)
            {
                throw new ArgumentNullException("routeValues");
            }

            var newRouteValues = new RouteValueDictionary();
            
            foreach (var key in routeValues.Keys)
            {
                AddToRouteValues(key, routeValues[key], newRouteValues);
            }

            return newRouteValues;
        }

        private static void AddToRouteValues(string key, object value, RouteValueDictionary routeValues)
        {
            if (value.IsSimpleType())
            {
                AddSimpleTypeToRouteValues(key, value, routeValues);
            }
            else if (value is IDictionary)
            {
                AddDictionaryToRouteValues(key, (IDictionary)value, routeValues);
            }
            else if (value is IEnumerable)
            {
                AddEnumerableToRouteValues(key, (IEnumerable)value, routeValues);
            }
            else
            {
                AddComplexTypeToRouteValues(key, value, routeValues);
            }
        }

        private static void AddSimpleTypeToRouteValues(string key, object value, RouteValueDictionary routeValues)
        {
            routeValues.Add(key, value);
        }

        private static void AddComplexTypeToRouteValues(string key, object value, RouteValueDictionary routeValues)
        {
            foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(value))
            {
                AddToRouteValues(string.Format("{0}.{1}", key, prop.Name), prop.GetValue(value), routeValues);
            }
        }

        private static void AddEnumerableToRouteValues(string key, IEnumerable enumerable, RouteValueDictionary routeValues)
        {
            var index = 0;

            foreach (var value in enumerable)
            {
                AddToRouteValues(string.Format("{0}[{1}]", key, index++), value, routeValues);
            }
        }

        private static void AddDictionaryToRouteValues(string key, IDictionary dictionary, RouteValueDictionary routeValues)
        {
            var index = 0;

            foreach (var dictionaryKey in dictionary.Keys)
            {
                routeValues.Add(string.Format("{0}[{1}].Key", key, index), dictionaryKey);
                routeValues.Add(string.Format("{0}[{1}].Value", key, index), dictionary[dictionaryKey]);

                index++;
            }
        }

        private static bool IsSimpleType(this object val)
        {
            return val == null || val is string || val.GetType().IsValueType;
        }
    }
}