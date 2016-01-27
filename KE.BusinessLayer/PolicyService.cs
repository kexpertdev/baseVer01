﻿using KE.DataLayer;
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
        private readonly IPolicyRepository _repo;

        public IPolicyRepository Repository
        {
            get
            {
                return _repo;
            }
        }

        public PolicyService(IPolicyRepository repository) 
        {
            if (repository == null) throw new ArgumentNullException("IPolicyRepository");
            _repo = repository;
        }


        public PolicyBaseViewModel GetPolicyBaseModel(long id)
        {
            var policy = AutoMapper.Mapper.Map<PolicyDTO>(Repository.PolicyRepo.GetByID(id));
            var policyPeriod =  policy == null ? null : AutoMapper.Mapper.Map<PolicyPeriodDTO>(Repository.PolicyPeriodRepo.GetByID(policy.LastPolicyPeriodID));

            return new PolicyBaseViewModel()
            {
                Policy = policy,
                PolicyPeriod = policyPeriod
            };
        }
    }
}