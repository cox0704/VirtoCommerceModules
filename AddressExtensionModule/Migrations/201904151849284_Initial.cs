namespace AddressExtensionModule.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class Initial : DbMigration
	{
		public override void Up()
		{
			CreateTable(
				"dbo.AddressShippingExtension",
				c => new
				{
					Id = c.String(nullable: false, maxLength: 128),
					SplitShipments = c.Boolean(nullable: false),
					FulfillmentMethod = c.Int(nullable: false),
					PreferredCarrier = c.String(),
					DefaultPickupLocation = c.String(),
				})
				.PrimaryKey(t => t.Id)
				.ForeignKey("dbo.Address", t => t.Id)
				.Index(t => t.Id);

			Sql("INSERT INTO dbo.AddressShippingExtension (Id, SplitShipments, FulfillmentMethod) SELECT Id, 0, 0 FROM dbo.Address");
		}

		public override void Down()
		{
			DropForeignKey("dbo.AddressShippingExtension", "Id", "dbo.Address");
			DropIndex("dbo.AddressShippingExtension", new[] { "Id" });
			DropTable("dbo.AddressShippingExtension");
		}
	}
}
