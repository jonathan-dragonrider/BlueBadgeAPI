namespace BlueBadgeAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedProperty : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Projects", "UserId", "dbo.Users");
            DropIndex("dbo.Projects", new[] { "UserId" });
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "About", c => c.String());
            AlterColumn("dbo.Projects", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Projects", "UserId");
            AddForeignKey("dbo.Projects", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Projects", new[] { "UserId" });
            AlterColumn("dbo.Projects", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "About");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            CreateIndex("dbo.Projects", "UserId");
            AddForeignKey("dbo.Projects", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
    }
}
