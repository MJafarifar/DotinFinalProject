namespace SampleWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intialize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GenerateLinkDtoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Link = c.String(nullable: false),
                        ShortLink = c.String(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GenerateLinkDtoes");
        }
    }
}
