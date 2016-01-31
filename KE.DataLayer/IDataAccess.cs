using KE.Entities.DbModels;
using KE.Entities.Emuns;
using KE.Entities.WsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KE.DataLayer
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDataAccess
    {
        IGenericRepository<Policy> PolicyRepo { get; }
        IGenericRepository<PolicyPeriod> PolicyPeriodRepo { get; }
        IGenericRepository<PolicyQuote> QuoteRepo { get; }

        int SaveChanges();

        /// <summary>
        /// Gets all policy.
        /// </summary>
        /// <returns>IEnumerable<Policy></returns>
        IEnumerable<Policy> GetAllPolicy();

        /// <summary>
        /// Saves the quote.
        /// </summary>
        /// <param name="quote">The quote.</param>
        /// <returns></returns>
        PolicyQuote SaveQuote(PolicyQuote quote);

        /// <summary>
        /// Saves the quote asynchronous.
        /// </summary>
        /// <param name="quote">The quote.</param>
        /// <returns></returns>
        Task<PolicyQuote> SaveQuoteAsync(PolicyQuote quote);

        /// <summary>
        /// Saves the policy.
        /// </summary>
        /// <param name="guid">The unique identifier.</param>
        /// <param name="client">The client.</param>
        /// <param name="vehicle">The vehicle.</param>
        /// <returns></returns>
        Policy SavePolicy(Guid guid, Client client, Vehicle vehicle, Broker broker);

        /// <summary>
        /// Gets the next policy number.
        /// </summary>
        /// <param name="productID">The product identifier.</param>
        /// <returns></returns>
        string GetNextPolicyNumber(Products productID);
    }
}
