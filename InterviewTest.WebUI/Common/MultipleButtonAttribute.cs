using System;
using System.Reflection;
using System.Web.Mvc;

namespace InterviewTest.WebUI.Common
{
    [AttributeUsage(AttributeTargets.Method)]
    public class MultipleButtonAttribute : ActionNameSelectorAttribute
    {
        public const string ButtonNameFormat = "{0}:{1}";

        public string Name { get; set; }
        public string Argument { get; set; }

        public override bool IsValidName(ControllerContext controllerContext, string actionName, MethodInfo methodInfo)
        {
            var key = string.Format(ButtonNameFormat, Name, Argument);
            var value = controllerContext.Controller.ValueProvider.GetValue(key);

            if (value == null)
                return false;

            controllerContext.Controller.ControllerContext.RouteData.Values[Name] = Argument;
            return true;
        }
    }
}