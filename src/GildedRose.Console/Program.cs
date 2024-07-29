using System;
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
            var MinQuality = 0;
            var MaxQuality = 50;
            
            foreach (var item in Items)
            {
                int change = 0;
                
                if (item.Name == "Sulfuras, Hand of Ragnaros")
                    continue;
                    
                else if (item.Name == "Aged Brie")
                {
                    change = item.SellIn switch
                    {
                        > 0 => +1,
                        _ => +2
                    };
                }
                
                else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    change = item.SellIn switch
                    {
                        > 10 => +1,
                        > 5 => +2,
                        > 0 => +3,
                        _ => -(item.Quality)
                    };
                }
                
                else
                {
                    change = item.SellIn switch
                    {
                        > 0 => -1,
                        _ => -2
                    };
                }
                
                item.SellIn--;
                item.Quality = Math.Clamp(item.Quality + change, MinQuality, MaxQuality);
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
