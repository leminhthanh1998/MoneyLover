namespace MoneyLover.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CIMASTs", "RATE", c => c.Double(nullable: false));
            DropColumn("dbo.CIMASTs", "PDID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CIMASTs", "PDID", c => c.Int(nullable: false));
            DropColumn("dbo.CIMASTs", "RATE");
        }
    }
}
