namespace SampleWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_db : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GenerateLinkEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        URL = c.String(nullable: false),
                        ShortenedURL = c.String(nullable: false),
                        Token = c.String(nullable: false),
                        Clicked = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.GenerateLinkDtoes");
        }
        
        public override void Down()
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
            
            DropTable("dbo.GenerateLinkEntities");
        }
    }
}
