namespace PersonalLogger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLogsToPersonalUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MyLogs", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.MyLogs", "ApplicationUser_Id");
            AddForeignKey("dbo.MyLogs", "ApplicationUser_Id", "dbo.AspNetUsers", "Id",cascadeDelete:true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MyLogs", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.MyLogs", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.MyLogs", "ApplicationUser_Id");
        }
    }
}
