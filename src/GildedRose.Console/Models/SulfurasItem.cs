namespace GildedRose.Console.Models
{
    /// <summary>
    /// Sulfuras item implementaition
    /// </summary>
    public class SulfurasItem : ItemBase
    {
        private new int MaxQuality = 80;
        private new int MinQuality = 0;
        
        public SulfurasItem(Item item) : base(item) { }

        /// <inheritdoc/>
        public override void UpdateQuality()
        {
            return;
        }

        /// <inheritdoc/>
        protected override int ComputeQualityChange()
        {
            return 0;
        }
    }
}
