using AutoMapper;
using KE.DataLayer;
using KE.Entities.DbModels;
using KE.Entities.Emuns;
using KE.Entities.Models;
using KE.Entities.WsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KE.BusinessLayer
{
    public class WsService : IWsService
    {
        #region Properties
        private readonly IDataAccess _dataAccess;

        public IDataAccess DataAccess
        {
            get
            {
                return _dataAccess;
            }
        }
        #endregion


        #region Constructors
        public WsService(IDataAccess dataAccess) 
        {
            if (dataAccess == null) throw new ArgumentNullException("IDataAccess");
            _dataAccess = dataAccess;
        }
        #endregion


        #region WebService Methods        
        /// <summary>
        /// Gets the quote.
        /// </summary>
        /// <param name="quote">The quote.</param>
        /// <returns></returns>
        public PolicyQuoteResponse GetQuote(PolicyQuoteRequest inputParameters, Broker broker, string url)
        {
            PolicyQuote quote = Mapper.Map<PolicyQuote>(inputParameters);
            quote.Broker_ID = broker.ID;
            quote.RequestUrl = url;
            quote.Premium = GetPremium(quote.Product_ID);


            PolicyQuote savedQuote = DataAccess.SaveQuote(quote);

            PolicyQuoteResponse result = Mapper.Map<PolicyQuoteResponse>(savedQuote);
            result.PolicyQuoteRequest = inputParameters;

            return result;       
        }

        /// <summary>
        /// Gets the quote asynchronous.
        /// </summary>
        /// <param name="quote">The quote.</param>
        /// <returns></returns>
        public async Task<PolicyQuoteResponse> GetQuoteAsync(PolicyQuoteRequest inputParameters, Broker broker, string url)
        {
            PolicyQuote quote = Mapper.Map<PolicyQuote>(inputParameters);
            quote.Broker_ID = broker.ID;
            quote.RequestUrl = url;
            quote.Premium = GetPremium(quote.Product_ID);

            PolicyQuote savedQuote = await DataAccess.SaveQuoteAsync(quote);;

            PolicyQuoteResponse result = Mapper.Map<PolicyQuoteResponse>(savedQuote);
            result.PolicyQuoteRequest = inputParameters;

            return result; 
        }

        public CreatePolicyResponse CreatePolicy(CreatePolicyRequest inputParameters, Broker broker)
        {
            Client client = Mapper.Map<Client>(inputParameters.RegisteredKeeper);
            if (inputParameters.RegisteredKeeper.IsLegalPerson)
            {
                client.LegalPerson = Mapper.Map<LegalPerson>(inputParameters.RegisteredKeeper);
                client.LegalPerson.Address = Mapper.Map<AddressDto>(inputParameters.RegisteredKeeper);
                client.LegalPerson.MailingAddress = Mapper.Map<MailingAddressDto>(inputParameters.RegisteredKeeper);
            }
            else
            {
                client.Person = Mapper.Map<Person>(inputParameters.RegisteredKeeper);
                client.Person.Address = Mapper.Map<AddressDto>(inputParameters.RegisteredKeeper);
                client.Person.MailingAddress = Mapper.Map<MailingAddressDto>(inputParameters.RegisteredKeeper);
            }           
            Vehicle vehicle = Mapper.Map<Vehicle>(inputParameters.Vehicle);


            Policy savedPolicy = DataAccess.SavePolicy(inputParameters.QuoteGuid, client, vehicle, broker);


            CreatePolicyResponse result = new CreatePolicyResponse()
            {
                PolicyNumber = savedPolicy.PolicyNumber
            };
            return result;
        }
        #endregion


        #region CalculatePremium
        private decimal GetPremium(Products product)
        {
            if (product == Products.KgfbCasco)
                return 5000;
            return 3000;
        }
        #endregion
    }
}
