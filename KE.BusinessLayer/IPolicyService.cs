using KE.DataLayer;
using KE.Entities.Models;
using KE.Entities.WebViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KE.BusinessLayer
{
    public interface IPolicyService : IService
    {
        IDataAccess DataAccess { get; }

        /// <summary>
        /// Gets the policy base model.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        PolicyBaseViewModel GetPolicyBaseModel(string id);

        /// <summary>
        /// Gets the quotes.
        /// </summary>
        /// <returns></returns>
        List<QuoteDto> GetQuotes();
    }
}
