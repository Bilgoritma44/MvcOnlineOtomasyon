namespace MvcOnlineOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fatura3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FaturaKalems", "Fatura_FaturaId", "dbo.Faturas");
            DropIndex("dbo.FaturaKalems", new[] { "Fatura_FaturaId" });
            RenameColumn(table: "dbo.FaturaKalems", name: "Fatura_FaturaId", newName: "FaturaId");
            AlterColumn("dbo.FaturaKalems", "FaturaId", c => c.Int(nullable: false));
            CreateIndex("dbo.FaturaKalems", "FaturaId");
            AddForeignKey("dbo.FaturaKalems", "FaturaId", "dbo.Faturas", "FaturaId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FaturaKalems", "FaturaId", "dbo.Faturas");
            DropIndex("dbo.FaturaKalems", new[] { "FaturaId" });
            AlterColumn("dbo.FaturaKalems", "FaturaId", c => c.Int());
            RenameColumn(table: "dbo.FaturaKalems", name: "FaturaId", newName: "Fatura_FaturaId");
            CreateIndex("dbo.FaturaKalems", "Fatura_FaturaId");
            AddForeignKey("dbo.FaturaKalems", "Fatura_FaturaId", "dbo.Faturas", "FaturaId");
        }
    }
}
