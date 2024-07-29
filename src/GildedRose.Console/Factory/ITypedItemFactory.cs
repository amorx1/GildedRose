
using GildedRose.Console.Items;

namespace GildedRose.Console.Factory
{
    /// <summary>
    /// Delegates creation of ItemBase implementations based on item names
    /// </summary>
    public interface ITypedItemFactory
    {
        /// <summary>
        /// Gets ItemBase implementation
        /// </summary>
        /// <returns>The corresponding ItemBase implementation</returns>
        public ItemBase GetItem(Item item);
    }
}
