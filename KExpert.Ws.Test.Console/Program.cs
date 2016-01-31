using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
//using KExpert.Ws.Test.Console.ServiceReference;
using KExpert.Ws.Test.Console.ServiceReferenceIISExp;
using System.Net;
using System.IO;
using System.ServiceModel.Web;

namespace KExpert.Ws.Test.Console
{
    class Program
    {
        public static void TestSoap()
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

        public static void TestRest()
        {
            string baseAddress = "http://localhost:51050/Service.svc/webapi/";
            WebServiceHost host = new WebServiceHost(typeof(ServiceClient), new Uri(baseAddress));
            host.AddServiceEndpoint(typeof(IService), new WebHttpBinding(), "").Behaviors.Add(new WebHttpBehavior());
            host.Open();
            System.Console.WriteLine("Host opened");

            byte[] image = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 }; // some image array
            string imageBase64 = Convert.ToBase64String(image);
            string jsonInput = "\"" + imageBase64 + "\"";
            byte[] jsonInputBytes = Encoding.UTF8.GetBytes(jsonInput);

            SendRequest(baseAddress + "PostViaBase64", "application/json", jsonInputBytes);
            //SendRequest(baseAddress + "/PostViaBinary", "image/jpeg", image);
            //SendRequest(baseAddress + "/PostViaByteArray", "application/json", GetJsonArray(image));

            System.Console.Write("Press ENTER to close the host");
            System.Console.ReadLine();
            host.Close();
        }

        static void Main(string[] args)
        {

            TestRest();


        }






        static void SendRequest(string uri, string contentType, byte[] body)
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(uri);
            req.Method = "POST";
            req.ContentType = contentType;
            req.GetRequestStream().Write(body, 0, body.Length);
            req.GetRequestStream().Close();

            HttpWebResponse resp;
            try
            {
                resp = (HttpWebResponse)req.GetResponse();
            }
            catch (WebException e)
            {
                resp = (HttpWebResponse)e.Response;
            }
            System.Console.WriteLine("HTTP/{0} {1} {2}", resp.ProtocolVersion, (int)resp.StatusCode, resp.StatusDescription);
            foreach (string headerName in resp.Headers.AllKeys)
            {
                System.Console.WriteLine("{0}: {1}", headerName, resp.Headers[headerName]);
            }
            System.Console.WriteLine();
            Stream respStream = resp.GetResponseStream();
            if (respStream != null)
            {
                string responseBody = new StreamReader(respStream).ReadToEnd();
                System.Console.WriteLine(responseBody);
            }
            else
            {
                System.Console.WriteLine("HttpWebResponse.GetResponseStream returned null");
            }
            System.Console.WriteLine();
            System.Console.WriteLine(" *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-* ");
            System.Console.WriteLine();
        }
        static byte[] GetJsonArray(byte[] data)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('[');
            for (int i = 0; i < data.Length; i++)
            {
                if (i > 0) sb.Append(',');
                sb.Append((int)data[i]);
            }
            sb.Append(']');
            return Encoding.UTF8.GetBytes(sb.ToString());
        }
    }
}
