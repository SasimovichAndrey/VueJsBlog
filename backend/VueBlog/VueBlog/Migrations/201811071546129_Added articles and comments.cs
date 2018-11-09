namespace VueBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedarticlesandcomments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogArticles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(unicode: false),
                        PreviewContent = c.String(unicode: false),
                        Content = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ArticleComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArticleId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128, storeType: "nvarchar"),
                        Content = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.BlogArticles", t => t.ArticleId, cascadeDelete: true)
                .Index(t => t.ArticleId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArticleComments", "ArticleId", "dbo.BlogArticles");
            DropForeignKey("dbo.ArticleComments", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.ArticleComments", new[] { "UserId" });
            DropIndex("dbo.ArticleComments", new[] { "ArticleId" });
            DropTable("dbo.ArticleComments");
            DropTable("dbo.BlogArticles");
        }
    }
}
