using System.Web;
using System.Web.Mvc;

namespace InterviewTest.WebUI.Common
{
    public static class HtmlExtensions
    {
        public static HtmlString DisabledIf(this HtmlHelper html, bool condition)
        {
            return new HtmlString(condition ? "disabled=\"disabled\"" : "");
        }
    }
}