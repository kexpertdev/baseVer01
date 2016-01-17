using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KExpertService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service : IService
    {
        public string HelloWorld()
        {
            return "Hello World from KexpertWS";
        }

        public string GetServertime() 
        {
            return DateTime.Now.ToString();
        }

        public async Task<string> GetStringAsync(string message)
        {
            return await Task.Factory.StartNew(() => MyMethod(message));
        }

        private string MyMethod(string message)
        {
            Thread.Sleep(10);
            return message;
        }

        public Person[] GetPeople()
        {
            return new[]
                    {
                        new Person { Age = 45, FirstName = "John", LastName = "Smith" }, 
                        new Person { Age = 42, FirstName = "Jane", LastName = "Smith" }
                    };
        }
        
    }

    [DataContract]
    public class Person
    {
        [DataMember]
        public int Age { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }
    }
}
