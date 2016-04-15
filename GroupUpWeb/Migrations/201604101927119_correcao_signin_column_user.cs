namespace GroupUpWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correcao_signin_column_user : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.TB_User", name: "sing_date", newName: "signin_date");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.TB_User", name: "signin_date", newName: "sing_date");
        }
    }
}
