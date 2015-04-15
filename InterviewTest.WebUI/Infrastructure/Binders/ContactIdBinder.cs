using System.Web;
using System.Web.Mvc;
using InterviewTest.Domain.Model.PhoneBook;

namespace InterviewTest.WebUI.Infrastructure.Binders
{
    public class ContactIdBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var request = controllerContext.HttpContext.Request;
            var idString = ParamsOrForm(request, bindingContext.ModelName);

            return string.IsNullOrEmpty(idString)
                ? ContactId.Null
                : new ContactId(int.Parse(idString));
        }

        private static string ParamsOrForm(HttpRequestBase request, string name)
        {
            return request.Params[name] ?? request.Form.Get(name) ?? string.Empty;
        }
    }
}