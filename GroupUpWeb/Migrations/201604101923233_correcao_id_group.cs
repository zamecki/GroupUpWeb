namespace GroupUpWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correcao_id_group : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.TB_Group", name: "iId", newName: "Id");
            AddColumn("dbo.TB_User", "Name", c => c.String());
            AddColumn("dbo.TB_User", "LastName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TB_User", "LastName");
            DropColumn("dbo.TB_User", "Name");
            RenameColumn(table: "dbo.TB_Group", name: "Id", newName: "iId");
        }
    }
}
