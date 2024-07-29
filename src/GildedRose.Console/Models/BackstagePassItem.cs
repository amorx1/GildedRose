
namespace GildedRose.Console.Models
{
    /// <summary>
    /// BackstagePass item implementaition
    /// </summary>
    public class BackstagePassItem : ItemBase
    {
        public BackstagePassItem(Item item) : base(item) { }

        /// <inheritdoc/>
        protected override int ComputeQualityChange()
        {
            return Item.SellIn switch
            {
                > 10 => +1,
                > 5 => +2,
                > 0 => +3,
                _ => -(Item.Quality)
            };
        }
    }    
}
