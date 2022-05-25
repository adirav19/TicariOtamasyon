namespace TicariOtamasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deparmani : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Personels", "Departman_DepartmanID", "dbo.Departmen");
            DropIndex("dbo.Personels", new[] { "Departman_DepartmanID" });
            RenameColumn(table: "dbo.Personels", name: "Departman_DepartmanID", newName: "Departmanid");
            AlterColumn("dbo.Personels", "Departmanid", c => c.Int(nullable: false));
            CreateIndex("dbo.Personels", "Departmanid");
            AddForeignKey("dbo.Personels", "Departmanid", "dbo.Departmen", "DepartmanID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Personels", "Departmanid", "dbo.Departmen");
            DropIndex("dbo.Personels", new[] { "Departmanid" });
            AlterColumn("dbo.Personels", "Departmanid", c => c.Int());
            RenameColumn(table: "dbo.Personels", name: "Departmanid", newName: "Departman_DepartmanID");
            CreateIndex("dbo.Personels", "Departman_DepartmanID");
            AddForeignKey("dbo.Personels", "Departman_DepartmanID", "dbo.Departmen", "DepartmanID");
        }
    }
}
