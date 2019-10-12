namespace MoneyLover.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sad : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CIMASTs", "TraLai", c => c.String());
            AlterColumn("dbo.CIMASTs", "KhiDenHan", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CIMASTs", "KhiDenHan", c => c.Double(nullable: false));
            AlterColumn("dbo.CIMASTs", "TraLai", c => c.Int(nullable: false));
        }
    }
}
