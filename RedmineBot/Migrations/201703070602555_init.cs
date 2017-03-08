namespace RedmineBot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "issues",
                c => new
                    {
                        issueid = c.Int(nullable: false, identity: true),
                        title = c.String(maxLength: 1000, unicode: false),
                        description = c.String(maxLength: 1000, unicode: false),
                        started = c.DateTime(precision: 0),
                        duedate = c.DateTime(precision: 0),
                        priority = c.Int(nullable: false),
                        ismuted = c.Boolean(nullable: false, storeType: "bit"),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.issueid)
                .ForeignKey("users", t => t.User_UserId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "redmines",
                c => new
                    {
                        remineid = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 1000, unicode: false),
                        url = c.String(maxLength: 1000, unicode: false),
                        password = c.String(maxLength: 1000, unicode: false),
                        login = c.String(maxLength: 1000, unicode: false),
                    })
                .PrimaryKey(t => t.remineid);
            
            CreateTable(
                "users",
                c => new
                    {
                        userid = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 1000, unicode: false),
                        apikey = c.String(maxLength: 1000, unicode: false),
                    })
                .PrimaryKey(t => t.userid);
            
            CreateTable(
                "UserRedmines",
                c => new
                    {
                        User_UserId = c.Int(nullable: false),
                        Redmine_RedmineId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_UserId, t.Redmine_RedmineId })
                .ForeignKey("users", t => t.User_UserId, cascadeDelete: true)
                .ForeignKey("redmines", t => t.Redmine_RedmineId, cascadeDelete: true)
                .Index(t => t.User_UserId)
                .Index(t => t.Redmine_RedmineId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("UserRedmines", "Redmine_RedmineId", "redmines");
            DropForeignKey("UserRedmines", "User_UserId", "users");
            DropForeignKey("issues", "User_UserId", "users");
            DropIndex("UserRedmines", new[] { "Redmine_RedmineId" });
            DropIndex("UserRedmines", new[] { "User_UserId" });
            DropIndex("issues", new[] { "User_UserId" });
            DropTable("UserRedmines");
            DropTable("users");
            DropTable("redmines");
            DropTable("issues");
        }
    }
}
