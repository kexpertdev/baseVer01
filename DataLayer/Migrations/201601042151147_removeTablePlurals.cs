namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeTablePlurals : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Addresses", newName: "Address");
            RenameTable(name: "dbo.AppUsers", newName: "AppUser");
            RenameTable(name: "dbo.AppUserRoles", newName: "AppUserRole");
            RenameTable(name: "dbo.Attachments", newName: "Attachment");
            RenameTable(name: "dbo.AttachmentTypes", newName: "AttachmentType");
            RenameTable(name: "dbo.Claims", newName: "Claim");
            RenameTable(name: "dbo.Policies", newName: "Policy");
            RenameTable(name: "dbo.PolicyCancellationReasons", newName: "PolicyCancellationReason");
            RenameTable(name: "dbo.Clients", newName: "Client");
            RenameTable(name: "dbo.LegalPersons", newName: "LegalPerson");
            RenameTable(name: "dbo.Persons", newName: "Person");
            RenameTable(name: "dbo.Products", newName: "Product");
            RenameTable(name: "dbo.Vehicles", newName: "Vehicle");
            RenameTable(name: "dbo.Brokers", newName: "Broker");
            RenameTable(name: "dbo.ClaimRemarkLogs", newName: "ClaimRemarkLog");
            RenameTable(name: "dbo.RemarkTypes", newName: "RemarkType");
            RenameTable(name: "dbo.ModificationReasons", newName: "ModificationReason");
            RenameTable(name: "dbo.PaymentTypes", newName: "PaymentType");
            RenameTable(name: "dbo.PolicyPeriods", newName: "PolicyPeriod");
            RenameTable(name: "dbo.PolicyQuotes", newName: "PolicyQuote");
            RenameTable(name: "dbo.PolicyRemarkLogs", newName: "PolicyRemarkLog");
            AddColumn("dbo.Client", "ClientCode", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Client", "ClientCode");
            RenameTable(name: "dbo.PolicyRemarkLog", newName: "PolicyRemarkLogs");
            RenameTable(name: "dbo.PolicyQuote", newName: "PolicyQuotes");
            RenameTable(name: "dbo.PolicyPeriod", newName: "PolicyPeriods");
            RenameTable(name: "dbo.PaymentType", newName: "PaymentTypes");
            RenameTable(name: "dbo.ModificationReason", newName: "ModificationReasons");
            RenameTable(name: "dbo.RemarkType", newName: "RemarkTypes");
            RenameTable(name: "dbo.ClaimRemarkLog", newName: "ClaimRemarkLogs");
            RenameTable(name: "dbo.Broker", newName: "Brokers");
            RenameTable(name: "dbo.Vehicle", newName: "Vehicles");
            RenameTable(name: "dbo.Product", newName: "Products");
            RenameTable(name: "dbo.Person", newName: "Persons");
            RenameTable(name: "dbo.LegalPerson", newName: "LegalPersons");
            RenameTable(name: "dbo.Client", newName: "Clients");
            RenameTable(name: "dbo.PolicyCancellationReason", newName: "PolicyCancellationReasons");
            RenameTable(name: "dbo.Policy", newName: "Policies");
            RenameTable(name: "dbo.Claim", newName: "Claims");
            RenameTable(name: "dbo.AttachmentType", newName: "AttachmentTypes");
            RenameTable(name: "dbo.Attachment", newName: "Attachments");
            RenameTable(name: "dbo.AppUserRole", newName: "AppUserRoles");
            RenameTable(name: "dbo.AppUser", newName: "AppUsers");
            RenameTable(name: "dbo.Address", newName: "Addresses");
        }
    }
}
