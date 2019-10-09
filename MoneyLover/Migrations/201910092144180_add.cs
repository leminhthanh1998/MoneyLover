namespace MoneyLover.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        email = c.String(nullable: false, maxLength: 128),
                        pass = c.String(),
                    })
                .PrimaryKey(t => t.email);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
