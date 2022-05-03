namespace MvcOnlineOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class todolist2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TodoLists",
                c => new
                    {
                        TodoListId = c.Int(nullable: false, identity: true),
                        Topic = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TodoListId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TodoLists");
        }
    }
}
