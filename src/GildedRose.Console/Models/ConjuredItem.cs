
namespace GildedRose.Console.Models
{
    /// <summary>
    /// Conjured item implementaition
    /// </summary>
    public class ConjuredItem : ItemBase
    {
        public ConjuredItem(Item item) : base(item) { }
        
        /// <inheritdoc/>
        protected override int ComputeQualityChange()
        {
            return Item.SellIn switch
            {
                > 0 => -2,
                _ => -4,
            };
        }        
    }
}
