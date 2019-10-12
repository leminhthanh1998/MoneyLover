namespace MoneyLover.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CIMASTs", "NPTERM", c => c.Double());
            AddColumn("dbo.CIMASTs", "BANK", c => c.String());
            AddColumn("dbo.CIMASTs", "TraLai", c => c.Int(nullable: false));
            AddColumn("dbo.CIMASTs", "KhiDenHan", c => c.Double(nullable: false));
            DropColumn("dbo.CIMASTs", "CUSID");
            DropColumn("dbo.CIMASTs", "TODATE");
            DropColumn("dbo.CIMASTs", "ISBLOCKED");
            DropColumn("dbo.CIMASTs", "BLOCKEDAMT");
            DropColumn("dbo.CIMASTs", "INCREASEINT");
            DropColumn("dbo.CIMASTs", "STATUS");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CIMASTs", "STATUS", c => c.String());
            AddColumn("dbo.CIMASTs", "INCREASEINT", c => c.Double(nullable: false));
            AddColumn("dbo.CIMASTs", "BLOCKEDAMT", c => c.Double(nullable: false));
            AddColumn("dbo.CIMASTs", "ISBLOCKED", c => c.Int(nullable: false));
            AddColumn("dbo.CIMASTs", "TODATE", c => c.DateTime(nullable: false));
            AddColumn("dbo.CIMASTs", "CUSID", c => c.Int(nullable: false));
            DropColumn("dbo.CIMASTs", "KhiDenHan");
            DropColumn("dbo.CIMASTs", "TraLai");
            DropColumn("dbo.CIMASTs", "BANK");
            DropColumn("dbo.CIMASTs", "NPTERM");
        }
    }
}
