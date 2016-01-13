namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PostalCode = c.String(maxLength: 4),
                        City = c.String(),
                        StreetName = c.String(),
                        StreetNumber = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Brokers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TaxNumber = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        Address_ID = c.Int(),
                        MailingAddress_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Addresses", t => t.Address_ID)
                .ForeignKey("dbo.Addresses", t => t.MailingAddress_ID)
                .Index(t => t.Address_ID)
                .Index(t => t.MailingAddress_ID);
            
            CreateTable(
                "dbo.Claims",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ClaimNumber = c.String(),
                        NotificationDate = c.DateTimeOffset(nullable: false, precision: 7),
                        AccidentDate = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        ClientCode = c.String(maxLength: 10),
                        IsLegalPerson = c.Boolean(nullable: false),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        LegalPerson_ID = c.Int(),
                        Person_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.LegalPersons", t => t.LegalPerson_ID)
                .ForeignKey("dbo.People", t => t.Person_ID)
                .Index(t => t.LegalPerson_ID)
                .Index(t => t.Person_ID);
            
            CreateTable(
                "dbo.LegalPersons",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TaxNumber = c.String(),
                        Address_ID = c.Int(),
                        MailingAddress_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Addresses", t => t.Address_ID)
                .ForeignKey("dbo.Addresses", t => t.MailingAddress_ID)
                .Index(t => t.Address_ID)
                .Index(t => t.MailingAddress_ID);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TaxNumber = c.String(),
                        Title = c.String(),
                        LastName = c.String(),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        BirthPlace = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        MotherLastName = c.String(),
                        MotherFirstName = c.String(),
                        MotherMiddleName = c.String(),
                        Address_ID = c.Int(),
                        MailingAddress_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Addresses", t => t.Address_ID)
                .ForeignKey("dbo.Addresses", t => t.MailingAddress_ID)
                .Index(t => t.Address_ID)
                .Index(t => t.MailingAddress_ID);
            
            CreateTable(
                "dbo.PaymentTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Policies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PolicyNumber = c.String(),
                        InsuranceCompany = c.String(),
                        InsurancePolicyNumber = c.String(),
                        PolicyStart = c.DateTimeOffset(nullable: false, precision: 7),
                        PolicyEnd = c.DateTimeOffset(nullable: false, precision: 7),
                        CancelledAt = c.DateTimeOffset(nullable: false, precision: 7),
                        CancelledFrom = c.DateTimeOffset(nullable: false, precision: 7),
                        CancellationReason_ID = c.Int(),
                        Client_ID = c.Long(),
                        Product_ID = c.Int(),
                        Status_ID = c.Int(),
                        Vehicle_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PolicyCancellationReasons", t => t.CancellationReason_ID)
                .ForeignKey("dbo.Clients", t => t.Client_ID)
                .ForeignKey("dbo.Products", t => t.Product_ID)
                .ForeignKey("dbo.PolicyStatus", t => t.Status_ID)
                .ForeignKey("dbo.Vehicles", t => t.Vehicle_ID)
                .Index(t => t.CancellationReason_ID)
                .Index(t => t.Client_ID)
                .Index(t => t.Product_ID)
                .Index(t => t.Status_ID)
                .Index(t => t.Vehicle_ID);
            
            CreateTable(
                "dbo.PolicyCancellationReasons",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PolicyStatus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PalateNumber = c.String(),
                        VIN = c.String(),
                        RegistrationCertNumber = c.String(),
                        Make = c.String(),
                        Model = c.String(),
                        Type = c.String(),
                        Color = c.String(),
                        Client_ID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Clients", t => t.Client_ID)
                .Index(t => t.Client_ID);
            
            CreateTable(
                "dbo.PolicyPeriods",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PeriodStart = c.DateTimeOffset(nullable: false, precision: 7),
                        PeriodEnd = c.DateTimeOffset(nullable: false, precision: 7),
                        Premium = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ChequeSentToPrint = c.DateTimeOffset(nullable: false, precision: 7),
                        DateOfPayment = c.DateTimeOffset(nullable: false, precision: 7),
                        IsLastPeriod = c.Boolean(nullable: false),
                        PeriodNumber = c.Int(nullable: false),
                        PaymentType_ID = c.Int(),
                        Policy_ID = c.Int(),
                        Quote_ID = c.Int(),
                        User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PaymentTypes", t => t.PaymentType_ID)
                .ForeignKey("dbo.Policies", t => t.Policy_ID)
                .ForeignKey("dbo.PolicyQuotes", t => t.Quote_ID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.PaymentType_ID)
                .Index(t => t.Policy_ID)
                .Index(t => t.Quote_ID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.PolicyQuotes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Uid = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        Email = c.String(),
                        Broker_ID = c.Int(),
                        Role_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Brokers", t => t.Broker_ID)
                .ForeignKey("dbo.UserRoles", t => t.Role_ID)
                .Index(t => t.Broker_ID)
                .Index(t => t.Role_ID);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PolicyPeriods", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Users", "Role_ID", "dbo.UserRoles");
            DropForeignKey("dbo.Users", "Broker_ID", "dbo.Brokers");
            DropForeignKey("dbo.PolicyPeriods", "Quote_ID", "dbo.PolicyQuotes");
            DropForeignKey("dbo.PolicyPeriods", "Policy_ID", "dbo.Policies");
            DropForeignKey("dbo.PolicyPeriods", "PaymentType_ID", "dbo.PaymentTypes");
            DropForeignKey("dbo.Policies", "Vehicle_ID", "dbo.Vehicles");
            DropForeignKey("dbo.Vehicles", "Client_ID", "dbo.Clients");
            DropForeignKey("dbo.Policies", "Status_ID", "dbo.PolicyStatus");
            DropForeignKey("dbo.Policies", "Product_ID", "dbo.Products");
            DropForeignKey("dbo.Policies", "Client_ID", "dbo.Clients");
            DropForeignKey("dbo.Policies", "CancellationReason_ID", "dbo.PolicyCancellationReasons");
            DropForeignKey("dbo.Clients", "Person_ID", "dbo.People");
            DropForeignKey("dbo.People", "MailingAddress_ID", "dbo.Addresses");
            DropForeignKey("dbo.People", "Address_ID", "dbo.Addresses");
            DropForeignKey("dbo.Clients", "LegalPerson_ID", "dbo.LegalPersons");
            DropForeignKey("dbo.LegalPersons", "MailingAddress_ID", "dbo.Addresses");
            DropForeignKey("dbo.LegalPersons", "Address_ID", "dbo.Addresses");
            DropForeignKey("dbo.Brokers", "MailingAddress_ID", "dbo.Addresses");
            DropForeignKey("dbo.Brokers", "Address_ID", "dbo.Addresses");
            DropIndex("dbo.Users", new[] { "Role_ID" });
            DropIndex("dbo.Users", new[] { "Broker_ID" });
            DropIndex("dbo.PolicyPeriods", new[] { "User_ID" });
            DropIndex("dbo.PolicyPeriods", new[] { "Quote_ID" });
            DropIndex("dbo.PolicyPeriods", new[] { "Policy_ID" });
            DropIndex("dbo.PolicyPeriods", new[] { "PaymentType_ID" });
            DropIndex("dbo.Vehicles", new[] { "Client_ID" });
            DropIndex("dbo.Policies", new[] { "Vehicle_ID" });
            DropIndex("dbo.Policies", new[] { "Status_ID" });
            DropIndex("dbo.Policies", new[] { "Product_ID" });
            DropIndex("dbo.Policies", new[] { "Client_ID" });
            DropIndex("dbo.Policies", new[] { "CancellationReason_ID" });
            DropIndex("dbo.People", new[] { "MailingAddress_ID" });
            DropIndex("dbo.People", new[] { "Address_ID" });
            DropIndex("dbo.LegalPersons", new[] { "MailingAddress_ID" });
            DropIndex("dbo.LegalPersons", new[] { "Address_ID" });
            DropIndex("dbo.Clients", new[] { "Person_ID" });
            DropIndex("dbo.Clients", new[] { "LegalPerson_ID" });
            DropIndex("dbo.Brokers", new[] { "MailingAddress_ID" });
            DropIndex("dbo.Brokers", new[] { "Address_ID" });
            DropTable("dbo.UserRoles");
            DropTable("dbo.Users");
            DropTable("dbo.PolicyQuotes");
            DropTable("dbo.PolicyPeriods");
            DropTable("dbo.Vehicles");
            DropTable("dbo.PolicyStatus");
            DropTable("dbo.Products");
            DropTable("dbo.PolicyCancellationReasons");
            DropTable("dbo.Policies");
            DropTable("dbo.PaymentTypes");
            DropTable("dbo.People");
            DropTable("dbo.LegalPersons");
            DropTable("dbo.Clients");
            DropTable("dbo.Claims");
            DropTable("dbo.Brokers");
            DropTable("dbo.Addresses");
        }
    }
}
