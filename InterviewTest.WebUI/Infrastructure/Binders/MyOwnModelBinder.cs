using System.ComponentModel;
using System.Web.Mvc;

namespace InterviewTest.WebUI.Infrastructure.Binders
{
    public class MyOwnModelBinder : DefaultModelBinder
    {
        protected override void SetProperty(ControllerContext controllerContext, ModelBindingContext bindingContext,
            PropertyDescriptor propertyDescriptor, object value)
        {
            if (value == null)
                return;

            base.SetProperty(controllerContext, bindingContext, propertyDescriptor, value);
        }
    }
}