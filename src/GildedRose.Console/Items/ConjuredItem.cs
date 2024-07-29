
namespace GildedRose.Console.Items
{
    public class ConjuredItem : ItemBase
    {
        public ConjuredItem(Item item) : base(item) { }
        
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
