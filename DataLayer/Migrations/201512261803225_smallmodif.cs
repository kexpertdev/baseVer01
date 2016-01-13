namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class smallmodif : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clients", "DateCreated", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.People", "BirthDate", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.People", "BirthDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Clients", "DateCreated", c => c.DateTime(nullable: false));
        }
    }
}
