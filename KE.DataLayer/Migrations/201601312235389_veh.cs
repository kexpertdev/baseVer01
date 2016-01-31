namespace KE.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class veh : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Vehicle", "ModifiedBy_ID", "dbo.AppUser");
            DropIndex("dbo.Vehicle", new[] { "ModifiedBy_ID" });
            AlterColumn("dbo.Vehicle", "ModifiedBy_ID", c => c.Int());
            CreateIndex("dbo.Vehicle", "ModifiedBy_ID");
            AddForeignKey("dbo.Vehicle", "ModifiedBy_ID", "dbo.AppUser", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicle", "ModifiedBy_ID", "dbo.AppUser");
            DropIndex("dbo.Vehicle", new[] { "ModifiedBy_ID" });
            AlterColumn("dbo.Vehicle", "ModifiedBy_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Vehicle", "ModifiedBy_ID");
            AddForeignKey("dbo.Vehicle", "ModifiedBy_ID", "dbo.AppUser", "ID", cascadeDelete: true);
        }
    }
}
