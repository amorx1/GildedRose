namespace GildedRose.Console.Items
{
    public class SulfurasItem : ItemBase
    {
        private new int MaxQuality = 80;
        private new int MinQuality = 0;
        
        public SulfurasItem(Item item) : base(item) { }

        public override void UpdateQuality()
        {
            return;
        }

        protected override int ComputeQualityChange()
        {
            return 0;
        }
    }
}
