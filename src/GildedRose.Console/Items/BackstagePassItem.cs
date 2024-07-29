
namespace GildedRose.Console.Items
{
    public class BackstagePassItem : ItemBase
    {
        public BackstagePassItem(Item item) : base(item) { }

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
