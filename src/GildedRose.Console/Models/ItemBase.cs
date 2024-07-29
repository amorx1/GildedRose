using System;

namespace GildedRose.Console.Models
{
    /// <summary>
    /// Base updateable item implementaition
    /// </summary>
	public abstract class ItemBase
    {
        protected int MaxQuality = 50;
        protected int MinQuality = 0;
        protected Item Item;
        
        public ItemBase(Item item) { Item = item; }
        
    	/// <summary>
    	/// Performs quality update on encapsulated item
    	/// </summary>
        public virtual void UpdateQuality()
        {
            int change = ComputeQualityChange();
            
            Item.SellIn--;
            Item.Quality = Math.Clamp(Item.Quality + change, MinQuality, MaxQuality);
        }

    	/// <summary>
    	/// Computes quality adjustment required based on encapsulated item properties
    	/// </summary>
		/// <returns>An signed integer indicating change in quality </returns>
        protected abstract int ComputeQualityChange();
    }
}
