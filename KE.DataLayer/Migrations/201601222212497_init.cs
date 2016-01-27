namespace KE.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BaseAddress",
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
                        Email = c.String(maxLength: 100),
                        PhoneNumber = c.String(maxLength: 25),
                        Role_ID = c.Int(nullable: false),
                        CreatedBy_ID = c.Int(nullable: false),
                        ModifiedBy_ID = c.Int(),
                        Created = c.DateTimeOffset(nullable: false, precision: 7),
                        Modified = c.DateTimeOffset(precision: 7),
                        ModifiedReason = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AppUser", t => t.CreatedBy_ID)
                .ForeignKey("dbo.AppUser", t => t.ModifiedBy_ID)
                .ForeignKey("dbo.AppUserRole", t => t.Role_ID, cascadeDelete: false)
                .Index(t => t.Role_ID)
                .Index(t => t.CreatedBy_ID)
                .Index(t => t.ModifiedBy_ID);
            
            CreateTable(
                "dbo.AppUserRole",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 255),
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
                        Email = c.String(maxLength: 100),
                        PhoneNumber = c.String(maxLength: 25),
                        IsActive = c.Boolean(nullable: false),
                        Address_ID = c.Int(nullable: false),
                        MailingAddress_ID = c.Int(),
                        CreatedBy_ID = c.Int(nullable: false),
                        ModifiedBy_ID = c.Int(),
                        Created = c.DateTimeOffset(nullable: false, precision: 7),
                        Modified = c.DateTimeOffset(precision: 7),
                        ModifiedReason = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BaseAddress", t => t.Address_ID, cascadeDelete: false)
                .ForeignKey("dbo.AppUser", t => t.CreatedBy_ID, cascadeDelete: false)
                .ForeignKey("dbo.BaseAddress", t => t.MailingAddress_ID)
                .ForeignKey("dbo.AppUser", t => t.ModifiedBy_ID)
                .Index(t => t.Address_ID)
                .Index(t => t.MailingAddress_ID)
                .Index(t => t.CreatedBy_ID)
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
                        InsurerClaimNumber = c.String(nullable: false, maxLength: 100),
                        NotificationDate = c.DateTimeOffset(nullable: false, precision: 7),
                        AccidentDate = c.DateTimeOffset(nullable: false, precision: 7),
                        Location = c.Geography(),
                        Latitude = c.Single(nullable: false),
                        Longitude = c.Single(nullable: false),
                        Description = c.String(),
                        LocationDesc = c.String(),
                        Insurer = c.String(maxLength: 25),
                        InsurerPolicyNumber = c.String(maxLength: 50),
                        PolicyPeriod_ID = c.Long(nullable: false),
                        CreatedBy_ID = c.Int(nullable: false),
                        ModifiedBy_ID = c.Int(),
                        Created = c.DateTimeOffset(nullable: false, precision: 7),
                        Modified = c.DateTimeOffset(precision: 7),
                        ModifiedReason = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AppUser", t => t.CreatedBy_ID, cascadeDelete: false)
                .ForeignKey("dbo.AppUser", t => t.ModifiedBy_ID)
                .ForeignKey("dbo.PolicyPeriod", t => t.PolicyPeriod_ID, cascadeDelete: false)
                .Index(t => t.PolicyPeriod_ID)
                .Index(t => t.CreatedBy_ID)
                .Index(t => t.ModifiedBy_ID);
            
            CreateTable(
                "dbo.ClaimContact",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(maxLength: 100),
                        PhoneNumber = c.String(maxLength: 25),
                        Claim_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Claim", t => t.Claim_ID, cascadeDelete: false)
                .Index(t => t.Claim_ID);
            
            CreateTable(
                "dbo.ClaimPicture",
                c => new
                    {
                        Guid = c.Guid(nullable: false, identity: true),
                        ImageName = c.String(nullable: false, maxLength: 255),
                        ImageSmall = c.String(unicode: false),
                        ImageFull = c.String(unicode: false),
                        ImageDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UploadedBy = c.String(maxLength: 50),
                        Claimant_ID = c.Int(nullable: false),
                        PictureType_ID = c.Int(nullable: false),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Guid)
                .ForeignKey("dbo.ClaimContact", t => t.Claimant_ID, cascadeDelete: false)
                .ForeignKey("dbo.ClaimPictureType", t => t.PictureType_ID, cascadeDelete: false)
                .Index(t => t.Claimant_ID)
                .Index(t => t.PictureType_ID);
            
            CreateTable(
                "dbo.ClaimPictureType",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 255),
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
                        InsurerCompany = c.String(maxLength: 50),
                        InsurerPolicyNumber = c.String(maxLength: 50),
                        InsuranceStartDate = c.DateTimeOffset(nullable: false, precision: 7),
                        InsuranceEndDate = c.DateTimeOffset(nullable: false, precision: 7),
                        Broker_ID = c.Int(nullable: false),
                        Policy_ID = c.Long(nullable: false),
                        Quote_ID = c.Long(nullable: false),
                        PaymentType_ID = c.Int(nullable: false),
                        PreviousPolicyPeriod_ID = c.Long(),
                        Created = c.DateTimeOffset(nullable: false, precision: 7),
                        Modified = c.DateTimeOffset(precision: 7),
                        ModifiedReason = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PolicyPaymentType", t => t.PaymentType_ID, cascadeDelete: false)
                .ForeignKey("dbo.Policy", t => t.Policy_ID, cascadeDelete: false)
                .ForeignKey("dbo.PolicyPeriod", t => t.PreviousPolicyPeriod_ID)
                .ForeignKey("dbo.PolicyQuote", t => t.Quote_ID, cascadeDelete: false)
                .Index(t => t.Policy_ID)
                .Index(t => t.Quote_ID)
                .Index(t => t.PaymentType_ID)
                .Index(t => t.PreviousPolicyPeriod_ID);
            
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
                        PolicyNumber = c.String(nullable: false, maxLength: 50),
                        PolicyStartDate = c.DateTimeOffset(nullable: false, precision: 7),
                        PolicyEndDate = c.DateTimeOffset(nullable: false, precision: 7),
                        CancelledAtDate = c.DateTimeOffset(precision: 7),
                        CancelledFromDate = c.DateTimeOffset(precision: 7),
                        IsFixedTerm = c.Boolean(nullable: false),
                        Product_ID = c.Int(nullable: false),
                        Status_ID = c.Int(nullable: false),
                        Broker_ID = c.Int(nullable: false),
                        Client_ID = c.Long(nullable: false),
                        Vehicle_ID = c.Long(nullable: false),
                        CancellationReason_ID = c.Int(),
                        ModificationReason_ID = c.Int(),
                        CreatedBy_ID = c.Int(nullable: false),
                        ModifiedBy_ID = c.Int(),
                        Created = c.DateTimeOffset(nullable: false, precision: 7),
                        Modified = c.DateTimeOffset(precision: 7),
                        ModifiedReason = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Broker", t => t.Broker_ID, cascadeDelete: false)
                .ForeignKey("dbo.PolicyCancellationReason", t => t.CancellationReason_ID)
                .ForeignKey("dbo.Client", t => t.Client_ID, cascadeDelete: false)
                .ForeignKey("dbo.AppUser", t => t.CreatedBy_ID, cascadeDelete: false)
                .ForeignKey("dbo.PolicyModificationReason", t => t.ModificationReason_ID)
                .ForeignKey("dbo.AppUser", t => t.ModifiedBy_ID)
                .ForeignKey("dbo.Product", t => t.Product_ID, cascadeDelete: false)
                .ForeignKey("dbo.PolicyStatus", t => t.Status_ID, cascadeDelete: false)
                .ForeignKey("dbo.Vehicle", t => t.Vehicle_ID, cascadeDelete: false)
                .Index(t => t.PolicyNumber, unique: true)
                .Index(t => t.Product_ID)
                .Index(t => t.Status_ID)
                .Index(t => t.Broker_ID)
                .Index(t => t.Client_ID)
                .Index(t => t.Vehicle_ID)
                .Index(t => t.CancellationReason_ID)
                .Index(t => t.ModificationReason_ID)
                .Index(t => t.CreatedBy_ID)
                .Index(t => t.ModifiedBy_ID);
            
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        ClientCode = c.String(nullable: false, maxLength: 10),
                        ClientCodeFromBroker = c.String(maxLength: 100),
                        IsLegalPerson = c.Boolean(nullable: false),
                        Email = c.String(maxLength: 100),
                        PhoneNumber = c.String(maxLength: 25),
                        Person_ID = c.Int(),
                        LegalPerson_ID = c.Int(),
                        ModifiedBy_ID = c.Int(),
                        Created = c.DateTimeOffset(nullable: false, precision: 7),
                        Modified = c.DateTimeOffset(precision: 7),
                        ModifiedReason = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BaseLegalPerson", t => t.LegalPerson_ID)
                .ForeignKey("dbo.AppUser", t => t.ModifiedBy_ID)
                .ForeignKey("dbo.BasePerson", t => t.Person_ID)
                .Index(t => t.Person_ID)
                .Index(t => t.LegalPerson_ID)
                .Index(t => t.ModifiedBy_ID);
            
            CreateTable(
                "dbo.BaseLegalPerson",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        TaxNumber = c.String(nullable: false),
                        Address_ID = c.Int(nullable: false),
                        MailingAddress_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BaseAddress", t => t.Address_ID, cascadeDelete: false)
                .ForeignKey("dbo.BaseAddress", t => t.MailingAddress_ID)
                .Index(t => t.Address_ID)
                .Index(t => t.MailingAddress_ID);
            
            CreateTable(
                "dbo.BasePerson",
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
                        Address_ID = c.Int(nullable: false),
                        MailingAddress_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BaseAddress", t => t.Address_ID, cascadeDelete: false)
                .ForeignKey("dbo.BaseAddress", t => t.MailingAddress_ID)
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
                        ID = c.Long(nullable: false, identity: true),
                        PalateNumber = c.String(nullable: false, maxLength: 25),
                        VIN = c.String(nullable: false, maxLength: 50),
                        RegistrationCertificateNumber = c.String(nullable: false, maxLength: 25),
                        Make = c.String(nullable: false, maxLength: 100),
                        Model = c.String(nullable: false, maxLength: 100),
                        Type = c.String(nullable: false, maxLength: 100),
                        Usage = c.String(nullable: false, maxLength: 100),
                        Color = c.String(maxLength: 50),
                        ModifiedBy_ID = c.Int(nullable: false),
                        Created = c.DateTimeOffset(nullable: false, precision: 7),
                        Modified = c.DateTimeOffset(precision: 7),
                        ModifiedReason = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AppUser", t => t.ModifiedBy_ID, cascadeDelete: false)
                .Index(t => t.ModifiedBy_ID);
            
            CreateTable(
                "dbo.PolicyQuote",
                c => new
                    {
                        ID = c.Long(nullable: false),
                        Guid = c.Guid(nullable: false, identity: true),
                        PolicyType = c.String(),
                        PolicyStartDate = c.DateTimeOffset(nullable: false, precision: 7),
                        PolicyNrOfMonthsValid = c.Int(nullable: false),
                        PolicyPaymentMethod = c.String(),
                        VehicleType = c.String(),
                        VehicleUsage = c.String(),
                        ContractorIsLegalPerson = c.Boolean(nullable: false),
                        PostalCode = c.String(),
                        RequestUrl = c.String(),
                        ResultedQuotePremium = c.Int(nullable: false),
                        PolicyEndDate = c.DateTimeOffset(nullable: false, precision: 7),
                        ClientCodeGenerated = c.String(),
                        PaymentUrl = c.String(),
                        Product_ID = c.Int(nullable: false),
                        Broker_ID = c.Int(nullable: false),
                        Created = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Broker", t => t.Broker_ID, cascadeDelete: false)
                .ForeignKey("dbo.Product", t => t.Product_ID, cascadeDelete: false)
                .Index(t => t.Product_ID)
                .Index(t => t.Broker_ID);
            
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
                        PolicyPeriod_ID = c.Long(nullable: false),
                        ModifiedBy_ID = c.Int(),
                        Created = c.DateTimeOffset(nullable: false, precision: 7),
                        Modified = c.DateTimeOffset(precision: 7),
                        ModifiedReason = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AppUser", t => t.ModifiedBy_ID)
                .ForeignKey("dbo.PolicyPeriod", t => t.PolicyPeriod_ID, cascadeDelete: false)
                .Index(t => t.PolicyPeriod_ID)
                .Index(t => t.ModifiedBy_ID);
            
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
                        RemarkType_ID = c.Int(nullable: false),
                        PolicyPeriod_ID = c.Long(nullable: false),
                        CreatedBy_ID = c.Int(nullable: false),
                        Created = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AppUser", t => t.CreatedBy_ID, cascadeDelete: false)
                .ForeignKey("dbo.PolicyPeriod", t => t.PolicyPeriod_ID, cascadeDelete: false)
                .ForeignKey("dbo.PolicyRemarkType", t => t.RemarkType_ID, cascadeDelete: false)
                .Index(t => t.RemarkType_ID)
                .Index(t => t.PolicyPeriod_ID)
                .Index(t => t.CreatedBy_ID);
            
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
            DropForeignKey("dbo.PolicyInstallment", "ModifiedBy_ID", "dbo.AppUser");
            DropForeignKey("dbo.Claim", "PolicyPeriod_ID", "dbo.PolicyPeriod");
            DropForeignKey("dbo.PolicyPeriod", "Quote_ID", "dbo.PolicyQuote");
            DropForeignKey("dbo.PolicyQuote", "Product_ID", "dbo.Product");
            DropForeignKey("dbo.PolicyQuote", "Broker_ID", "dbo.Broker");
            DropForeignKey("dbo.PolicyPeriod", "PreviousPolicyPeriod_ID", "dbo.PolicyPeriod");
            DropForeignKey("dbo.PolicyPeriod", "Policy_ID", "dbo.Policy");
            DropForeignKey("dbo.Policy", "Vehicle_ID", "dbo.Vehicle");
            DropForeignKey("dbo.Vehicle", "ModifiedBy_ID", "dbo.AppUser");
            DropForeignKey("dbo.Policy", "Status_ID", "dbo.PolicyStatus");
            DropForeignKey("dbo.Policy", "Product_ID", "dbo.Product");
            DropForeignKey("dbo.Policy", "ModifiedBy_ID", "dbo.AppUser");
            DropForeignKey("dbo.Policy", "ModificationReason_ID", "dbo.PolicyModificationReason");
            DropForeignKey("dbo.Policy", "CreatedBy_ID", "dbo.AppUser");
            DropForeignKey("dbo.Policy", "Client_ID", "dbo.Client");
            DropForeignKey("dbo.Client", "Person_ID", "dbo.BasePerson");
            DropForeignKey("dbo.BasePerson", "MailingAddress_ID", "dbo.BaseAddress");
            DropForeignKey("dbo.BasePerson", "Address_ID", "dbo.BaseAddress");
            DropForeignKey("dbo.Client", "ModifiedBy_ID", "dbo.AppUser");
            DropForeignKey("dbo.Client", "LegalPerson_ID", "dbo.BaseLegalPerson");
            DropForeignKey("dbo.BaseLegalPerson", "MailingAddress_ID", "dbo.BaseAddress");
            DropForeignKey("dbo.BaseLegalPerson", "Address_ID", "dbo.BaseAddress");
            DropForeignKey("dbo.Policy", "CancellationReason_ID", "dbo.PolicyCancellationReason");
            DropForeignKey("dbo.Policy", "Broker_ID", "dbo.Broker");
            DropForeignKey("dbo.PolicyPeriod", "PaymentType_ID", "dbo.PolicyPaymentType");
            DropForeignKey("dbo.Claim", "ModifiedBy_ID", "dbo.AppUser");
            DropForeignKey("dbo.Claim", "CreatedBy_ID", "dbo.AppUser");
            DropForeignKey("dbo.ClaimPicture", "PictureType_ID", "dbo.ClaimPictureType");
            DropForeignKey("dbo.ClaimPicture", "Claimant_ID", "dbo.ClaimContact");
            DropForeignKey("dbo.ClaimContact", "Claim_ID", "dbo.Claim");
            DropForeignKey("dbo.Broker", "ModifiedBy_ID", "dbo.AppUser");
            DropForeignKey("dbo.Broker", "MailingAddress_ID", "dbo.BaseAddress");
            DropForeignKey("dbo.Broker", "CreatedBy_ID", "dbo.AppUser");
            DropForeignKey("dbo.Broker", "Address_ID", "dbo.BaseAddress");
            DropForeignKey("dbo.AppUser", "Role_ID", "dbo.AppUserRole");
            DropForeignKey("dbo.AppUser", "ModifiedBy_ID", "dbo.AppUser");
            DropForeignKey("dbo.AppUser", "CreatedBy_ID", "dbo.AppUser");
            DropIndex("dbo.PolicyRemark", new[] { "CreatedBy_ID" });
            DropIndex("dbo.PolicyRemark", new[] { "PolicyPeriod_ID" });
            DropIndex("dbo.PolicyRemark", new[] { "RemarkType_ID" });
            DropIndex("dbo.PolicyInstallment", new[] { "ModifiedBy_ID" });
            DropIndex("dbo.PolicyInstallment", new[] { "PolicyPeriod_ID" });
            DropIndex("dbo.PolicyQuote", new[] { "Broker_ID" });
            DropIndex("dbo.PolicyQuote", new[] { "Product_ID" });
            DropIndex("dbo.Vehicle", new[] { "ModifiedBy_ID" });
            DropIndex("dbo.BasePerson", new[] { "MailingAddress_ID" });
            DropIndex("dbo.BasePerson", new[] { "Address_ID" });
            DropIndex("dbo.BaseLegalPerson", new[] { "MailingAddress_ID" });
            DropIndex("dbo.BaseLegalPerson", new[] { "Address_ID" });
            DropIndex("dbo.Client", new[] { "ModifiedBy_ID" });
            DropIndex("dbo.Client", new[] { "LegalPerson_ID" });
            DropIndex("dbo.Client", new[] { "Person_ID" });
            DropIndex("dbo.Policy", new[] { "ModifiedBy_ID" });
            DropIndex("dbo.Policy", new[] { "CreatedBy_ID" });
            DropIndex("dbo.Policy", new[] { "ModificationReason_ID" });
            DropIndex("dbo.Policy", new[] { "CancellationReason_ID" });
            DropIndex("dbo.Policy", new[] { "Vehicle_ID" });
            DropIndex("dbo.Policy", new[] { "Client_ID" });
            DropIndex("dbo.Policy", new[] { "Broker_ID" });
            DropIndex("dbo.Policy", new[] { "Status_ID" });
            DropIndex("dbo.Policy", new[] { "Product_ID" });
            DropIndex("dbo.Policy", new[] { "PolicyNumber" });
            DropIndex("dbo.PolicyPeriod", new[] { "PreviousPolicyPeriod_ID" });
            DropIndex("dbo.PolicyPeriod", new[] { "PaymentType_ID" });
            DropIndex("dbo.PolicyPeriod", new[] { "Quote_ID" });
            DropIndex("dbo.PolicyPeriod", new[] { "Policy_ID" });
            DropIndex("dbo.ClaimPicture", new[] { "PictureType_ID" });
            DropIndex("dbo.ClaimPicture", new[] { "Claimant_ID" });
            DropIndex("dbo.ClaimContact", new[] { "Claim_ID" });
            DropIndex("dbo.Claim", new[] { "ModifiedBy_ID" });
            DropIndex("dbo.Claim", new[] { "CreatedBy_ID" });
            DropIndex("dbo.Claim", new[] { "PolicyPeriod_ID" });
            DropIndex("dbo.Broker", new[] { "ModifiedBy_ID" });
            DropIndex("dbo.Broker", new[] { "CreatedBy_ID" });
            DropIndex("dbo.Broker", new[] { "MailingAddress_ID" });
            DropIndex("dbo.Broker", new[] { "Address_ID" });
            DropIndex("dbo.AppUser", new[] { "ModifiedBy_ID" });
            DropIndex("dbo.AppUser", new[] { "CreatedBy_ID" });
            DropIndex("dbo.AppUser", new[] { "Role_ID" });
            DropTable("dbo.PolicyRemarkType");
            DropTable("dbo.PolicyRemark");
            DropTable("dbo.PolicyInstallment");
            DropTable("dbo.PolicyQuote");
            DropTable("dbo.Vehicle");
            DropTable("dbo.PolicyStatus");
            DropTable("dbo.Product");
            DropTable("dbo.PolicyModificationReason");
            DropTable("dbo.BasePerson");
            DropTable("dbo.BaseLegalPerson");
            DropTable("dbo.Client");
            DropTable("dbo.Policy");
            DropTable("dbo.PolicyPaymentType");
            DropTable("dbo.PolicyPeriod");
            DropTable("dbo.ClaimPictureType");
            DropTable("dbo.ClaimPicture");
            DropTable("dbo.ClaimContact");
            DropTable("dbo.Claim");
            DropTable("dbo.PolicyCancellationReason");
            DropTable("dbo.Broker");
            DropTable("dbo.AppUserRole");
            DropTable("dbo.AppUser");
            DropTable("dbo.BaseAddress");
        }
    }
}
