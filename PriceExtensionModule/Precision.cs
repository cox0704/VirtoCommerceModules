using System;
using System.Data.Entity;
using System.Linq;

namespace PriceExtensionModule
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class Precision : Attribute
	{
		public byte TotalDigits { get; set; }

		public byte Scale { get; set; }

		public Precision(byte precision, byte scale)
		{
			TotalDigits = precision;
			Scale = scale;
		}

		public static void ConfigureModelBuilder(DbModelBuilder modelBuilder)
		{
			modelBuilder.Properties().Where(x => x.GetCustomAttributes(false).OfType<Precision>().Any())
                .Configure(c => c.HasPrecision(c.ClrPropertyInfo.GetCustomAttributes(false).OfType<Precision>().First()
                    .TotalDigits, c.ClrPropertyInfo.GetCustomAttributes(false).OfType<Precision>().First().Scale));
		}
	}	
}