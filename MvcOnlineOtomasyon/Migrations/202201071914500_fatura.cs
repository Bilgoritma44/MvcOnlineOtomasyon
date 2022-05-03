namespace MvcOnlineOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fatura : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Faturas", "SumPrice", c => c.String());
            AlterColumn("dbo.Faturas", "FaturaHour", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Faturas", "FaturaHour", c => c.DateTime(nullable: false));
            DropColumn("dbo.Faturas", "SumPrice");
        }
    }
}
