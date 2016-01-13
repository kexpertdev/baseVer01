using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class KExpertContext : DbContext
    {
        public KExpertContext() : base("name=KExpertContext") { }


        public DbSet<Product> Product { get; set; }

        public DbSet<Vehicle> Vehicle { get; set; }

        public DbSet<Address> Address { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<LegalPerson> LegalPerson { get; set; }
        public DbSet<Client> Client { get; set; }

        public DbSet<Broker> Broker { get; set; }
        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<AppUserRole> AppUserRole { get; set; }

        public DbSet<PaymentType> PaymentType { get; set; }
        public DbSet<ModificationReason> ModificationReason { get; set; }
        public DbSet<PolicyStatus> PolicyStatus { get; set; }
        public DbSet<PolicyCancellationReason> PolicyCancellationReason { get; set; }

        public DbSet<PolicyQuote> PolicyQuote { get; set; }
        public DbSet<PolicyRemarkLog> PolicyRemarkLog { get; set; }
        public DbSet<PolicyInstallment> PolicyInstallment { get; set; }
        public DbSet<PolicyPeriod> PolicyPeriod { get; set; }
        public DbSet<Policy> Policy { get; set; }

        public DbSet<Claim> Claim { get; set; }
        public DbSet<ClaimRemarkLog> ClaimRemarkLog { get; set; }
        public DbSet<Attachment> Attachment { get; set; }
        public DbSet<AttachmentType> AttachmentType { get; set; }
        public DbSet<RemarkType> RemarkType { get; set; }
    }
}
