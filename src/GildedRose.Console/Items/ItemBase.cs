using System;

namespace GildedRose.Console.Items
{
	public abstract class ItemBase
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

        protected abstract int ComputeQualityChange();
    }
}
