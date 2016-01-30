using KE.DataLayer;
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
        IDataAccess Repository { get; }

        /// <summary>
        /// Gets the policy base model.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        PolicyBaseViewModel GetPolicyBaseModel(long id);
    }
}
