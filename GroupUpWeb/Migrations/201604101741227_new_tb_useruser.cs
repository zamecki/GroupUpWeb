namespace GroupUpWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_tb_useruser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TB_Group", "owner_id", "dbo.TB_User");
            DropForeignKey("dbo.TB_GroupUser", "GroupId", "dbo.TB_Group");
            DropForeignKey("dbo.TB_GroupUser", "UserId", "dbo.TB_User");
            CreateTable(
                "dbo.TB_UserUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstUserId = c.Int(nullable: false),
                        SecondUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TB_User", t => t.FirstUserId)
                .ForeignKey("dbo.TB_User", t => t.SecondUserId)
                .Index(t => t.FirstUserId)
                .Index(t => t.SecondUserId);
            
            AddForeignKey("dbo.TB_Group", "owner_id", "dbo.TB_User", "Id");
            AddForeignKey("dbo.TB_GroupUser", "GroupId", "dbo.TB_Group", "iId");
            AddForeignKey("dbo.TB_GroupUser", "UserId", "dbo.TB_User", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_GroupUser", "UserId", "dbo.TB_User");
            DropForeignKey("dbo.TB_GroupUser", "GroupId", "dbo.TB_Group");
            DropForeignKey("dbo.TB_Group", "owner_id", "dbo.TB_User");
            DropForeignKey("dbo.TB_UserUser", "SecondUserId", "dbo.TB_User");
            DropForeignKey("dbo.TB_UserUser", "FirstUserId", "dbo.TB_User");
            DropIndex("dbo.TB_UserUser", new[] { "SecondUserId" });
            DropIndex("dbo.TB_UserUser", new[] { "FirstUserId" });
            DropTable("dbo.TB_UserUser");
            AddForeignKey("dbo.TB_GroupUser", "UserId", "dbo.TB_User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TB_GroupUser", "GroupId", "dbo.TB_Group", "iId", cascadeDelete: true);
            AddForeignKey("dbo.TB_Group", "owner_id", "dbo.TB_User", "Id", cascadeDelete: true);
        }
    }
}
