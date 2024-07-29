
namespace GildedRose.Console.Items 
{
    public class RegularItem : ItemBase
    {
        public RegularItem(Item item) : base(item) { }

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
