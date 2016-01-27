namespace KE.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modQuote3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PolicyQuote", "ResultedQuotePremium", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PolicyQuote", "ResultedQuotePremium", c => c.Int(nullable: false));
        }
    }
}
