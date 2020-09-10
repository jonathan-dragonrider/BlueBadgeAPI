namespace BlueBadgeAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedAssignment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Assignments", "UserId", "dbo.Users");
            DropIndex("dbo.Assignments", new[] { "UserId" });
            AlterColumn("dbo.Assignments", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Assignments", "UserId");
            AddForeignKey("dbo.Assignments", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Assignments", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Assignments", new[] { "UserId" });
            AlterColumn("dbo.Assignments", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Assignments", "UserId");
            AddForeignKey("dbo.Assignments", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
    }
}
