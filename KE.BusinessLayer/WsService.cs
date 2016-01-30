using KE.DataLayer;
using KE.Entities.DbModels;
using KE.Entities.Emuns;
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

        public IDataAccess Repository
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
        public PolicyQuote GetQuote(PolicyQuote quote)
        {
            quote.Premium = GetPremium(quote.Product_ID);
            return Repository.SaveQuote(quote);           
        }

        /// <summary>
        /// Gets the quote asynchronous.
        /// </summary>
        /// <param name="quote">The quote.</param>
        /// <returns></returns>
        public async Task<PolicyQuote> GetQuoteAsync(PolicyQuote quote)
        {
            quote.Premium = GetPremium(quote.Product_ID);
            return await Repository.SaveQuoteAsync(quote);
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
