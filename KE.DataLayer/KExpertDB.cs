﻿using KE.Entities.DbModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KE.DataLayer
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Data.Entity.DbContext" />
    public class KexpertDb : DbContext, IKexpertDb
    {
        public KexpertDb() : base("name=KExpertContext") { }

        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<AppUserRole> AppUserRole { get; set; }


        public DbSet<Address> Address { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<LegalPerson> LegalPerson { get; set; }
        public DbSet<Client> Client { get; set; }

        public DbSet<Broker> Broker { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<Vehicle> Vehicle { get; set; }

        public DbSet<Policy> Policy { get; set; }
        public DbSet<PolicyPeriod> Period { get; set; }
        public DbSet<PolicyInstallment> Installment { get; set; }
        public DbSet<PolicyQuote> Quote { get; set; }
        public DbSet<InsuranceCompany> InsuranceCompany { get; set; }
        public DbSet<InsurancePolicy> InsurancePolicy { get; set; }

        public DbSet<PolicyStatus> Status { get; set; }
        public DbSet<PolicyPaymentType> PaymentType { get; set; }
        public DbSet<PolicyModificationReason> ModificationReason { get; set; }
        public DbSet<PolicyCancellationReason> CancellationReason { get; set; }
        public DbSet<PolicyRemark> Remark { get; set; }
        public DbSet<PolicyRemarkType> RemarkType { get; set; }

        public DbSet<Claim> Claim { get; set; }
        public DbSet<ClaimContact> ContactPerson { get; set; }
        public DbSet<ClaimPicture> Picture { get; set; }
        public DbSet<ClaimPictureType> PictureType { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<AppUser>()
                .HasOptional(u => u.CreatedBy)  // this could be a problem, see below
                .WithMany()
                .HasForeignKey(u => u.CreatedBy_ID);

            modelBuilder.Entity<AppUser>()
                .HasOptional(u => u.ModifiedBy)
                .WithMany()
                .HasForeignKey(u => u.ModifiedBy_ID);
        }
    }     
}
