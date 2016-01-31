[assembly: WebActivator.PostApplicationStartMethod(typeof(KExpert.Ws.App_Start.PostApplicationStartMethod), "Initialize")]

namespace KExpert.Ws.App_Start
{
    using System.Reflection;

    using SimpleInjector;
    using SimpleInjector.Integration.Wcf;
    using KE.BusinessLayer;
    using KE.DataLayer;

    public static class PostApplicationStartMethod
    {
        /// <summary>Initialize the container and register it for the WCF ServiceHostFactory.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WcfOperationLifestyle();

            InitializeContainer(container);

            container.RegisterWcfServices(Assembly.GetExecutingAssembly());

            //container.Verify();
            
            SimpleInjectorServiceHostFactory.SetContainer(container);

            // TODO: Add the following attribute to all .svc files:
            // Factory="SimpleInjector.Integration.Wcf.SimpleInjectorServiceHostFactory, SimpleInjector.Integration.Wcf"
        }

        private static void InitializeContainer(Container container)
        {
            // Configure the container (register)
            container.Register<IWsService, WsService>();
            container.Register<IDataAccess, DataAccess>();
            container.Register<IKexpertDb, KexpertDb>();

            // Optionally verify the container's configuration.
            //container.Verify();
        }
    }
}