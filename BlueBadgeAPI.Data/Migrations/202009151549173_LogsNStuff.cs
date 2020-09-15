namespace BlueBadgeAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LogsNStuff : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Log",
                c => new
                    {
                        LogId = c.Int(nullable: false, identity: true),
                        WhatHappened = c.String(),
                    })
                .PrimaryKey(t => t.LogId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Log");
        }
    }
}
