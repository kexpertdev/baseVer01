using AutoMapper;
using DevTrends.WCFDataAnnotations;
using KE.BusinessLayer;
using KE.Entities.DbModels;
using KE.Entities.Emuns;
using KE.Entities.WsMobile;
using KE.Entities.WsModels;
using KExpert.Ws.ExceptionHandler;
using KExpert.Ws.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Security.Principal;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft;
using System.IO;
using System.Drawing;
using System.Web.Hosting;

namespace KExpert.Ws
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    
    [AutomapServiceBehavior]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [ValidateDataAnnotationsBehavior]
    public class Service : IService, IMobileService
    {
        #region Properties
        private readonly IWsService _service;

        public IWsService Wservice
        {
            get
            {
                return _service;
            }
        }
        #endregion

        #region Constructor
        public Service(IWsService service)
        {
            _service = service;
        }
        #endregion


        public string GetServertime()
        {
            return DateTime.Now.ToString();
        }



        #region Brokers WebService
        /// <summary>
        /// Gets the quotation asynchronous.
        /// </summary>
        /// <param name="inputParameters">The input parameters.</param>
        /// <returns></returns>
        /// <exception cref="FaultException{ExceptionFaultContract}">new ExceptionFaultContract(GetQuote, message, description)</exception>
        /// <exception cref="ExceptionFaultContract">GetQuote;message;description</exception>
        public async Task<PolicyQuoteResponse> GetQuotationAsync(PolicyQuoteRequest inputParameters)
        {
            try
            {
                //to do AUTH
                IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
                WebHeaderCollection headers = request.Headers;
                var url = HttpContext.Current.Request.Url.AbsoluteUri;

                Broker broker = new Broker() { ID = 1, Name = "Test"};

                PolicyQuoteResponse result = await Wservice.GetQuoteAsync(inputParameters, broker, url);

                return result;
            }
            catch (Exception ex)
            {
                throw new FaultException<ExceptionFaultContract>(new ExceptionFaultContract("GetQuote", "message", "description"));
            }
        }

        

        /// <summary>
        /// Gets the quote.
        /// </summary>
        /// <param name="inputParameters">The input parameters.</param>
        /// <returns></returns>
        /// <exception cref="System.ServiceModel.FaultException">GetQuote error description</exception>
        //[WebInvoke]        
        public PolicyQuoteResponse GetQuote(PolicyQuoteRequest inputParameters)
        {
            try
            {
                //to do AUTH
                IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
                var context = OperationContext.Current;
                var url = context.IncomingMessageHeaders.To.AbsoluteUri;
                //WebHeaderCollection headers = request.Headers;
                //var url = HttpContext.Current.Request.Url.AbsoluteUri;

                Broker broker = new Broker() { ID = 1, Name = "Test" };

                PolicyQuoteResponse result = Wservice.GetQuote(inputParameters, broker, url);

                return result;

                /*
                PolicyQuote quote = new PolicyQuote()
                {
                    Product_ID = inputParameters.Product,
                    Broker_ID = broker.ID,
                    IsLegalPerson = inputParameters.IsLegalPerson ? LegalEntity.LegalEntity : LegalEntity.NaturalPerson,
                    PolicyNrOfMonthsValid = inputParameters.PolicyNrOfMonthsValid,
                    PolicyPaymentMethod_ID = inputParameters.PolicyPaymentMethod,
                    PolicyStartDate = new DateTimeOffset(inputParameters.PolicyStartingDate, TimeZoneInfo.Local.GetUtcOffset(inputParameters.PolicyStartingDate)),
                    PolicyEndDate = new DateTimeOffset(inputParameters.PolicyStartingDate, TimeZoneInfo.Local.GetUtcOffset(inputParameters.PolicyStartingDate)).AddYears(1).AddDays(-1),
                    //ResultedQuotePremium = 0,
                    PolicyType_ID = inputParameters.PolicyType,
                    PostalCode = inputParameters.PostalCode,
                    VehicleType_ID = inputParameters.VehicleType,
                    VehicleUsage_ID = inputParameters.VehicleUsage
                };

                PolicyQuote savedQuote = service.GetQuote(quote);

                return new PolicyQuoteResponse()
                {
                    QuoteGuid = savedQuote.Guid,
                    CreatedAt = savedQuote.Created.DateTime,
                    Premium = savedQuote.Premium,
                    PolicyStartingDate = savedQuote.PolicyStartDate.DateTime,
                    PolicyEndingDate = savedQuote.PolicyEndDate.DateTime,
                    //received request
                    PolicyQuoteRequest = inputParameters
                };
                */
            }
            catch (Exception ex)
            {
                throw new FaultException("GetQuote error description");
                //throw new FaultException<ExceptionFaultContract>(new ExceptionFaultContract("GetQuote", "message", "description"));
            }
        }


        /// <summary>
        /// Creates the policy.
        /// </summary>
        /// <param name="inputParameters">The input parameters.</param>
        /// <returns></returns>
        /// <exception cref="FaultException{ExceptionFaultContract}">new ExceptionFaultContract(CreatePolicy, not implemented, )</exception>
        /// <exception cref="ExceptionFaultContract">CreatePolicy;not implemented</exception>
        public CreatePolicyResponse CreatePolicy(CreatePolicyRequest inputParameters) 
        {
            try
            {
                //to do AUTH
                IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
                WebHeaderCollection headers = request.Headers;
                //var url = HttpContext.Current.Request.Url.AbsoluteUri;
                Broker broker = new Broker() { ID = 1, Name = "Test" };

                CreatePolicyResponse result = Wservice.CreatePolicy(inputParameters, broker);

                return result;

            }
            catch (Exception ex)
            {
                //throw new FaultException("CreatePolicy error description");
                throw new FaultException<ExceptionFaultContract>(new ExceptionFaultContract("CreatePolicy", "Error during creating the policy", ex.Message), "");
            }
        }
        #endregion



        #region Mobile WebService
        public PolicyDetails GetPolicyDetails(string policyId)
        {
            throw new FaultException<ExceptionFaultContract>(new ExceptionFaultContract("webapi", "GetPolicyDetails", "not implemented "));
        }

        public bool SaveClaimDocuments(string policyId)
        {
            throw new FaultException<ExceptionFaultContract>(new ExceptionFaultContract("webapi", "SaveClaimDocuments", "not implemented "));
        }

        public ImageSetCollection GetImageThumbnails(string policyId)
        {
            throw new FaultException<ExceptionFaultContract>(new ExceptionFaultContract("webapi", "GetImageThumbnails", "not implemented "));
        }

        public KE.Entities.WsMobile.Image GetFullImage(string guid)
        {
            throw new FaultException<ExceptionFaultContract>(new ExceptionFaultContract("webapi", "GetFullImage", "not implemented "));
        }

        public bool UploadImageSets(ImageSetCollection imageSetCollection)
        {
            var imgSets = imageSetCollection.ImageSets;
            return true;
        }

        public string PostBase64(string base64)
        {
            try
            {
                byte[] bytes = Convert.FromBase64String(base64);
                System.Drawing.Image image;
                using (var ms = new MemoryStream(bytes, 0, bytes.Length))
                {
                    ms.Write(bytes, 0, bytes.Length);
                    image = System.Drawing.Image.FromStream(ms, true, true);
                }
                image.Save(HostingEnvironment.MapPath("~/upload/" + "Pic" + ".png"), System.Drawing.Imaging.ImageFormat.Png);

                return "Saved";
            }
            catch(Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public string GetBase64(string guid)
        {
            return Convert.ToBase64String(File.ReadAllBytes(HostingEnvironment.MapPath("~/upload/" + "Pic" + ".png")));
        }
        #endregion

    }
}
