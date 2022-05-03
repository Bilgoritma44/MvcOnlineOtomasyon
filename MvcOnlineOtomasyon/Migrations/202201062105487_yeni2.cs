namespace MvcOnlineOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yeni2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Personels", "PersonelStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Personels", "PersonelStatus");
        }
    }
}
