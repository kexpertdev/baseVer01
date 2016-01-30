namespace KE.DataLayer.Migrations
{
    using KE.Entities.DbModels;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<KE.DataLayer.KexpertDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(KE.DataLayer.KexpertDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var product = new List<Product>
            {
                new Product { Name = "Kgfb" },
                new Product { Name = "Casco" },
                new Product { Name = "KgfbCasco" }
            };
            product.ForEach(s => context.Product.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();


            var role = new List<AppUserRole>
            {
                new AppUserRole { Name = "Admin" },
            };
            role.ForEach(s => context.AppUserRole.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();


            var user = new List<AppUser>
            {
                new AppUser { 
                    Fullname = "Admin", 
                    Username = "admin", 
                    Password = "password",
                    IsActive = true,
                    Email = "a@a.com",
                    Role = role.FirstOrDefault(),
                    CreatedBy = null,
                    Created = DateTime.Now
                },
            };
            user.ForEach(s => context.AppUser.AddOrUpdate(p => p.Username, s));
            context.SaveChanges();


            var address = new List<Address>
            {
                new Address { PostalCode = "1131",   City = "Budapest", StreetName = "Mosoly", StreetNumber = "19 4/2" },
                new Address { PostalCode = "1132", City = "Budapest", StreetName = "Mosoly", StreetNumber = "19 4/2" },
            };
            address.ForEach(s => context.Address.AddOrUpdate(p => p.ID, s));
            context.SaveChanges();


            var broker = new List<Broker>
            {
                new Broker { 
                    Name = "Test Broker",
                    Username = "testuser",
                    Password = "password",
                    TaxNumber = "12345678-1-123",
                    BankAccountNumber = "12700000-00000000-00000000",
                    Email = "a@a.com",
                    IsActive = true,
                    Address = address.FirstOrDefault(),
                    MailingAddress = address.FirstOrDefault(),
                    CreatedBy = user.FirstOrDefault(),
                    Created = DateTime.Now}
            };
            broker.ForEach(s => context.Broker.AddOrUpdate(p => p.TaxNumber, s));
            context.SaveChanges(); 


            var status = new List<PolicyStatus>
            {
                new PolicyStatus { Name = "Offer" },
                new PolicyStatus { Name = "Policy" },
                new PolicyStatus { Name = "Cancelled" }
            };
            status.ForEach(s => context.Status.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();


            var cancelReasons = new List<PolicyCancellationReason>
            {
                new PolicyCancellationReason { Name = "OtherReason" },
                new PolicyCancellationReason { Name = "AnniversaryNoticeToQuite" },
                new PolicyCancellationReason { Name = "AnniversaryQuitingByTheInsurer" },
                new PolicyCancellationReason { Name = "CommonAgrement" },
                new PolicyCancellationReason { Name = "LossOfInsuredInterest" },
                new PolicyCancellationReason { Name = "NonPayment" }
            };
            cancelReasons.ForEach(s => context.CancellationReason.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();


            var modifReasons = new List<PolicyModificationReason>
            {
                new PolicyModificationReason { Name = "OtherReason" },
                new PolicyModificationReason { Name = "PolicyData" },
                new PolicyModificationReason { Name = "ClientData" },
                new PolicyModificationReason { Name = "VehicleData" },
                new PolicyModificationReason { Name = "ClaimData" }
            };
            modifReasons.ForEach(s => context.ModificationReason.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();
        }

    }
}
