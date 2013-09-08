namespace QuestManager.Data
{
    public class Reward
    {
        public int RewardId { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }

        public int QuestId { get; set; }

        public int? ItemId { get; set; }

        public virtual Item Item { get; set; }
    }
}
