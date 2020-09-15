namespace BlueBadgeAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMigrtionLogAdd : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Project", "Title", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Project", "Title", c => c.String(nullable: false));
        }
    }
}
