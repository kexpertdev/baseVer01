namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tableRename : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Address", newName: "BaseAddress");
            RenameTable(name: "dbo.LegalPerson", newName: "BaseLegalPerson");
            RenameTable(name: "dbo.Person", newName: "BasePerson");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.BasePerson", newName: "Person");
            RenameTable(name: "dbo.BaseLegalPerson", newName: "LegalPerson");
            RenameTable(name: "dbo.BaseAddress", newName: "Address");
        }
    }
}
