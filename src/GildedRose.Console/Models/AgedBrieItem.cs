
namespace GildedRose.Console.Models
{
    /// <summary>
    /// Aged Brie item implementaition
    /// </summary>
    public class AgedBrieItem : ItemBase
    {
        public AgedBrieItem(Item item) : base(item) { }
        
        /// <inheritdoc/>
        protected override int ComputeQualityChange()
        {
            return Item.SellIn switch
            {
                > 0 => +1,
                _ => +2,
            };
        }        
    }
}
