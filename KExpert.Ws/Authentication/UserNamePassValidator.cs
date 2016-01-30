using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace KExpert.Ws.Authentication
{
    internal class UserNamePassValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            //if (userName == null || password == null)
            //    throw new ArgumentNullException();
            //if (!(userName == "fayaz") || !(password == "soomro"))
            //    throw new FaultException("Incorrect Username or Password");
        }
    }
}