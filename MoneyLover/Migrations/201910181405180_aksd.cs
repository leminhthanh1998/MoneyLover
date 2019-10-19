namespace MoneyLover.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aksd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CITRANs", "DemNgay", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CITRANs", "DemNgay");
        }
    }
}
