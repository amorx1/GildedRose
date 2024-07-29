
namespace GildedRose.Console.Items
{
    public class AgedBrieItem : ItemBase
    {
        public AgedBrieItem(Item item) : base(item) { }
        
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
