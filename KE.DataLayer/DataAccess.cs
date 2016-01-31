using KE.Entities.DbModels;
using KE.Entities.Emuns;
using KE.Entities.WsModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KE.DataLayer
{
    public class DataAccess : IDataAccess
    {
        //private bool _disposed = false;

        #region Context
        internal readonly IKexpertDb _context;

        public KexpertDb Context
        {
            get
            {
                //if (_context == null)
                //{
                //    _context = new KExpertDB();
                //}
                return (KexpertDb)_context;
            }
        }
        #endregion

        #region Repositories
        private IGenericRepository<Policy> _policyRepo;
        public IGenericRepository<Policy> PolicyRepo 
        {
            get 
            {
                if(_policyRepo == null)
                {
                    _policyRepo = new GenericRepository<Policy>((KexpertDb)_context);
                }
                return _policyRepo;
            }
        }

        private IGenericRepository<PolicyPeriod> _policyPeriodRepo;
        public IGenericRepository<PolicyPeriod> PolicyPeriodRepo 
        {
            get
            {
                if (_policyPeriodRepo == null)
                {
                    _policyPeriodRepo = new GenericRepository<PolicyPeriod>((KexpertDb)_context);
                }
                return _policyPeriodRepo;
            }
        }

        private IGenericRepository<PolicyQuote> _quoteRepo;
        public IGenericRepository<PolicyQuote> QuoteRepo
        {
            get
            {
                if (_quoteRepo == null)
                {
                    _quoteRepo = new GenericRepository<PolicyQuote>((KexpertDb)_context);
                }
                return _quoteRepo;
            }
        }
        #endregion

        #region Constructors
        public DataAccess(IKexpertDb context)
        {
            _context = context;
        }
        #endregion


        #region Methods
        public IEnumerable<Policy> GetAllPolicy()
        {
            return PolicyRepo.GetAll();
            //return Context.Policy.ToList();
        }


        public PolicyQuote SaveQuote(PolicyQuote quote)
        {
            PolicyQuote savedQuote = Context.Quote.Add(quote);
            SaveChanges();

            return savedQuote;
        }

        public async Task<PolicyQuote> SaveQuoteAsync(PolicyQuote quote)
        {
            //PolicyQuote savedQuote = Context.Quote.Add(quote);
            PolicyQuote savedQuote = QuoteRepo.Insert(quote);
            await Context.SaveChangesAsync();

            return savedQuote;
        }

        public Policy SavePolicy(Guid guid, Client client, Vehicle vehicle, Broker broker)
        {
            PolicyQuote quote = QuoteRepo.GetByID(guid);
            if (quote == null)
                throw new Exception("The supplied guid not exists");
            if(quote.Period.Count > 0)
                throw new Exception("The quote already is transferred to policy");

            //check if exists policy with quote
            //check if the quid belong to the brokee or not
            //check againts quote starting date, and modify if we need!!!

            string policyNumber = GetNextPolicyNumber(quote.Product_ID);
            client.ClientCode = policyNumber;

            Policy policy = new Policy()
            {
                PolicyNumber = policyNumber,
                PolicyStartDate = quote.PolicyStartDate,
                PolicyEndDate = quote.PolicyEndDate,
                IsFixedTerm = quote.PolicyType_ID == PolicyTypes.FixedTerm ? true : false,
                Product_ID = Convert.ToInt32(quote.Product_ID),
                Status_ID = Convert.ToInt32(PolicyStatuses.Policy),
                Broker_ID = quote.Broker_ID,
                CreatedBy_ID = 1, //sysadmin, to do
                Client = client,
                Vehicle = vehicle,
                PolicyPeriods = new List<PolicyPeriod>()
                {
                    new PolicyPeriod()
                    {
                        PeriodStartDate = quote.PolicyStartDate,
                        PeriodEndDate = quote.PolicyEndDate,
                        Premium = quote.Premium,
                        IsLastPeriod = true,
                        PeriodNumber = 1,
                        PaymentType_ID = Convert.ToInt32(quote.PolicyPaymentMethod_ID),
                        PreviousPolicyPeriod_ID = null,
                        Quote = quote,
                        Installment = new List<PolicyInstallment>()
                        {
                            new PolicyInstallment()
                            {
                                Nr = 1,
                                Type = 1,
                                DueDate = quote.PolicyStartDate,
                                Value = quote.Premium
                            }
                        },
                        InsurancePolicies = new List<InsurancePolicy>()
                        {
                            new InsurancePolicy()
                            {
                                Company = Convert.ToInt32(quote.InsuranceCompany),
                                PolicyNumber = quote.InsurancePolicyNumber,
                                StartDate = quote.InsuranceStartDate,
                                EndDate = quote.InsuranceEndDate
                            }
                        }
                    }
                }
            };

            Policy savedPolicy = PolicyRepo.Insert(policy);
            SaveChanges();

            return savedPolicy;
        }
        #endregion


        #region Call StoredProcedure
        public string GetNextPolicyNumber(Products productID)
        {
            try
            {
                long nextSeq = CallStoredProcedure<long>("GetNextPolicyNumberSequenceValue").FirstOrDefault();
                int prodCode = Convert.ToInt32(productID); //Enum.Parse(typeof(Products), productID.ToString());
                return "KE" + prodCode.ToString() + nextSeq.ToString("D7");
            }
            catch
            {
                throw new Exception("Error during generating the policy number");
            }
        }

        public IEnumerable<T> CallStoredProcedure<T>(string name)
        {
            IEnumerable<T> result;
            result = Context.Database
                .SqlQuery<T>(name)
                .ToList();
            
            return result;
        }

        public IEnumerable<T> CallStoredProcedure<T>(string name, SqlParameterCollection parameters)
        {
            IEnumerable<T> result;   
            //var clientIdParameter = new SqlParameter("@ClientId", 4);
            result = Context.Database
                .SqlQuery<T>(name)
                .ToList();
            return result;
        }
        #endregion


        #region SaveChanges
        public int SaveChanges()
        {
            return Context.SaveChanges();
        }
        #endregion

        //#region Dispose
        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}

        //protected virtual void Dispose(bool disposing)
        //{
        //    if (!_disposed)
        //    {
        //        if (disposing)
        //        {
        //            // Dispose any managed objects
        //            Context.Dispose();
        //        }
        //        // Now disposed of any unmanaged objects
        //        _disposed = true;
        //    }
        //}
        //#endregion
    }
}
