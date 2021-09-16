using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Linq;

namespace Quartz
{
    public class QuartzRoutePrefixConvention : IApplicationModelConvention
    {
        private readonly AttributeRouteModel _prefix;

        public QuartzRoutePrefixConvention(string prefix = "quartz-api")
        {
            _prefix = new AttributeRouteModel(new RouteAttribute(prefix));
        }

        public void Apply(ApplicationModel application)
        {
            foreach (var controller in application.Controllers)
            {
                if (controller.ControllerType?.Namespace?.StartsWith("Quartz.AspNetCore.HttpApi.Controllers") == true)
                {
                    AddPrefixesToExistingRoutes(controller);
                }
            }
        }

        private void AddPrefixesToExistingRoutes(ControllerModel controller)
        {
            foreach (var selectorModel in controller.Selectors.Where(x => x.AttributeRouteModel != null).ToList())
            {
                // Merge existing route models with the api prefix
                var originalAttributeRoute = selectorModel.AttributeRouteModel;
                selectorModel.AttributeRouteModel = AttributeRouteModel.CombineAttributeRouteModel(_prefix, originalAttributeRoute);
            }
        }
    }
}
