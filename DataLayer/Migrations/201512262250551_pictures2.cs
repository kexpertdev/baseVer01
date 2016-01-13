namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pictures2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Image = c.Binary(storeType: "image"),
                        Claim_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Claims", t => t.Claim_ID)
                .Index(t => t.Claim_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pictures", "Claim_ID", "dbo.Claims");
            DropIndex("dbo.Pictures", new[] { "Claim_ID" });
            DropTable("dbo.Pictures");
        }
    }
}
