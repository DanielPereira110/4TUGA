namespace _4Tuga.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Files : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FilePaths", "Person_Id", "dbo.AspNetUsers");
            DropIndex("dbo.FilePaths", new[] { "Person_Id" });
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        PersonId = c.Int(nullable: false),
                        Person_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.Person_Id)
                .Index(t => t.Person_Id);
            
            DropTable("dbo.FilePaths");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FilePaths",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        FileType = c.Int(nullable: false),
                        PersonID = c.Int(nullable: false),
                        Person_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID);
            
            DropForeignKey("dbo.Files", "Person_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Files", new[] { "Person_Id" });
            DropTable("dbo.Files");
            CreateIndex("dbo.FilePaths", "Person_Id");
            AddForeignKey("dbo.FilePaths", "Person_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
