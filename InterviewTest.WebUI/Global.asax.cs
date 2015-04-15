using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using InterviewTest.Domain.Model.PhoneBook;
using InterviewTest.WebUI.Infrastructure.Binders;

namespace InterviewTest.WebUI
{
    public class MvcApplication : HttpApplication
    {
        public const string PhoneBookFileName = "PhoneBook.xml";
        public const string ContactIdSequenceFileName = "ContactIdSequence.xml";

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            RegisterBinders();
            RegisterControllerFactory();
        }

        private void RegisterControllerFactory()
        {
            IControllerFactory factory = new MyOwnControllerFactory();
            ControllerBuilder.Current.SetControllerFactory(factory);
        }

        private void RegisterBinders()
        {
            ModelBinders.Binders.DefaultBinder = new MyOwnModelBinder();
            ModelBinders.Binders.Add(typeof(ContactId), new ContactIdBinder());
            ModelBinders.Binders.Add(typeof(ContactTelephone), new ContactTelephoneBinder());
        }
    }
}
