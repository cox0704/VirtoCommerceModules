namespace PriceExtensionModule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PriceExtension",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ErpListPrice = c.Decimal(precision: 18, scale: 4),
                        ErpSalePrice = c.Decimal(precision: 18, scale: 4),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Price", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);

	        Sql("INSERT INTO dbo.PriceExtension (Id, ErpSalePrice, ErpListPrice) SELECT Id, 0.0000, 0.0000 FROM dbo.Price");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PriceExtension", "Id", "dbo.Price");
            DropIndex("dbo.PriceExtension", new[] { "Id" });
            DropTable("dbo.PriceExtension");
        }
    }
}
