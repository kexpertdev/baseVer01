namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addins : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Claim", "Policy_ID", "dbo.Policy");
            DropIndex("dbo.Claim", new[] { "Policy_ID" });
            CreateTable(
                "dbo.PolicyInstallment",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Nr = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        DueDate = c.DateTimeOffset(nullable: false, precision: 7),
                        Value = c.Int(nullable: false),
                        IncomeValue = c.Int(nullable: false),
                        PayedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        ChequeSentToPrint = c.DateTimeOffset(nullable: false, precision: 7),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        LastModifiedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        LastModifiedReason = c.String(),
                        PolicyPeriod_ID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PolicyPeriod", t => t.PolicyPeriod_ID)
                .Index(t => t.PolicyPeriod_ID);
            
            AddColumn("dbo.Claim", "PolicyPeriod_ID", c => c.Long());
            AddColumn("dbo.Policy", "IsLimitedTerm", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Claim", "PolicyPeriod_ID");
            AddForeignKey("dbo.Claim", "PolicyPeriod_ID", "dbo.PolicyPeriod", "ID");
            DropColumn("dbo.Claim", "Policy_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Claim", "Policy_ID", c => c.Long());
            DropForeignKey("dbo.PolicyInstallment", "PolicyPeriod_ID", "dbo.PolicyPeriod");
            DropForeignKey("dbo.Claim", "PolicyPeriod_ID", "dbo.PolicyPeriod");
            DropIndex("dbo.PolicyInstallment", new[] { "PolicyPeriod_ID" });
            DropIndex("dbo.Claim", new[] { "PolicyPeriod_ID" });
            DropColumn("dbo.Policy", "IsLimitedTerm");
            DropColumn("dbo.Claim", "PolicyPeriod_ID");
            DropTable("dbo.PolicyInstallment");
            CreateIndex("dbo.Claim", "Policy_ID");
            AddForeignKey("dbo.Claim", "Policy_ID", "dbo.Policy", "ID");
        }
    }
}
