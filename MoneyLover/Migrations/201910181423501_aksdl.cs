namespace MoneyLover.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aksdl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GUITHEMs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        STK = c.Int(nullable: false),
                        SoTienGui = c.Double(nullable: false),
                        NgayGui = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GUITHEMs");
        }
    }
}
