namespace MvcOnlineOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fatura2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Faturas", "SumPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Faturas", "SumPrice", c => c.String());
        }
    }
}
