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
        IDataAccess _dataAccess;

        public IDataAccess DataAccess
        {
            get
            {
                return _dataAccess;
            }
        }
        #endregion

        #region Constructor
        public PolicyService(IDataAccess dataAccess) 
        {
            if (dataAccess == null) throw new ArgumentNullException("IDataAccess");
            _dataAccess = dataAccess;
        }
        #endregion

        #region Methods        
        public PolicyBaseViewModel GetPolicyBaseModel(string policyNumber)
        {
            var policy = Mapper.Map<PolicyDto>(DataAccess.GetPolicyByPolicyNumber(policyNumber));
            //var policyPeriod = policy == null ? null : Mapper.Map<PolicyPeriodDto>(DataAccess.PolicyPeriodRepo.GetByID(policy.LastPolicyPeriod_ID));
            //var vehicle = Mapper.Map<VehicleDto>(DataAccess.VehicleRepo.GetByID(policy.Vehicle_ID));

            return new PolicyBaseViewModel()
            {
                Policy = policy,
                PolicyPeriod = policy == null ? null : Mapper.Map<PolicyPeriodDto>(DataAccess.PolicyPeriodRepo.GetByID(policy.LastPolicyPeriod_ID)),
                //Client = Mapper.Map<ClientDto>(DataAccess.ClientRepo.GetByID(policy.Client_ID)),
                Vehicle = policy == null ? null : Mapper.Map<VehicleDto>(DataAccess.VehicleRepo.GetByID(policy.Vehicle_ID))
            };
        }

        public List<QuoteDto> GetQuotes()
        {
            return Mapper.Map<List<PolicyQuote>, List<QuoteDto>>(DataAccess.QuoteRepo.GetAll().ToList());
        }
        #endregion
    }
}
