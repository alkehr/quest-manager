using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace QuestManager.Data
{
    public class QuestManagerContext : DbContext
    {
        public DbSet<Quest> Quests { get; set; }
    }
}
