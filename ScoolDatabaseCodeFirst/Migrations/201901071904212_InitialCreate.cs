namespace ScoolDatabaseCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.School",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        SchoolName = c.String(nullable: false, maxLength: 20, fixedLength: true),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 20, fixedLength: true),
                        LastName = c.String(nullable: false, maxLength: 20, fixedLength: true),
                        SchoolID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.School", t => t.SchoolID)
                .Index(t => t.SchoolID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Student", "SchoolID", "dbo.School");
            DropIndex("dbo.Student", new[] { "SchoolID" });
            DropTable("dbo.Student");
            DropTable("dbo.School");
        }
    }
}
