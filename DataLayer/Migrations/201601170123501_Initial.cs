namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PostalCode = c.String(nullable: false, maxLength: 4),
                        City = c.String(nullable: false, maxLength: 100),
                        StreetName = c.String(nullable: false, maxLength: 100),
                        StreetNumber = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AppUser",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Fullname = c.String(nullable: false, maxLength: 100),
                        Username = c.String(nullable: false, maxLength: 25),
                        Password = c.String(nullable: false, maxLength: 25),
                        IsActive = c.Boolean(nullable: false),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedDate = c.DateTimeOffset(precision: 7),
                        ModifiedReason = c.String(),
                        Role_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AppUserRole", t => t.Role_ID)
                .Index(t => t.Role_ID);
            
            CreateTable(
                "dbo.AppUserRole",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 255),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Broker",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 25),
                        TaxNumber = c.String(nullable: false),
                        BankAccountNumber = c.String(nullable: false),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedDate = c.DateTimeOffset(precision: 7),
                        ModifiedReason = c.String(),
                        Address_ID = c.Int(),
                        CreatedBy_ID = c.Int(),
                        MailingAddress_ID = c.Int(),
                        ModifiedBy_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Address", t => t.Address_ID)
                .ForeignKey("dbo.AppUser", t => t.CreatedBy_ID)
                .ForeignKey("dbo.Address", t => t.MailingAddress_ID)
                .ForeignKey("dbo.AppUser", t => t.ModifiedBy_ID)
                .Index(t => t.Address_ID)
                .Index(t => t.CreatedBy_ID)
                .Index(t => t.MailingAddress_ID)
                .Index(t => t.ModifiedBy_ID);
            
            CreateTable(
                "dbo.PolicyCancellationReason",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Claim",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ClaimNumber = c.String(nullable: false, maxLength: 10),
                        NotificationDate = c.DateTimeOffset(nullable: false, precision: 7),
                        AccidentDate = c.DateTimeOffset(nullable: false, precision: 7),
                        Location = c.Geography(),
                        Latitude = c.Single(nullable: false),
                        Longitude = c.Single(nullable: false),
                        Description = c.String(),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        PolicyPeriod_ID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PolicyPeriod", t => t.PolicyPeriod_ID)
                .Index(t => t.PolicyPeriod_ID);
            
            CreateTable(
                "dbo.ClaimContactPerson",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        Claim_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Claim", t => t.Claim_ID)
                .Index(t => t.Claim_ID);
            
            CreateTable(
                "dbo.ClaimPicture",
                c => new
                    {
                        GUID = c.Guid(nullable: false),
                        ImageSmall = c.String(unicode: false),
                        ImageFull = c.String(unicode: false),
                        ImageDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UploadedBy = c.String(maxLength: 50),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        Claim_ID = c.Int(),
                        Claimant_ID = c.Int(),
                        PictureType_ID = c.Int(),
                    })
                .PrimaryKey(t => t.GUID)
                .ForeignKey("dbo.Claim", t => t.Claim_ID)
                .ForeignKey("dbo.ClaimContactPerson", t => t.Claimant_ID)
                .ForeignKey("dbo.ClaimPictureType", t => t.PictureType_ID)
                .Index(t => t.Claim_ID)
                .Index(t => t.Claimant_ID)
                .Index(t => t.PictureType_ID);
            
            CreateTable(
                "dbo.ClaimPictureType",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PolicyPeriod",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        PeriodStartDate = c.DateTimeOffset(nullable: false, precision: 7),
                        PeriodEndDate = c.DateTimeOffset(nullable: false, precision: 7),
                        Premium = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsLastPeriod = c.Boolean(nullable: false),
                        PeriodNumber = c.Int(nullable: false),
                        InsuranceCompany = c.String(),
                        InsurancePolicyNumber = c.String(),
                        InsuranceStartDate = c.DateTimeOffset(nullable: false, precision: 7),
                        InsuranceEndDate = c.DateTimeOffset(nullable: false, precision: 7),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        Broker_ID = c.Int(),
                        PaymentType_ID = c.Int(),
                        Policy_ID = c.Long(),
                        Quote_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Broker", t => t.Broker_ID)
                .ForeignKey("dbo.PolicyPaymentType", t => t.PaymentType_ID)
                .ForeignKey("dbo.Policy", t => t.Policy_ID)
                .ForeignKey("dbo.PolicyQuote", t => t.Quote_ID)
                .Index(t => t.Broker_ID)
                .Index(t => t.PaymentType_ID)
                .Index(t => t.Policy_ID)
                .Index(t => t.Quote_ID);
            
            CreateTable(
                "dbo.PolicyPaymentType",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Policy",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        PolicyNumber = c.String(),
                        PolicyStartDate = c.DateTimeOffset(nullable: false, precision: 7),
                        PolicyEndDate = c.DateTimeOffset(nullable: false, precision: 7),
                        CancelledAtDate = c.DateTimeOffset(nullable: false, precision: 7),
                        CancelledFromDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsLimitedTerm = c.Boolean(nullable: false),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedDate = c.DateTimeOffset(precision: 7),
                        ModifiedReason = c.String(),
                        CancellationReason_ID = c.Int(),
                        Client_ID = c.Long(),
                        ModificationReason_ID = c.Int(),
                        ModifiedBy_ID = c.Int(),
                        Product_ID = c.Int(),
                        Status_ID = c.Int(),
                        Vehicle_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PolicyCancellationReason", t => t.CancellationReason_ID)
                .ForeignKey("dbo.Client", t => t.Client_ID)
                .ForeignKey("dbo.PolicyModificationReason", t => t.ModificationReason_ID)
                .ForeignKey("dbo.AppUser", t => t.ModifiedBy_ID)
                .ForeignKey("dbo.Product", t => t.Product_ID)
                .ForeignKey("dbo.PolicyStatus", t => t.Status_ID)
                .ForeignKey("dbo.Vehicle", t => t.Vehicle_ID)
                .Index(t => t.CancellationReason_ID)
                .Index(t => t.Client_ID)
                .Index(t => t.ModificationReason_ID)
                .Index(t => t.ModifiedBy_ID)
                .Index(t => t.Product_ID)
                .Index(t => t.Status_ID)
                .Index(t => t.Vehicle_ID);
            
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        ClientCode = c.String(nullable: false, maxLength: 10),
                        IsLegalPerson = c.Boolean(nullable: false),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        LegalPerson_ID = c.Int(),
                        Person_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.LegalPerson", t => t.LegalPerson_ID)
                .ForeignKey("dbo.Person", t => t.Person_ID)
                .Index(t => t.LegalPerson_ID)
                .Index(t => t.Person_ID);
            
            CreateTable(
                "dbo.LegalPerson",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        TaxNumber = c.String(nullable: false),
                        Address_ID = c.Int(),
                        MailingAddress_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Address", t => t.Address_ID)
                .ForeignKey("dbo.Address", t => t.MailingAddress_ID)
                .Index(t => t.Address_ID)
                .Index(t => t.MailingAddress_ID);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 100),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        MiddleName = c.String(nullable: false, maxLength: 100),
                        BirthPlace = c.String(nullable: false, maxLength: 100),
                        BirthDate = c.DateTimeOffset(nullable: false, precision: 7),
                        MotherLastName = c.String(nullable: false, maxLength: 100),
                        MotherFirstName = c.String(nullable: false, maxLength: 100),
                        MotherMiddleName = c.String(nullable: false, maxLength: 100),
                        Gender = c.String(nullable: false, maxLength: 10),
                        IdentityCardNumber = c.String(maxLength: 25),
                        Address_ID = c.Int(),
                        MailingAddress_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Address", t => t.Address_ID)
                .ForeignKey("dbo.Address", t => t.MailingAddress_ID)
                .Index(t => t.Address_ID)
                .Index(t => t.MailingAddress_ID);
            
            CreateTable(
                "dbo.PolicyModificationReason",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PolicyStatus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Vehicle",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PalateNumber = c.String(nullable: false, maxLength: 25),
                        VIN = c.String(nullable: false, maxLength: 50),
                        RegistrationCertificateNumber = c.String(nullable: false, maxLength: 25),
                        Make = c.String(nullable: false, maxLength: 100),
                        Model = c.String(nullable: false, maxLength: 100),
                        Type = c.String(nullable: false, maxLength: 100),
                        Color = c.String(maxLength: 50),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PolicyQuote",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Uid = c.String(nullable: false),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PolicyInstallment",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Nr = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        DueDate = c.DateTimeOffset(nullable: false, precision: 7),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IncomeValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PayedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsPaid = c.Boolean(nullable: false),
                        ChequeSentToPrint = c.DateTimeOffset(nullable: false, precision: 7),
                        ChequeReSentToPrint = c.DateTimeOffset(nullable: false, precision: 7),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        PolicyPeriod_ID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PolicyPeriod", t => t.PolicyPeriod_ID)
                .Index(t => t.PolicyPeriod_ID);
            
            CreateTable(
                "dbo.PolicyRemark",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Remark = c.String(nullable: false),
                        IsPrivate = c.Boolean(nullable: false),
                        IsApproved = c.Boolean(nullable: false),
                        IsPushMessage = c.Boolean(nullable: false),
                        IsSentAsPushMessage = c.Boolean(nullable: false),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        CreatedBy_ID = c.Int(),
                        PolicyPeriod_ID = c.Long(),
                        RemarkType_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AppUser", t => t.CreatedBy_ID)
                .ForeignKey("dbo.PolicyPeriod", t => t.PolicyPeriod_ID)
                .ForeignKey("dbo.PolicyRemarkType", t => t.RemarkType_ID)
                .Index(t => t.CreatedBy_ID)
                .Index(t => t.PolicyPeriod_ID)
                .Index(t => t.RemarkType_ID);
            
            CreateTable(
                "dbo.PolicyRemarkType",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PolicyRemark", "RemarkType_ID", "dbo.PolicyRemarkType");
            DropForeignKey("dbo.PolicyRemark", "PolicyPeriod_ID", "dbo.PolicyPeriod");
            DropForeignKey("dbo.PolicyRemark", "CreatedBy_ID", "dbo.AppUser");
            DropForeignKey("dbo.PolicyInstallment", "PolicyPeriod_ID", "dbo.PolicyPeriod");
            DropForeignKey("dbo.Claim", "PolicyPeriod_ID", "dbo.PolicyPeriod");
            DropForeignKey("dbo.PolicyPeriod", "Quote_ID", "dbo.PolicyQuote");
            DropForeignKey("dbo.Policy", "Vehicle_ID", "dbo.Vehicle");
            DropForeignKey("dbo.Policy", "Status_ID", "dbo.PolicyStatus");
            DropForeignKey("dbo.Policy", "Product_ID", "dbo.Product");
            DropForeignKey("dbo.PolicyPeriod", "Policy_ID", "dbo.Policy");
            DropForeignKey("dbo.Policy", "ModifiedBy_ID", "dbo.AppUser");
            DropForeignKey("dbo.Policy", "ModificationReason_ID", "dbo.PolicyModificationReason");
            DropForeignKey("dbo.Policy", "Client_ID", "dbo.Client");
            DropForeignKey("dbo.Client", "Person_ID", "dbo.Person");
            DropForeignKey("dbo.Person", "MailingAddress_ID", "dbo.Address");
            DropForeignKey("dbo.Person", "Address_ID", "dbo.Address");
            DropForeignKey("dbo.Client", "LegalPerson_ID", "dbo.LegalPerson");
            DropForeignKey("dbo.LegalPerson", "MailingAddress_ID", "dbo.Address");
            DropForeignKey("dbo.LegalPerson", "Address_ID", "dbo.Address");
            DropForeignKey("dbo.Policy", "CancellationReason_ID", "dbo.PolicyCancellationReason");
            DropForeignKey("dbo.PolicyPeriod", "PaymentType_ID", "dbo.PolicyPaymentType");
            DropForeignKey("dbo.PolicyPeriod", "Broker_ID", "dbo.Broker");
            DropForeignKey("dbo.ClaimPicture", "PictureType_ID", "dbo.ClaimPictureType");
            DropForeignKey("dbo.ClaimPicture", "Claimant_ID", "dbo.ClaimContactPerson");
            DropForeignKey("dbo.ClaimPicture", "Claim_ID", "dbo.Claim");
            DropForeignKey("dbo.ClaimContactPerson", "Claim_ID", "dbo.Claim");
            DropForeignKey("dbo.Broker", "ModifiedBy_ID", "dbo.AppUser");
            DropForeignKey("dbo.Broker", "MailingAddress_ID", "dbo.Address");
            DropForeignKey("dbo.Broker", "CreatedBy_ID", "dbo.AppUser");
            DropForeignKey("dbo.Broker", "Address_ID", "dbo.Address");
            DropForeignKey("dbo.AppUser", "Role_ID", "dbo.AppUserRole");
            DropIndex("dbo.PolicyRemark", new[] { "RemarkType_ID" });
            DropIndex("dbo.PolicyRemark", new[] { "PolicyPeriod_ID" });
            DropIndex("dbo.PolicyRemark", new[] { "CreatedBy_ID" });
            DropIndex("dbo.PolicyInstallment", new[] { "PolicyPeriod_ID" });
            DropIndex("dbo.Person", new[] { "MailingAddress_ID" });
            DropIndex("dbo.Person", new[] { "Address_ID" });
            DropIndex("dbo.LegalPerson", new[] { "MailingAddress_ID" });
            DropIndex("dbo.LegalPerson", new[] { "Address_ID" });
            DropIndex("dbo.Client", new[] { "Person_ID" });
            DropIndex("dbo.Client", new[] { "LegalPerson_ID" });
            DropIndex("dbo.Policy", new[] { "Vehicle_ID" });
            DropIndex("dbo.Policy", new[] { "Status_ID" });
            DropIndex("dbo.Policy", new[] { "Product_ID" });
            DropIndex("dbo.Policy", new[] { "ModifiedBy_ID" });
            DropIndex("dbo.Policy", new[] { "ModificationReason_ID" });
            DropIndex("dbo.Policy", new[] { "Client_ID" });
            DropIndex("dbo.Policy", new[] { "CancellationReason_ID" });
            DropIndex("dbo.PolicyPeriod", new[] { "Quote_ID" });
            DropIndex("dbo.PolicyPeriod", new[] { "Policy_ID" });
            DropIndex("dbo.PolicyPeriod", new[] { "PaymentType_ID" });
            DropIndex("dbo.PolicyPeriod", new[] { "Broker_ID" });
            DropIndex("dbo.ClaimPicture", new[] { "PictureType_ID" });
            DropIndex("dbo.ClaimPicture", new[] { "Claimant_ID" });
            DropIndex("dbo.ClaimPicture", new[] { "Claim_ID" });
            DropIndex("dbo.ClaimContactPerson", new[] { "Claim_ID" });
            DropIndex("dbo.Claim", new[] { "PolicyPeriod_ID" });
            DropIndex("dbo.Broker", new[] { "ModifiedBy_ID" });
            DropIndex("dbo.Broker", new[] { "MailingAddress_ID" });
            DropIndex("dbo.Broker", new[] { "CreatedBy_ID" });
            DropIndex("dbo.Broker", new[] { "Address_ID" });
            DropIndex("dbo.AppUser", new[] { "Role_ID" });
            DropTable("dbo.PolicyRemarkType");
            DropTable("dbo.PolicyRemark");
            DropTable("dbo.PolicyInstallment");
            DropTable("dbo.PolicyQuote");
            DropTable("dbo.Vehicle");
            DropTable("dbo.PolicyStatus");
            DropTable("dbo.Product");
            DropTable("dbo.PolicyModificationReason");
            DropTable("dbo.Person");
            DropTable("dbo.LegalPerson");
            DropTable("dbo.Client");
            DropTable("dbo.Policy");
            DropTable("dbo.PolicyPaymentType");
            DropTable("dbo.PolicyPeriod");
            DropTable("dbo.ClaimPictureType");
            DropTable("dbo.ClaimPicture");
            DropTable("dbo.ClaimContactPerson");
            DropTable("dbo.Claim");
            DropTable("dbo.PolicyCancellationReason");
            DropTable("dbo.Broker");
            DropTable("dbo.AppUserRole");
            DropTable("dbo.AppUser");
            DropTable("dbo.Address");
        }
    }
}
