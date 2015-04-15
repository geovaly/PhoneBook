using System.Linq;
using System.Web.Routing;

namespace InterviewTest.WebUI.Common
{
    public static class ObjectExtensions
    {
        public static RouteValueDictionary ToRoutes(this object o)
        {
            return new RouteValueDictionary(o);
        }

        public static RouteValueDictionary ToRoutes(this object o, params object[] others)
        {
            return new RouteValueDictionary(o).Add(others);
        }
    }
}