namespace PersonalLogger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategories : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LogCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CategoryFields",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FieldName = c.String(),
                        FieldType = c.String(),
                        LogCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LogCategories", t => t.LogCategory_Id)
                .Index(t => t.LogCategory_Id);
            
            AddColumn("dbo.MyLogs", "LogCategory_Id", c => c.Int());
            CreateIndex("dbo.MyLogs", "LogCategory_Id");
            AddForeignKey("dbo.MyLogs", "LogCategory_Id", "dbo.LogCategories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MyLogs", "LogCategory_Id", "dbo.LogCategories");
            DropForeignKey("dbo.CategoryFields", "LogCategory_Id", "dbo.LogCategories");
            DropIndex("dbo.MyLogs", new[] { "LogCategory_Id" });
            DropIndex("dbo.CategoryFields", new[] { "LogCategory_Id" });
            DropColumn("dbo.MyLogs", "LogCategory_Id");
            DropTable("dbo.CategoryFields");
            DropTable("dbo.LogCategories");
        }
    }
}
