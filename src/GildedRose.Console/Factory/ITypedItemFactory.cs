
using GildedRose.Console.Items;

namespace GildedRose.Console.Factory
{
    public interface ITypedItemFactory
    {
        public ItemBase GetItem(Item item);
    }
}
