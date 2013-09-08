using System.Data.Entity;

namespace QuestManager.Data
{
    public class QuestManagerContext : DbContext
    {
        public DbSet<Quest> Quests { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}
