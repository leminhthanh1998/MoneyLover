namespace MoneyLover.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aksdla : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CIMASTs", "STT", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CIMASTs", "STT");
        }
    }
}
