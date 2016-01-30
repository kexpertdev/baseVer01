using AutoMapper;
using DevTrends.WCFDataAnnotations;
using KE.BusinessLayer;
using KE.Entities.DbModels;
using KE.Entities.Emuns;
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

namespace KExpert.Ws
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    
    [AutomapServiceBehavior]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [ValidateDataAnnotationsBehavior]
    public class Service : IService
    {
        #region Properties
        private readonly IWsService _service;

        public IWsService WS
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
                IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
                WebHeaderCollection headers = request.Headers;
                var url = HttpContext.Current.Request.Url.AbsoluteUri;

                //service = new WsService();

                //to do AUTH
                //IIdentity primaryIdentity = ServiceSecurityContext.Current.PrimaryIdentity;
                Broker broker = new Broker() { ID = 1, Name = "Test"};

                PolicyQuote quote = Mapper.Map<PolicyQuote>(inputParameters);
                quote.Broker_ID = broker.ID;
                quote.RequestUrl = url;

                PolicyQuote savedQuote = await WS.GetQuoteAsync(quote);

                PolicyQuoteResponse result = AutoMapper.Mapper.Map<PolicyQuoteResponse>(savedQuote);
                result.PolicyQuoteRequest = inputParameters;

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
                //IIdentity primaryIdentity = ServiceSecurityContext.Current.PrimaryIdentity;
                Broker broker = new Broker() { ID = 1, Name = "Test" };

                PolicyQuote quote = AutoMapper.Mapper.Map<PolicyQuote>(inputParameters);
                quote.Broker_ID = broker.ID;

                PolicyQuote savedQuote = WS.GetQuote(quote);

                PolicyQuoteResponse result = AutoMapper.Mapper.Map<PolicyQuoteResponse>(savedQuote);
                result.PolicyQuoteRequest = inputParameters;

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
            throw new FaultException<ExceptionFaultContract>(new ExceptionFaultContract("CreatePolicy", "Not implemented", "CreatePolicy not implemented "));
        }
        #endregion
    }
}
