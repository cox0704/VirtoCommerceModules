namespace CatalogModuleExtensions.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CatalogAliasExtensionMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CatalogModuleExtension",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CategoryAlias = c.String(nullable: false, maxLength: 64),
                        CategoryAliasPath = c.String(nullable: false, maxLength: 2000),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.CategoryAlias, unique: true)
                .Index(t => t.CategoryAliasPath, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CatalogModuleExtension", "Id", "dbo.Category");

            DropIndex("dbo.CatalogModuleExtension", new[] { "CategoryAliasPath" });
            DropIndex("dbo.CatalogModuleExtension", new[] { "CategoryAlias" });
            DropIndex("dbo.CatalogModuleExtension", new[] { "Id" });
            
            DropTable("dbo.CatalogModuleExtension");
        }
    }
}
