using KE.Entities.DbModels;
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


        /// <summary>
        /// Gets all policy.
        /// </summary>
        /// <returns>IEnumerable<Policy></returns>
        IEnumerable<Policy> GetAllPolicy();

        /// <summary>
        /// Gets the next policy number sequence value.
        /// </summary>
        /// <returns></returns>
        long GetNextPolicyNumberSequenceValue();

        PolicyQuote SaveQuote(PolicyQuote quote);
        Task<PolicyQuote> SaveQuoteAsync(PolicyQuote quote);

    }
}
