namespace KE.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modQuote : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PolicyQuote", "PolicyType", c => c.Int(nullable: false));
            AlterColumn("dbo.PolicyQuote", "PolicyPaymentMethod", c => c.Int(nullable: false));
            AlterColumn("dbo.PolicyQuote", "VehicleType", c => c.String(maxLength: 100));
            AlterColumn("dbo.PolicyQuote", "VehicleUsage", c => c.String(maxLength: 100));
            AlterColumn("dbo.PolicyQuote", "PostalCode", c => c.String(maxLength: 6));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PolicyQuote", "PostalCode", c => c.String());
            AlterColumn("dbo.PolicyQuote", "VehicleUsage", c => c.String());
            AlterColumn("dbo.PolicyQuote", "VehicleType", c => c.String());
            AlterColumn("dbo.PolicyQuote", "PolicyPaymentMethod", c => c.String());
            AlterColumn("dbo.PolicyQuote", "PolicyType", c => c.String());
        }
    }
}
