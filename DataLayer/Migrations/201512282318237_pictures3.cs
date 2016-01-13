namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Spatial;
    
    public partial class pictures3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pictures", "Claim_ID", "dbo.Claims");
            DropForeignKey("dbo.Vehicles", "Client_ID", "dbo.Clients");
            DropIndex("dbo.Pictures", new[] { "Claim_ID" });
            DropIndex("dbo.Vehicles", new[] { "Client_ID" });
            CreateTable(
                "dbo.Attachments",
                c => new
                    {
                        GUID = c.Guid(nullable: false),
                        AttachmentPath = c.String(),
                        ImageBase64String = c.String(unicode: false),
                        Image = c.Binary(storeType: "image"),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        AttachmentType_ID = c.Int(),
                        Claim_ID = c.Int(),
                    })
                .PrimaryKey(t => t.GUID)
                .ForeignKey("dbo.AttachmentTypes", t => t.AttachmentType_ID)
                .ForeignKey("dbo.Claims", t => t.Claim_ID)
                .Index(t => t.AttachmentType_ID)
                .Index(t => t.Claim_ID);
            
            CreateTable(
                "dbo.AttachmentTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AllowedExt = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Brokers", "CreatedDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Claims", "Location", c => c.Geography());
            AddColumn("dbo.Claims", "Latitude", c => c.Single(nullable: false));
            AddColumn("dbo.Claims", "Longitude", c => c.Single(nullable: false));
            AddColumn("dbo.Claims", "Email", c => c.String());
            AddColumn("dbo.Claims", "PhoneNumber", c => c.String());
            AddColumn("dbo.Claims", "Remark", c => c.String());
            AddColumn("dbo.Claims", "CreatedDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Claims", "Policy_ID", c => c.Int());
            AddColumn("dbo.Clients", "CreatedDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Person", "IDCardNumber", c => c.String());
            AddColumn("dbo.Policies", "CreatedDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.PolicyStatus", "Name", c => c.String());
            AddColumn("dbo.Vehicles", "CreatedDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.PolicyPeriods", "CreatedDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.PolicyQuotes", "CreatedDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Users", "CreatedDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            CreateIndex("dbo.Claims", "Policy_ID");
            AddForeignKey("dbo.Claims", "Policy_ID", "dbo.Policies", "ID");
            DropColumn("dbo.Clients", "ClientCode");
            DropColumn("dbo.Clients", "DateCreated");
            DropColumn("dbo.Person", "TaxNumber");
            DropColumn("dbo.PolicyStatus", "Status");
            DropColumn("dbo.Vehicles", "Client_ID");
            DropTable("dbo.Pictures");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Image = c.Binary(storeType: "image"),
                        Claim_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Vehicles", "Client_ID", c => c.Long());
            AddColumn("dbo.PolicyStatus", "Status", c => c.String());
            AddColumn("dbo.Person", "TaxNumber", c => c.String());
            AddColumn("dbo.Clients", "DateCreated", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Clients", "ClientCode", c => c.String(maxLength: 10));
            DropForeignKey("dbo.Claims", "Policy_ID", "dbo.Policies");
            DropForeignKey("dbo.Attachments", "Claim_ID", "dbo.Claims");
            DropForeignKey("dbo.Attachments", "AttachmentType_ID", "dbo.AttachmentTypes");
            DropIndex("dbo.Claims", new[] { "Policy_ID" });
            DropIndex("dbo.Attachments", new[] { "Claim_ID" });
            DropIndex("dbo.Attachments", new[] { "AttachmentType_ID" });
            DropColumn("dbo.Users", "CreatedDate");
            DropColumn("dbo.PolicyQuotes", "CreatedDate");
            DropColumn("dbo.PolicyPeriods", "CreatedDate");
            DropColumn("dbo.Vehicles", "CreatedDate");
            DropColumn("dbo.PolicyStatus", "Name");
            DropColumn("dbo.Policies", "CreatedDate");
            DropColumn("dbo.Person", "IDCardNumber");
            DropColumn("dbo.Clients", "CreatedDate");
            DropColumn("dbo.Claims", "Policy_ID");
            DropColumn("dbo.Claims", "CreatedDate");
            DropColumn("dbo.Claims", "Remark");
            DropColumn("dbo.Claims", "PhoneNumber");
            DropColumn("dbo.Claims", "Email");
            DropColumn("dbo.Claims", "Longitude");
            DropColumn("dbo.Claims", "Latitude");
            DropColumn("dbo.Claims", "Location");
            DropColumn("dbo.Brokers", "CreatedDate");
            DropTable("dbo.AttachmentTypes");
            DropTable("dbo.Attachments");
            CreateIndex("dbo.Vehicles", "Client_ID");
            CreateIndex("dbo.Pictures", "Claim_ID");
            AddForeignKey("dbo.Vehicles", "Client_ID", "dbo.Clients", "ID");
            AddForeignKey("dbo.Pictures", "Claim_ID", "dbo.Claims", "ID");
        }
    }
}
