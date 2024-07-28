using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        public IList<Item> Items;
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
                          {
                              Items = new List<Item>
                                          {
                                              new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                                              new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                                              new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                                              new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                                              new Item
                                                  {
                                                      Name = "Backstage passes to a TAFKAL80ETC concert",
                                                      SellIn = 15,
                                                      Quality = 20
                                                  },
                                              new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                                          }

                          };

            app.UpdateQuality();

            System.Console.ReadKey();

        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                if (item.Name == "Sulfuras, Hand of Ragnaros")
                    continue;
                    
                if (item.Name == "Aged Brie")
                {
                    if (item.Quality < 50) item.Quality++;
                    item.SellIn--;
                    if (item.Quality < 50 && item.SellIn < 0) item.Quality++;
                    
                    continue;
                }
                
                if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (item.Quality < 50) item.Quality++;
                    if (item.Quality < 50 && item.SellIn < 11) item.Quality++;
                    if (item.Quality < 50 && item.SellIn < 6) item.Quality++;
                    item.SellIn--;
                    if (item.SellIn < 0) item.Quality = 0;

                    continue;
                }
                
                else
                {
                    if (item.Quality > 0)
                    {
                        item.Quality--;
                    }
                }
                
                item.SellIn--;

                if (item.SellIn < 0)
                {
                    if (item.Quality > 0)
                    {
                        item.Quality--;
                    }
                }
            }
        }

    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

}
