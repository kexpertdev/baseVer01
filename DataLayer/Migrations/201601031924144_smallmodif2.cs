namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class smallmodif2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Broker_ID", "dbo.Brokers");
            DropForeignKey("dbo.PolicyPeriods", "User_ID", "dbo.Users");

            RenameTable(name: "dbo.Person", newName: "Persons");
            RenameTable(name: "dbo.Users", newName: "AppUsers");
            RenameTable(name: "dbo.UserRoles", newName: "AppUserRoles");
           
            DropForeignKey("dbo.Claims", "Policy_ID", "dbo.Policies");
            DropForeignKey("dbo.PolicyPeriods", "Policy_ID", "dbo.Policies");
            DropIndex("dbo.Claims", new[] { "Policy_ID" });
            DropIndex("dbo.PolicyPeriods", new[] { "Policy_ID" });
            DropIndex("dbo.PolicyPeriods", new[] { "User_ID" });
            DropIndex("dbo.AppUsers", new[] { "Broker_ID" });
            DropPrimaryKey("dbo.Policies");
            DropPrimaryKey("dbo.PolicyPeriods");
            CreateTable(
                "dbo.ClaimRemarkLogs",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Remark = c.String(),
                        IsApproved = c.Boolean(nullable: false),
                        IsPushMessage = c.Boolean(nullable: false),
                        IsSentAsPushMessage = c.Boolean(nullable: false),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        Claim_ID = c.Int(),
                        CreatedBy_ID = c.Int(),
                        RemarkType_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Claims", t => t.Claim_ID)
                .ForeignKey("dbo.AppUsers", t => t.CreatedBy_ID)
                .ForeignKey("dbo.RemarkTypes", t => t.RemarkType_ID)
                .Index(t => t.Claim_ID)
                .Index(t => t.CreatedBy_ID)
                .Index(t => t.RemarkType_ID);
            
            CreateTable(
                "dbo.RemarkTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ModificationReasons",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PolicyRemarkLogs",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Remark = c.String(),
                        IsApproved = c.Boolean(nullable: false),
                        IsPushMessage = c.Boolean(nullable: false),
                        IsSentAsPushMessage = c.Boolean(nullable: false),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        CreatedBy_ID = c.Int(),
                        PolicyPeriod_ID = c.Long(),
                        RemarkType_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AppUsers", t => t.CreatedBy_ID)
                .ForeignKey("dbo.PolicyPeriods", t => t.PolicyPeriod_ID)
                .ForeignKey("dbo.RemarkTypes", t => t.RemarkType_ID)
                .Index(t => t.CreatedBy_ID)
                .Index(t => t.PolicyPeriod_ID)
                .Index(t => t.RemarkType_ID);
            
            AddColumn("dbo.Attachments", "UploadedBy", c => c.String());
            AddColumn("dbo.Claims", "Description", c => c.String());
            AddColumn("dbo.Claims", "LastModifiedDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Claims", "LastModifiedReason", c => c.String());
            AddColumn("dbo.Policies", "LastModifiedDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Policies", "LastModifiedReason", c => c.String());
            AddColumn("dbo.Brokers", "Username", c => c.String());
            AddColumn("dbo.Brokers", "LastModifiedDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Brokers", "LastModifiedReason", c => c.String());
            AddColumn("dbo.PolicyPeriods", "LastModifiedDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.PolicyPeriods", "LastModifiedReason", c => c.String());
            AddColumn("dbo.PolicyPeriods", "Broker_ID", c => c.Int());
            AddColumn("dbo.AppUsers", "LastModifiedDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.AppUsers", "LastModifiedReason", c => c.String());
            AlterColumn("dbo.Claims", "Policy_ID", c => c.Long());
            AlterColumn("dbo.Policies", "ID", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.PolicyPeriods", "ID", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.PolicyPeriods", "Policy_ID", c => c.Long());
            AddPrimaryKey("dbo.Policies", "ID");
            AddPrimaryKey("dbo.PolicyPeriods", "ID");
            CreateIndex("dbo.Claims", "Policy_ID");
            CreateIndex("dbo.PolicyPeriods", "Broker_ID");
            CreateIndex("dbo.PolicyPeriods", "Policy_ID");
            AddForeignKey("dbo.PolicyPeriods", "Broker_ID", "dbo.Brokers", "ID");
            AddForeignKey("dbo.Claims", "Policy_ID", "dbo.Policies", "ID");
            AddForeignKey("dbo.PolicyPeriods", "Policy_ID", "dbo.Policies", "ID");
            DropColumn("dbo.Claims", "Remark");
            DropColumn("dbo.PolicyPeriods", "ChequeSentToPrint");
            DropColumn("dbo.PolicyPeriods", "DateOfPayment");
            DropColumn("dbo.PolicyPeriods", "User_ID");
            DropColumn("dbo.AppUsers", "Broker_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AppUsers", "Broker_ID", c => c.Int());
            AddColumn("dbo.PolicyPeriods", "User_ID", c => c.Int());
            AddColumn("dbo.PolicyPeriods", "DateOfPayment", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.PolicyPeriods", "ChequeSentToPrint", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Claims", "Remark", c => c.String());
            DropForeignKey("dbo.PolicyPeriods", "Policy_ID", "dbo.Policies");
            DropForeignKey("dbo.Claims", "Policy_ID", "dbo.Policies");
            DropForeignKey("dbo.PolicyRemarkLogs", "RemarkType_ID", "dbo.RemarkTypes");
            DropForeignKey("dbo.PolicyRemarkLogs", "PolicyPeriod_ID", "dbo.PolicyPeriods");
            DropForeignKey("dbo.PolicyRemarkLogs", "CreatedBy_ID", "dbo.AppUsers");
            DropForeignKey("dbo.PolicyPeriods", "Broker_ID", "dbo.Brokers");
            DropForeignKey("dbo.ClaimRemarkLogs", "RemarkType_ID", "dbo.RemarkTypes");
            DropForeignKey("dbo.ClaimRemarkLogs", "CreatedBy_ID", "dbo.AppUsers");
            DropForeignKey("dbo.ClaimRemarkLogs", "Claim_ID", "dbo.Claims");
            DropIndex("dbo.PolicyRemarkLogs", new[] { "RemarkType_ID" });
            DropIndex("dbo.PolicyRemarkLogs", new[] { "PolicyPeriod_ID" });
            DropIndex("dbo.PolicyRemarkLogs", new[] { "CreatedBy_ID" });
            DropIndex("dbo.PolicyPeriods", new[] { "Policy_ID" });
            DropIndex("dbo.PolicyPeriods", new[] { "Broker_ID" });
            DropIndex("dbo.ClaimRemarkLogs", new[] { "RemarkType_ID" });
            DropIndex("dbo.ClaimRemarkLogs", new[] { "CreatedBy_ID" });
            DropIndex("dbo.ClaimRemarkLogs", new[] { "Claim_ID" });
            DropIndex("dbo.Claims", new[] { "Policy_ID" });
            DropPrimaryKey("dbo.PolicyPeriods");
            DropPrimaryKey("dbo.Policies");
            AlterColumn("dbo.PolicyPeriods", "Policy_ID", c => c.Int());
            AlterColumn("dbo.PolicyPeriods", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Policies", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Claims", "Policy_ID", c => c.Int());
            DropColumn("dbo.AppUsers", "LastModifiedReason");
            DropColumn("dbo.AppUsers", "LastModifiedDate");
            DropColumn("dbo.PolicyPeriods", "Broker_ID");
            DropColumn("dbo.PolicyPeriods", "LastModifiedReason");
            DropColumn("dbo.PolicyPeriods", "LastModifiedDate");
            DropColumn("dbo.Brokers", "LastModifiedReason");
            DropColumn("dbo.Brokers", "LastModifiedDate");
            DropColumn("dbo.Brokers", "Username");
            DropColumn("dbo.Policies", "LastModifiedReason");
            DropColumn("dbo.Policies", "LastModifiedDate");
            DropColumn("dbo.Claims", "LastModifiedReason");
            DropColumn("dbo.Claims", "LastModifiedDate");
            DropColumn("dbo.Claims", "Description");
            DropColumn("dbo.Attachments", "UploadedBy");
            DropTable("dbo.PolicyRemarkLogs");
            DropTable("dbo.ModificationReasons");
            DropTable("dbo.RemarkTypes");
            DropTable("dbo.ClaimRemarkLogs");
            AddPrimaryKey("dbo.PolicyPeriods", "ID");
            AddPrimaryKey("dbo.Policies", "ID");
            CreateIndex("dbo.AppUsers", "Broker_ID");
            CreateIndex("dbo.PolicyPeriods", "User_ID");
            CreateIndex("dbo.PolicyPeriods", "Policy_ID");
            CreateIndex("dbo.Claims", "Policy_ID");
            AddForeignKey("dbo.PolicyPeriods", "Policy_ID", "dbo.Policies", "ID");
            AddForeignKey("dbo.Claims", "Policy_ID", "dbo.Policies", "ID");
            AddForeignKey("dbo.PolicyPeriods", "User_ID", "dbo.Users", "ID");
            AddForeignKey("dbo.Users", "Broker_ID", "dbo.Brokers", "ID");
            RenameTable(name: "dbo.AppUserRoles", newName: "UserRoles");
            RenameTable(name: "dbo.AppUsers", newName: "Users");
            RenameTable(name: "dbo.Persons", newName: "Person");
        }
    }
}
