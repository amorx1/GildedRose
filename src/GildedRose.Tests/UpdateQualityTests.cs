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

        public class RegularItemsTests
        {
            public Program app;
            public RegularItemsTests()
            {
                app = new Program { };
            }

            [Fact]
            public void RegularItem_SellIn_DecreasesByOne()
            {
                var regularItem = new Item { Name = "+5 Dexterity Vest", Quality = 3, SellIn = 2 };
                app.Items = new List<Item> { regularItem };

                app.UpdateQuality();

                Assert.Equal(1, regularItem.SellIn);
            }
        
            [Fact]
            public void RegularItem_QualityDecreasesByOne_WhenSellInPositive()
            {
                var regularItem = new Item { Name = "+5 Dexterity Vest", Quality = 3, SellIn = 2 };
                app.Items = new List<Item> { regularItem };

                app.UpdateQuality();

                Assert.Equal(2, regularItem.Quality);
            }

            [Fact]
            public void RegularItem_QualityDecreasesByTwo_WhenSellInZero()
            {
                var regularItem = new Item { Name = "+5 Dexterity Vest", Quality = 3, SellIn = 0 };
                app.Items = new List<Item> { regularItem };

                app.UpdateQuality();

                Assert.Equal(1, regularItem.Quality);
            }
            
            [Fact]
            public void RegularItem_QualityDecreasesByTwo_WhenSellInNegative()
            {
                var regularItem = new Item { Name = "+5 Dexterity Vest", Quality = 3, SellIn = -1 };
                app.Items = new List<Item> { regularItem };

                app.UpdateQuality();

                Assert.Equal(1, regularItem.Quality);
            }

            [Fact]
            public void RegularItem_MinimumQuality_IsZero()
            {
                var regularItem = new Item { Name = "+5 Dexterity Vest", Quality = 1, SellIn = -1 };
                app.Items = new List<Item> { regularItem };

                app.UpdateQuality();

                Assert.Equal(0, regularItem.Quality);
            }
        }
    }
}
