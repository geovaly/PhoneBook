using System.Collections.Generic;
using System.Linq;
using System.Web.Routing;

namespace InterviewTest.WebUI.Common
{
    public static class RouteValueDictionaryExtensions
    {
        public static RouteValueDictionary Add(this RouteValueDictionary routeValueDictionary, params object[] values)
        {
            return Add(routeValueDictionary, values.Select(v => new RouteValueDictionary(v)));
        }

        public static RouteValueDictionary Add(this RouteValueDictionary routeValueDictionary, params RouteValueDictionary[] otherRouteValueDictionaries)
        {
            return Add(routeValueDictionary, otherRouteValueDictionaries as IEnumerable<RouteValueDictionary>);
        }

        public static RouteValueDictionary Add(this RouteValueDictionary routeValueDictionary, IEnumerable<RouteValueDictionary> others)
        {
            foreach (var other in others)
            {
                foreach (var key in other.Keys)
                {
                    routeValueDictionary.Add(key, other[key]);
                }
            }

            return routeValueDictionary;
        }

        public static RouteValueDictionary DisabledIf(this RouteValueDictionary routeValueDictionary, bool condition)
        {
            if (condition)
                routeValueDictionary.Add("disabled", "true");

            return routeValueDictionary;
        }
    }
}