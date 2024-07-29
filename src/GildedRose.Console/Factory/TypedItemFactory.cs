
using GildedRose.Console.Items;

namespace GildedRose.Console.Factory
{
    /// <inheritdoc/>
    public class TypedItemFactory : ITypedItemFactory
    {
        public ItemBase GetItem(Item item)
        {
            return item.Name switch
            {
                "Aged Brie" => new AgedBrieItem(item),
                "Sulfuras, Hand of Ragnaros" => new SulfurasItem(item),
                "Backstage passes to a TAFKAL80ETC concert" => new BackstagePassItem(item),
                _ => new RegularItem(item)
            };
        }
    }
}
