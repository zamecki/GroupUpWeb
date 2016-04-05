namespace GroupUpWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TB_Group",
                c => new
                    {
                        iId = c.Int(nullable: false, identity: true),
                        title = c.String(nullable: false, maxLength: 150),
                        description = c.String(maxLength: 250),
                        owner_id = c.Int(nullable: false),
                        creation_date = c.DateTime(nullable: false),
                        last_update_date = c.DateTime(),
                    })
                .PrimaryKey(t => t.iId)
                .ForeignKey("dbo.TB_User", t => t.owner_id, cascadeDelete: true)
                .Index(t => t.owner_id);
            
            CreateTable(
                "dbo.TB_User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        fbid = c.String(nullable: false, maxLength: 150),
                        sing_date = c.DateTime(nullable: false),
                        last_login_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TB_GroupUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TB_Group", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.TB_User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_GroupUser", "UserId", "dbo.TB_User");
            DropForeignKey("dbo.TB_GroupUser", "GroupId", "dbo.TB_Group");
            DropForeignKey("dbo.TB_Group", "owner_id", "dbo.TB_User");
            DropIndex("dbo.TB_GroupUser", new[] { "UserId" });
            DropIndex("dbo.TB_GroupUser", new[] { "GroupId" });
            DropIndex("dbo.TB_Group", new[] { "owner_id" });
            DropTable("dbo.TB_GroupUser");
            DropTable("dbo.TB_User");
            DropTable("dbo.TB_Group");
        }
    }
}
