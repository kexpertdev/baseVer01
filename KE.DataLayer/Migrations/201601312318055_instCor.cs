namespace KE.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class instCor : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PolicyInstallment", "PayedDate", c => c.DateTimeOffset(precision: 7));
            AlterColumn("dbo.PolicyInstallment", "ChequeSentToPrint", c => c.DateTimeOffset(precision: 7));
            AlterColumn("dbo.PolicyInstallment", "ChequeReSentToPrint", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PolicyInstallment", "ChequeReSentToPrint", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.PolicyInstallment", "ChequeSentToPrint", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.PolicyInstallment", "PayedDate", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
    }
}
