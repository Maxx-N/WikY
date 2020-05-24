namespace WikY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MODIFY_NAME_OF_CREATIONDATE_PROPERTY_IN_ARTICLES : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "CreationDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Articles", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Articles", "MyProperty", c => c.DateTime(nullable: false));
            DropColumn("dbo.Articles", "CreationDate");
        }
    }
}
