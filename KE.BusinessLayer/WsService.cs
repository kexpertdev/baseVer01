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
        private readonly IPolicyRepository _policyRepo;
        private readonly IUserRepository _userRepo;

        public IPolicyRepository PolicyRepository
        {
            get
            {
                return _policyRepo;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                return _userRepo;
            }
        }

        public WsService()
        {
            _userRepo = new UserRepository();
            _policyRepo = new PolicyRepository();
        }

        public WsService(IUserRepository userRepo, IPolicyRepository policyRepo) 
        {
            if (userRepo == null || policyRepo == null) throw new ArgumentNullException("IPolicyRepository");
            _userRepo = userRepo;
            _policyRepo = policyRepo;
        }

        public PolicyQuoteResponse GetQuote(PolicyQuoteRequest request, AppUser user)
        {
            //to do, register mapper
            decimal premium = GetPremium(request.Product);
            return PolicyRepository.GetQuote(request, premium);
        }

        
        
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
