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

            [Theory]
            [InlineData("+5 Dexterity Vest")]
            [InlineData("Elixir of the Mongoose")]
            public void RegularItem_SellIn_DecreasesByOne(string itemName)
            {
                var regularItem = new Item { Name = itemName, Quality = 3, SellIn = 2 };
                app.Items = new List<Item> { regularItem };

                app.UpdateQuality();

                Assert.Equal(1, regularItem.SellIn);
            }
        
            [Theory]
            [InlineData("+5 Dexterity Vest")]
            [InlineData("Elixir of the Mongoose")]
            public void RegularItem_QualityDecreasesByOne_WhenSellInPositive(string itemName)
            {
                var regularItem = new Item { Name = itemName, Quality = 3, SellIn = 2 };
                app.Items = new List<Item> { regularItem };

                app.UpdateQuality();

                Assert.Equal(2, regularItem.Quality);
            }

            [Theory]
            [InlineData("+5 Dexterity Vest")]
            [InlineData("Elixir of the Mongoose")]
            public void RegularItem_QualityDecreasesByTwo_WhenSellInZero(string itemName)
            {
                var regularItem = new Item { Name = itemName, Quality = 3, SellIn = 0 };
                app.Items = new List<Item> { regularItem };

                app.UpdateQuality();

                Assert.Equal(1, regularItem.Quality);
            }
            
            [Theory]
            [InlineData("+5 Dexterity Vest")]
            [InlineData("Elixir of the Mongoose")]
            public void RegularItem_QualityDecreasesByTwo_WhenSellInNegative(string itemName)
            {
                var regularItem = new Item { Name = itemName, Quality = 3, SellIn = -1 };
                app.Items = new List<Item> { regularItem };

                app.UpdateQuality();

                Assert.Equal(1, regularItem.Quality);
            }

            [Theory]
            [InlineData("+5 Dexterity Vest")]
            [InlineData("Elixir of the Mongoose")]
            public void RegularItem_MinimumQuality_IsZero(string itemName)
            {
                var regularItem = new Item { Name = itemName, Quality = 1, SellIn = -1 };
                app.Items = new List<Item> { regularItem };

                app.UpdateQuality();

                Assert.Equal(0, regularItem.Quality);
            }
        }

        public class AgedBrieItemsTests
        {
            public Program app;
            public AgedBrieItemsTests()
            {
                app = new Program { };
            }

            [Fact]
            public void AgedBrieItem_SellIn_DecreasesByOne()
            {
                var agedBrieItem = new Item { Name = "Aged Brie", Quality = 3, SellIn = 2 };
                app.Items = new List<Item> { agedBrieItem };

                app.UpdateQuality();

                Assert.Equal(1, agedBrieItem.SellIn);
            }

            [Fact]
            public void AgedBrieItem_QualityIncreasesByOne_WhenSellInPositive()
            {
                var agedBrieItem = new Item { Name = "Aged Brie", Quality = 3, SellIn = 2 };
                app.Items = new List<Item> { agedBrieItem };

                app.UpdateQuality();

                Assert.Equal(4, agedBrieItem.Quality);
            }

            [Fact]
            public void AgedBrieItem_QualityIncreasesByTwo_WhenSellInZero()
            {
                var agedBrieItem = new Item { Name = "Aged Brie", Quality = 3, SellIn = 0 };
                app.Items = new List<Item> { agedBrieItem };

                app.UpdateQuality();

                Assert.Equal(5, agedBrieItem.Quality);
            }
            
            [Fact]
            public void AgedBrieItem_QualityIncreasesByTwo_WhenSellInNegative()
            {
                var agedBrieItem = new Item { Name = "Aged Brie", Quality = 3, SellIn = -1 };
                app.Items = new List<Item> { agedBrieItem };

                app.UpdateQuality();

                Assert.Equal(5, agedBrieItem.Quality);
            }            

            [Fact]
            public void AgedBrieItem_MaxQuality_IsFifty()
            {
                var agedBrieItem = new Item { Name = "Aged Brie", Quality = 49, SellIn = -2 };
                app.Items = new List<Item> { agedBrieItem };

                app.UpdateQuality();

                Assert.Equal(50, agedBrieItem.Quality);
            }            
        }

        public class BackstagePassTests
        {
            public Program app;
            public BackstagePassTests()
            {
                app = new Program { };
            }

            [Fact]
            public void BackstagePassItem_SellIn_DecreasesByOne()
            {
                var backstagePassItem = new Item { Name = "Backstage passes to a TAFKAL80ETC concert",  Quality = 3, SellIn = 2 };
                app.Items = new List<Item> { backstagePassItem };

                app.UpdateQuality();

                Assert.Equal(1, backstagePassItem.SellIn);
            }
            
            [Fact]
            public void BackstagePassItem_QualityIsZero_WhenSellInZero()
            {
                var backstagePassItem = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 10, SellIn = 0 };
                app.Items = new List<Item> { backstagePassItem };

                app.UpdateQuality();

                Assert.Equal(0, backstagePassItem.Quality);
            }
            
            [Fact]
            public void BackstagePassItem_QualityIsZero_WhenSellInNegative()
            {
                var backstagePassItem = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 10, SellIn = -1 };
                app.Items = new List<Item> { backstagePassItem };

                app.UpdateQuality();

                Assert.Equal(0, backstagePassItem.Quality);
            }

            [Theory]
            [InlineData(1, 1, 4)]
            [InlineData(1, 2, 4)]
            [InlineData(1, 3, 4)]
            [InlineData(1, 4, 4)]
            [InlineData(1, 5, 4)]
            public void BackstagePassItem_QualityIncreasesByThree_WhenSellInBetweenOneAndFive(int quality, int sellIn, int expected)
            {
                var backstagePassItem = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = quality, SellIn = sellIn };
                app.Items = new List<Item> { backstagePassItem };

                app.UpdateQuality();

                Assert.Equal(expected, backstagePassItem.Quality);
            }
            
            [Theory]
            [InlineData(1, 6, 3)]
            [InlineData(1, 7, 3)]
            [InlineData(1, 8, 3)]
            [InlineData(1, 9, 3)]
            [InlineData(1, 10, 3)]
            public void BackstagePassItem_QualityIncreasesByTwo_WhenSellInBetweenSixAndTen(int quality, int sellIn, int expected)
            {
                var backstagePassItem =  new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = quality, SellIn = sellIn};
                app.Items = new List<Item> { backstagePassItem };

                app.UpdateQuality();

                Assert.Equal(expected, backstagePassItem.Quality);
            }
            
            [Theory]
            [InlineData(1, 11, 2)]
            [InlineData(1, 12, 2)]
            [InlineData(1, 13, 2)]
            public void BackstagePassItem_QualityIncreasesByOne_WhenSellInElevenOrGreater(int quality, int sellIn, int expected)
            {
                var backstagePassItem = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = quality, SellIn = sellIn };
                app.Items = new List<Item> { backstagePassItem };

                app.UpdateQuality();
                
                Assert.Equal(expected, backstagePassItem.Quality);
            }
            
            [Fact]
            public void BackstagePassItem_MaxQuality_IsFifty()
            {
                var backstagePassItem = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 49, SellIn = 2 };
                app.Items = new List<Item> { backstagePassItem };

                app.UpdateQuality();

                Assert.Equal(50, backstagePassItem.Quality);
            }
        }
        
        public class ConjuredItemsTests
        {
            public Program app;
            public ConjuredItemsTests()
            {
                app = new Program { };
            }

            [Fact]
            public void ConjuredItem_SellIn_DecreasesByOne()
            {
                var conjuredItem = new Item { Name = "Conjured Mana Cake", Quality = 3, SellIn = 2 };
                app.Items = new List<Item> { conjuredItem };

                app.UpdateQuality();

                Assert.Equal(1, conjuredItem.SellIn);

            }

            [Fact]
            public void ConjuredItems_QualityDecreasesByTwo_WhenSellInPositive()
            {
                var conjuredItem = new Item { Name = "Conjured Mana Cake", Quality = 5, SellIn = 1 };
                app.Items = new List<Item> { conjuredItem };

                app.UpdateQuality();

                Assert.Equal(3, conjuredItem.Quality);
            }

            [Fact]
            public void ConjuredItems_QualityDecreasesByFour_WhenSellInZero()
            {
                var conjuredItem = new Item { Name = "Conjured Mana Cake", Quality = 5, SellIn = 0 };
                app.Items = new List<Item> { conjuredItem };

                app.UpdateQuality();

                Assert.Equal(1, conjuredItem.Quality);
            }
            
            [Fact]
            public void ConjuredItems_QualityDecreasesByFour_WhenSellInNegative()
            {
                var conjuredItem = new Item { Name = "Conjured Mana Cake", Quality = 5, SellIn = -1 };
                app.Items = new List<Item> { conjuredItem };

                app.UpdateQuality();

                Assert.Equal(1, conjuredItem.Quality);
            }

            [Fact]
            public void ConjuredItem_MinimumQuality_IsZero()
            {
                var conjuredItem = new Item { Name = "Conjured Mana Cake", Quality = 1, SellIn = -3 };
                app.Items = new List<Item> { conjuredItem };

                app.UpdateQuality();

                Assert.Equal(0, conjuredItem.Quality);
            }
        }
    }
}
