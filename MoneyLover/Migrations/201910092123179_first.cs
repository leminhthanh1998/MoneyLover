namespace MoneyLover.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AllCodes",
                c => new
                    {
                        CDTYPE = c.String(nullable: false, maxLength: 128),
                        CDNAME = c.String(nullable: false, maxLength: 128),
                        CDVAL = c.String(nullable: false, maxLength: 128),
                        CDCONTENT = c.String(),
                        EN_CDCONTENT = c.String(),
                        LSTODR = c.Int(nullable: false),
                        CDUSER = c.String(),
                    })
                .PrimaryKey(t => new { t.CDTYPE, t.CDNAME, t.CDVAL });
            
            CreateTable(
                "dbo.BRANCHes",
                c => new
                    {
                        BRID = c.Int(nullable: false, identity: true),
                        BRName = c.String(),
                        Address = c.String(),
                        REPRESENTATIVE = c.Int(),
                        Phone = c.Int(nullable: false),
                        Mail = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.BRID);
            
            CreateTable(
                "dbo.CALENDARs",
                c => new
                    {
                        AUTOID = c.Int(nullable: false, identity: true),
                        SBDATE = c.DateTime(nullable: false),
                        CLDRTYPE = c.String(),
                        ISHOLIDAY = c.String(),
                    })
                .PrimaryKey(t => t.AUTOID);
            
            CreateTable(
                "dbo.CFIMAGEs",
                c => new
                    {
                        USIMGID = c.Int(nullable: false, identity: true),
                        CUSID = c.Int(nullable: false),
                        FTIMGURL = c.String(),
                        BKIMGURL = c.String(),
                        FGIMGURL = c.String(),
                        FRDATE = c.DateTime(nullable: false),
                        TODATE = c.DateTime(nullable: false),
                        STATUS = c.String(),
                    })
                .PrimaryKey(t => t.USIMGID);
            
            CreateTable(
                "dbo.CFMASTs",
                c => new
                    {
                        CUSID = c.Int(nullable: false, identity: true),
                        FULLNAME = c.String(),
                        SEX = c.String(),
                        DOB = c.DateTime(nullable: false),
                        COUNTRY = c.String(),
                        IDCODE = c.String(),
                        IDPLACE = c.String(),
                        IDDATE = c.DateTime(nullable: false),
                        IDTYPE = c.String(),
                        ADDRESS = c.String(),
                        MAIL = c.String(),
                        FAX = c.Int(nullable: false),
                        TAXCODE = c.Int(nullable: false),
                        PHONE = c.Int(nullable: false),
                        BRID = c.Int(nullable: false),
                        STATUS = c.String(),
                    })
                .PrimaryKey(t => t.CUSID);
            
            CreateTable(
                "dbo.CIINTTRANs",
                c => new
                    {
                        AUTOID = c.Int(nullable: false, identity: true),
                        INTBAL = c.Double(),
                        IRRATE = c.Double(nullable: false),
                        TODATE = c.DateTime(nullable: false),
                        FRDATE = c.DateTime(nullable: false),
                        INTTYPE = c.String(),
                        ACCTNO = c.Int(nullable: false),
                        INTMANT = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.AUTOID);
            
            CreateTable(
                "dbo.CIMASTs",
                c => new
                    {
                        ACCTNO = c.Int(nullable: false, identity: true),
                        CUSID = c.Int(nullable: false),
                        DEPOSITAMT = c.Double(),
                        PDID = c.Int(nullable: false),
                        INTEREST = c.Double(nullable: false),
                        FRDATE = c.DateTime(nullable: false),
                        TODATE = c.DateTime(nullable: false),
                        ISBLOCKED = c.Int(nullable: false),
                        BLOCKEDAMT = c.Double(nullable: false),
                        INCREASEINT = c.Double(nullable: false),
                        STATUS = c.String(),
                    })
                .PrimaryKey(t => t.ACCTNO);
            
            CreateTable(
                "dbo.CIPRODUCTs",
                c => new
                    {
                        PDID = c.Int(nullable: false, identity: true),
                        NAME = c.String(),
                        MAX = c.Int(nullable: false),
                        MIN = c.Int(nullable: false),
                        Type = c.String(),
                        PTERM = c.Int(nullable: false),
                        NPTERM = c.Int(nullable: false),
                        RATE = c.Double(nullable: false),
                        PDRATE = c.Double(nullable: false),
                        NPPAYDATE = c.DateTime(nullable: false),
                        EFFECTDATE = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PDID);
            
            CreateTable(
                "dbo.DEPARTMENTEs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Phone = c.Int(nullable: false),
                        Mail = c.String(),
                        BRID = c.Int(nullable: false),
                        TLID = c.Int(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TLLOGS",
                c => new
                    {
                        AUTOID = c.Int(nullable: false, identity: true),
                        OFFTIME = c.String(),
                        MSGACCT = c.String(),
                        MSGAMT = c.Int(nullable: false),
                        TXSTATUS = c.String(),
                        WSNAME = c.String(),
                        IPADDRESS = c.String(),
                        TXDESC = c.String(),
                        BUSDATE = c.DateTime(nullable: false),
                        DELTD = c.String(),
                        TLTXCD = c.String(),
                        CHID = c.String(),
                        TLID = c.Int(nullable: false),
                        BRID = c.Int(nullable: false),
                        TXTIME = c.String(),
                        TXDATE = c.DateTime(),
                        TXNUM = c.String(),
                    })
                .PrimaryKey(t => t.AUTOID);
            
            CreateTable(
                "dbo.TLPROFILEs",
                c => new
                    {
                        TLID = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Sex = c.String(),
                        Mail = c.String(),
                        Phone = c.Int(nullable: false),
                        DepartmentID = c.Int(nullable: false),
                        Address = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.TLID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TLPROFILEs");
            DropTable("dbo.TLLOGS");
            DropTable("dbo.DEPARTMENTEs");
            DropTable("dbo.CIPRODUCTs");
            DropTable("dbo.CIMASTs");
            DropTable("dbo.CIINTTRANs");
            DropTable("dbo.CFMASTs");
            DropTable("dbo.CFIMAGEs");
            DropTable("dbo.CALENDARs");
            DropTable("dbo.BRANCHes");
            DropTable("dbo.AllCodes");
        }
    }
}
