using System;

namespace GildedRose.Console.Items
{
	public class ItemBase
    {
        protected int MaxQuality = 50;
        protected int MinQuality = 0;
        protected Item Item;
        
        public ItemBase(Item item) { Item = item; }
        
        public virtual void UpdateQuality()
        {
            int change = ComputeQualityChange();
            
            Item.SellIn--;
            Item.Quality = Math.Clamp(Item.Quality + change, MinQuality, MaxQuality);
        }

		// Regular item quality implementation
        protected virtual int ComputeQualityChange()
        {
            return Item.SellIn switch
            {
                > 0 => -1,
                _ => -2
            };
        }
    }
}
