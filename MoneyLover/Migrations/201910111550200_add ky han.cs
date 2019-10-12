namespace MoneyLover.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addkyhan : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CIMASTs", "TERM", c => c.Int(nullable: false));
            DropColumn("dbo.CIMASTs", "INTEREST");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CIMASTs", "INTEREST", c => c.Double(nullable: false));
            DropColumn("dbo.CIMASTs", "TERM");
        }
    }
}
