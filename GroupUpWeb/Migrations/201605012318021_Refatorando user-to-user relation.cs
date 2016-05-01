namespace GroupUpWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Refatorandousertouserrelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TB_UserUser", "FirstUserId", "dbo.TB_User");
            DropForeignKey("dbo.TB_UserUser", "SecondUserId", "dbo.TB_User");
            DropIndex("dbo.TB_UserUser", new[] { "FirstUserId" });
            DropIndex("dbo.TB_UserUser", new[] { "SecondUserId" });
            CreateTable(
                "dbo.TB_UserFriends",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        FriendID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TB_User", t => t.FriendID)
                .ForeignKey("dbo.TB_User", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.FriendID);
            
            DropTable("dbo.TB_UserUser");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TB_UserUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstUserId = c.Int(nullable: false),
                        SecondUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.TB_UserFriends", "UserID", "dbo.TB_User");
            DropForeignKey("dbo.TB_UserFriends", "FriendID", "dbo.TB_User");
            DropIndex("dbo.TB_UserFriends", new[] { "FriendID" });
            DropIndex("dbo.TB_UserFriends", new[] { "UserID" });
            DropTable("dbo.TB_UserFriends");
            CreateIndex("dbo.TB_UserUser", "SecondUserId");
            CreateIndex("dbo.TB_UserUser", "FirstUserId");
            AddForeignKey("dbo.TB_UserUser", "SecondUserId", "dbo.TB_User", "Id");
            AddForeignKey("dbo.TB_UserUser", "FirstUserId", "dbo.TB_User", "Id");
        }
    }
}
