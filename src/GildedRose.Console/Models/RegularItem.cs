
namespace GildedRose.Console.Models
{
    /// <summary>
    /// Regular item implementaition
    /// </summary>
    public class RegularItem : ItemBase
    {
        public RegularItem(Item item) : base(item) { }

        /// <inheritdoc/>
        protected override int ComputeQualityChange()
        {
            return Item.SellIn switch
            {
                > 0 => -1,
                _ => -2
            };
        }
    }
}
