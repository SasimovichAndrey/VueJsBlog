namespace VueBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updatearticlecommentmodel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("ArticleComments", "UserId", "AspNetUsers");
            DropIndex("ArticleComments", new[] { "UserId" });
            AddColumn("ArticleComments", "CommentatorName", c => c.String(unicode: false));
            DropColumn("ArticleComments", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("ArticleComments", "UserId", c => c.String(maxLength: 128, storeType: "nvarchar"));
            DropColumn("ArticleComments", "CommentatorName");
            CreateIndex("ArticleComments", "UserId");
            AddForeignKey("ArticleComments", "UserId", "AspNetUsers", "Id");
        }
    }
}
