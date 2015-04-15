using System;
using System.Web.Mvc;
using System.Web.Routing;
using InterviewTest.Persistance;
using InterviewTest.Persistance.DataModel;
using InterviewTest.Persistance.DataModel.Convertes;
using InterviewTest.Persistance.Sequences;
using InterviewTest.Persistance.Serializers;
using InterviewTest.WebUI.Controllers;

namespace InterviewTest.WebUI
{
    public class MyOwnControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == typeof(PhoneBookController))
                return new PhoneBookController(new XmlContactRepository(
                    new EntitySerializerUsingXmlSerializer<InMemoryPhoneBook, PhoneBookDto>(
                        MvcApplication.PhoneBookFileName,
                        PhoneBookConverter.Instance),
                    new IncrementalContactIdSequence(
                        new EntitySerializerUsingXmlSerializer<ContactIdSequence, ContactIdSequenceDto>(
                            MvcApplication.ContactIdSequenceFileName,
                            ContactIdSequenceConverter.Instance))));

            return base.GetControllerInstance(requestContext, controllerType);
        }
    }
}