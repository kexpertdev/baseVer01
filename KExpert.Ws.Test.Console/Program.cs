using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
using KExpert.Ws.Test.Console.ServiceReference;

namespace KExpert.Ws.Test.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var binding = new BasicHttpBinding(BasicHttpSecurityMode.TransportWithMessageCredential);
            var endpointAddress = new EndpointAddress(@"https://localhost/KExpert.Ws/Service.svc");

            using (var service = new ServiceClient(binding, endpointAddress))
            {
               

                var defaultCredentials = service.Endpoint.Behaviors.Find<ClientCredentials>();
                var loginCredentials = defaultCredentials;   //new ClientCredentials();
                loginCredentials.UserName.UserName = @"fayaz";
                loginCredentials.UserName.Password = @"soomro";
                
                service.Endpoint.Behaviors.Remove(defaultCredentials); //remove default ones
                service.Endpoint.Behaviors.Add(loginCredentials); //add required ones

                var data = service.GetServertime();
                System.Console.WriteLine(data);
                System.Console.ReadKey();
            }
        }
    }
}
