namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableModifUpdates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AppUser", "ModifiedBy_ID", c => c.Int());
            AddColumn("dbo.Claim", "ModifiedDate", c => c.DateTimeOffset(precision: 7));
            AddColumn("dbo.Claim", "ModifiedReason", c => c.String());
            AddColumn("dbo.Claim", "ModifiedBy_ID", c => c.Int());
            AddColumn("dbo.PolicyPeriod", "ModifiedDate", c => c.DateTimeOffset(precision: 7));
            AddColumn("dbo.PolicyPeriod", "ModifiedReason", c => c.String());
            AddColumn("dbo.PolicyPeriod", "ModifiedBy_ID", c => c.Int());
            AddColumn("dbo.Client", "ModifiedDate", c => c.DateTimeOffset(precision: 7));
            AddColumn("dbo.Client", "ModifiedReason", c => c.String());
            AddColumn("dbo.Client", "ModifiedBy_ID", c => c.Int());
            AddColumn("dbo.Vehicle", "ModifiedDate", c => c.DateTimeOffset(precision: 7));
            AddColumn("dbo.Vehicle", "ModifiedReason", c => c.String());
            AddColumn("dbo.Vehicle", "ModifiedBy_ID", c => c.Int());
            CreateIndex("dbo.AppUser", "ModifiedBy_ID");
            CreateIndex("dbo.Claim", "ModifiedBy_ID");
            CreateIndex("dbo.PolicyPeriod", "ModifiedBy_ID");
            CreateIndex("dbo.Client", "ModifiedBy_ID");
            CreateIndex("dbo.Vehicle", "ModifiedBy_ID");
            AddForeignKey("dbo.AppUser", "ModifiedBy_ID", "dbo.AppUser", "ID");
            AddForeignKey("dbo.Claim", "ModifiedBy_ID", "dbo.AppUser", "ID");
            AddForeignKey("dbo.PolicyPeriod", "ModifiedBy_ID", "dbo.AppUser", "ID");
            AddForeignKey("dbo.Client", "ModifiedBy_ID", "dbo.AppUser", "ID");
            AddForeignKey("dbo.Vehicle", "ModifiedBy_ID", "dbo.AppUser", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicle", "ModifiedBy_ID", "dbo.AppUser");
            DropForeignKey("dbo.Client", "ModifiedBy_ID", "dbo.AppUser");
            DropForeignKey("dbo.PolicyPeriod", "ModifiedBy_ID", "dbo.AppUser");
            DropForeignKey("dbo.Claim", "ModifiedBy_ID", "dbo.AppUser");
            DropForeignKey("dbo.AppUser", "ModifiedBy_ID", "dbo.AppUser");
            DropIndex("dbo.Vehicle", new[] { "ModifiedBy_ID" });
            DropIndex("dbo.Client", new[] { "ModifiedBy_ID" });
            DropIndex("dbo.PolicyPeriod", new[] { "ModifiedBy_ID" });
            DropIndex("dbo.Claim", new[] { "ModifiedBy_ID" });
            DropIndex("dbo.AppUser", new[] { "ModifiedBy_ID" });
            DropColumn("dbo.Vehicle", "ModifiedBy_ID");
            DropColumn("dbo.Vehicle", "ModifiedReason");
            DropColumn("dbo.Vehicle", "ModifiedDate");
            DropColumn("dbo.Client", "ModifiedBy_ID");
            DropColumn("dbo.Client", "ModifiedReason");
            DropColumn("dbo.Client", "ModifiedDate");
            DropColumn("dbo.PolicyPeriod", "ModifiedBy_ID");
            DropColumn("dbo.PolicyPeriod", "ModifiedReason");
            DropColumn("dbo.PolicyPeriod", "ModifiedDate");
            DropColumn("dbo.Claim", "ModifiedBy_ID");
            DropColumn("dbo.Claim", "ModifiedReason");
            DropColumn("dbo.Claim", "ModifiedDate");
            DropColumn("dbo.AppUser", "ModifiedBy_ID");
        }
    }
}
