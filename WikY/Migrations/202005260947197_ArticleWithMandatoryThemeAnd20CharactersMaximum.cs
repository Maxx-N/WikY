namespace WikY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArticleWithMandatoryThemeAnd20CharactersMaximum : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Articles", "Theme", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Articles", "Theme", c => c.String());
        }
    }
}
