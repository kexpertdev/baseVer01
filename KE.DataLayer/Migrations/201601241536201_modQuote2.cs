namespace KE.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modQuote2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PolicyPeriod", "Quote_ID", "dbo.PolicyQuote");
            DropPrimaryKey("dbo.PolicyQuote");
            AlterColumn("dbo.PolicyQuote", "ID", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.PolicyQuote", "Guid", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.PolicyQuote", "ID");
            AddForeignKey("dbo.PolicyPeriod", "Quote_ID", "dbo.PolicyQuote", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PolicyPeriod", "Quote_ID", "dbo.PolicyQuote");
            DropPrimaryKey("dbo.PolicyQuote");
            AlterColumn("dbo.PolicyQuote", "Guid", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.PolicyQuote", "ID", c => c.Long(nullable: false));
            AddPrimaryKey("dbo.PolicyQuote", "ID");
            AddForeignKey("dbo.PolicyPeriod", "Quote_ID", "dbo.PolicyQuote", "ID", cascadeDelete: true);
        }
    }
}
