using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuestManager.Data
{
    public class Quest
    {
        public int QuestId { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }

        public virtual List<Objective> Objectives { get; set; }
        public virtual List<Reward> Rewards { get; set; }
    }
}
