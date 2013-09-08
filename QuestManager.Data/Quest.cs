using System.Collections.Generic;
using QuestManager.Serialization;

namespace QuestManager.Data
{
    public class Quest
    {
        [QuestId]
        public int QuestId { get; set; }

        [QuestElement("name")]
        public string Name { get; set; }

        [QuestElement("level")]
        public int Level { get; set; }

        public virtual List<Objective> Objectives { get; set; }
        public virtual List<Reward> Rewards { get; set; }

    }
}
