namespace KE.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class quoteMod : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PolicyQuote", "IsLegalPerson", c => c.Byte(nullable: false));
            AddColumn("dbo.PolicyQuote", "Premium", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Vehicle", "Type", c => c.Int(nullable: false));
            AlterColumn("dbo.Vehicle", "Usage", c => c.Int(nullable: false));
            DropColumn("dbo.PolicyQuote", "ContractorIsLegalPerson");
            DropColumn("dbo.PolicyQuote", "ResultedQuotePremium");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PolicyQuote", "ResultedQuotePremium", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.PolicyQuote", "ContractorIsLegalPerson", c => c.Byte(nullable: false));
            AlterColumn("dbo.Vehicle", "Usage", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Vehicle", "Type", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.PolicyQuote", "Premium");
            DropColumn("dbo.PolicyQuote", "IsLegalPerson");
        }
    }
}
