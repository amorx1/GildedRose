using System.Collections.Generic;
using GildedRose.Console;
using Xunit;

namespace GildedRose.Tests
{
    public class UpdateQualityTests
    {
		public class SulfurasItemsTests
		{
            public Program app;
            public SulfurasItemsTests()
            {
                app = new Program { };
            }

	        [Fact]
            public void Sulfuras_Quality_DoesntChange()
            {
                var sulfurasItem = new Item { Name = "Sulfuras, Hand of Ragnaros", Quality = 80, SellIn = 0 };
                app.Items = new List<Item> { sulfurasItem };
                
                app.UpdateQuality();

                Assert.Equal(80, sulfurasItem.Quality);
            }

            [Fact]
            public void Sulfuras_SellIn_DoesntChange()
            {
                var sulfurasItem = new Item { Name = "Sulfuras, Hand of Ragnaros", Quality = 80, SellIn = 0 };
                app.Items = new List<Item> { sulfurasItem };

                app.UpdateQuality();
                
                Assert.Equal(0, sulfurasItem.SellIn);
            }
		}
    }
}
