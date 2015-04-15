using System.Web.Mvc;
using InterviewTest.Domain.Model.PhoneBook;

namespace InterviewTest.WebUI.Infrastructure.Binders
{
    public class ContactTelephoneBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var request = controllerContext.HttpContext.Request;

            return new ContactTelephone(
                request.Form.Get(bindingContext.ModelName + ".TelephoneNumber") ?? string.Empty,
                request.Form.Get(bindingContext.ModelName + ".TelephoneNumberType") ?? string.Empty);
        }
    }
}