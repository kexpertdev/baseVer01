using KE.Entities.DbModels;
using System;
using System.Data.Entity;
namespace KE.DataLayer
{
    public interface IKexpertDb
    {
        DbSet<Address> Address { get; set; }
        DbSet<AppUser> AppUser { get; set; }
        DbSet<AppUserRole> AppUserRole { get; set; }
        DbSet<Broker> Broker { get; set; }
        DbSet<PolicyCancellationReason> CancellationReason { get; set; }
        DbSet<Claim> Claim { get; set; }
        DbSet<Client> Client { get; set; }
        DbSet<ClaimContact> ContactPerson { get; set; }
        DbSet<PolicyInstallment> Installment { get; set; }
        DbSet<LegalPerson> LegalPerson { get; set; }
        DbSet<PolicyModificationReason> ModificationReason { get; set; }
        DbSet<PolicyPaymentType> PaymentType { get; set; }
        DbSet<PolicyPeriod> Period { get; set; }
        DbSet<Person> Person { get; set; }
        DbSet<ClaimPicture> Picture { get; set; }
        DbSet<ClaimPictureType> PictureType { get; set; }
        DbSet<Policy> Policy { get; set; }
        DbSet<Product> Product { get; set; }
        DbSet<PolicyQuote> Quote { get; set; }
        DbSet<PolicyRemark> Remark { get; set; }
        DbSet<PolicyRemarkType> RemarkType { get; set; }
        DbSet<PolicyStatus> Status { get; set; }
        DbSet<Vehicle> Vehicle { get; set; }
    }
}
