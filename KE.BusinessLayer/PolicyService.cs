using AutoMapper;
using KE.DataLayer;
using KE.Entities.DbModels;
using KE.Entities.Models;
using KE.Entities.WebViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KE.BusinessLayer
{
    public class PolicyService : IPolicyService
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

        public PolicyService(IDataAccess dataAccess) 
        {
            if (dataAccess == null) throw new ArgumentNullException("IDataAccess");
            _dataAccess = dataAccess;
        }
        #endregion

        #region Methods        
        public PolicyBaseViewModel GetPolicyBaseModel(long id)
        {
            var policy = AutoMapper.Mapper.Map<PolicyDto>(DataAccess.PolicyRepo.GetByID(id));
            var policyPeriod = policy == null ? null : AutoMapper.Mapper.Map<PolicyPeriodDto>(DataAccess.PolicyPeriodRepo.GetByID(policy.LastPolicyPeriodID));

            return new PolicyBaseViewModel()
            {
                Policy = policy,
                PolicyPeriod = policyPeriod
            };
        }

        public List<QuoteDto> GetQuotes()
        {
            return Mapper.Map<List<PolicyQuote>, List<QuoteDto>>(DataAccess.QuoteRepo.GetAll().ToList());
        }
        #endregion
    }
}
