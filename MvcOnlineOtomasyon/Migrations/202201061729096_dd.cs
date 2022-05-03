namespace MvcOnlineOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SalesMoves", "Personel_PersonelId", "dbo.Personels");
            DropIndex("dbo.SalesMoves", new[] { "Personel_PersonelId" });
            RenameColumn(table: "dbo.SalesMoves", name: "Personel_PersonelId", newName: "PersonelId");
            AlterColumn("dbo.SalesMoves", "PersonelId", c => c.Int(nullable: false));
            CreateIndex("dbo.SalesMoves", "PersonelId");
            AddForeignKey("dbo.SalesMoves", "PersonelId", "dbo.Personels", "PersonelId", cascadeDelete: true);
            DropColumn("dbo.SalesMoves", "Personeld");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SalesMoves", "Personeld", c => c.Int(nullable: false));
            DropForeignKey("dbo.SalesMoves", "PersonelId", "dbo.Personels");
            DropIndex("dbo.SalesMoves", new[] { "PersonelId" });
            AlterColumn("dbo.SalesMoves", "PersonelId", c => c.Int());
            RenameColumn(table: "dbo.SalesMoves", name: "PersonelId", newName: "Personel_PersonelId");
            CreateIndex("dbo.SalesMoves", "Personel_PersonelId");
            AddForeignKey("dbo.SalesMoves", "Personel_PersonelId", "dbo.Personels", "PersonelId");
        }
    }
}
