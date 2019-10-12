namespace MoneyLover.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abcd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CITRANs",
                c => new
                    {
                        AUTOID = c.Int(nullable: false, identity: true),
                        ACCTNO = c.Int(nullable: false),
                        BKDATE = c.DateTime(nullable: false),
                        SoTienRut = c.Double(),
                        TienLai = c.Double(),
                    })
                .PrimaryKey(t => t.AUTOID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CITRANs");
        }
    }
}
