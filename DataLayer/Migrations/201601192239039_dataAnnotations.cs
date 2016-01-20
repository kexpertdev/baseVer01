namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dataAnnotations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PolicyPeriod", "InsurerCompany", c => c.String(maxLength: 50));
            AddColumn("dbo.PolicyPeriod", "InsurerPolicyNumber", c => c.String(maxLength: 50));
            AlterColumn("dbo.Policy", "PolicyNumber", c => c.String(maxLength: 50));
            DropColumn("dbo.PolicyPeriod", "InsuranceCompany");
            DropColumn("dbo.PolicyPeriod", "InsurancePolicyNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PolicyPeriod", "InsurancePolicyNumber", c => c.String());
            AddColumn("dbo.PolicyPeriod", "InsuranceCompany", c => c.String());
            AlterColumn("dbo.Policy", "PolicyNumber", c => c.String());
            DropColumn("dbo.PolicyPeriod", "InsurerPolicyNumber");
            DropColumn("dbo.PolicyPeriod", "InsurerCompany");
        }
    }
}
