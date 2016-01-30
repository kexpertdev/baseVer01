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
        #endregion

        #region Constructors
        public DataAccess(IKexpertDb context)
        {
            _context = context;
        }
        #endregion


        #region Methods
        /// <summary>
        /// Gets all policy.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Policy> GetAllPolicy()
        {
            return PolicyRepo.GetAll();
            //return Context.Policy.ToList();
        }

        /// <summary>
        /// Gets the next policy number sequence value.
        /// </summary>
        /// <returns></returns>
        public long GetNextPolicyNumberSequenceValue()
        {
            return CallStoredProcedure<long>("GetNextPolicyNumberSequenceValue").FirstOrDefault();
        }


        /// <summary>
        /// Saves the quote.
        /// </summary>
        /// <param name="quote">The quote.</param>
        /// <returns></returns>
        public PolicyQuote SaveQuote(PolicyQuote quote)
        {
            PolicyQuote savedQuote = Context.Quote.Add(quote);
            Context.SaveChanges();

            return savedQuote;
        }

        /// <summary>
        /// Saves the quote asynchronous.
        /// </summary>
        /// <param name="quote">The quote.</param>
        /// <returns></returns>
        public async Task<PolicyQuote> SaveQuoteAsync(PolicyQuote quote)
        {
            PolicyQuote savedQuote = Context.Quote.Add(quote);
            await Context.SaveChangesAsync();

            return savedQuote;
        }
        #endregion


        #region Call StoredProcedure
        public IEnumerable<T> CallStoredProcedure<T>(string name)
        {
            IEnumerable<T> result;
            using (Context)
            {
                result = Context.Database
                    .SqlQuery<T>(name)
                    .ToList();
            }
            return result;
        }

        public IEnumerable<T> CallStoredProcedure<T>(string name, SqlParameterCollection parameters)
        {
            IEnumerable<T> result;
            using (Context)
            {
                //var clientIdParameter = new SqlParameter("@ClientId", 4);
                result = Context.Database
                    .SqlQuery<T>(name)
                    .ToList();
            }
            return result;
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
