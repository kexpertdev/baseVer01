using KE.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Integration.Web;
using KE.DataLayer;

namespace KExpert.App_Start
{
    public static class SimpleInjectorConfig
    {
        public static void RegisterDependencies() 
        {
            // Create a new Simple Injector container
            var container = new SimpleInjector.Container();

            // Set the scoped lifestyle one directly after creating the container
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            // Configure the container (register)
            container.Register<IPolicyService, PolicyService>(Lifestyle.Scoped);
            container.Register<IPolicyRepository, PolicyRepository>(Lifestyle.Scoped);

            // Optionally verify the container's configuration.
            container.Verify();

            // Store the container for use by the application
            DependencyResolver.SetResolver(
                new SimpleInjectorDependencyResolver(container));
        }
    }
}