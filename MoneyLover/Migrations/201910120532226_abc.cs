namespace MoneyLover.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CIMASTs", "Balance", c => c.Double());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CIMASTs", "Balance");
        }
    }
}
