namespace BlueBadgeAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EvenMoreLoStuff : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Log", newName: "LogListItems");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.LogListItems", newName: "Log");
        }
    }
}
