namespace FrameTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Complete : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        AreaID = c.Int(nullable: false, identity: true),
                        AreaName = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        AreaEnName = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        CityID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AreaID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Areas");
        }
    }
}
