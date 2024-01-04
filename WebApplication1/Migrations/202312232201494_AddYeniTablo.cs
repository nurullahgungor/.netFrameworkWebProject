namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddYeniTablo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.cityGraphs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        sehir_adi = c.String(),
                        sehir_veri = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.cityGraphs");
        }
    }
}
