using QuestManager.Serialization;

namespace QuestManager.Data
{
    public class Objective
    {
        [QuestArrayKey]
        public int ObjectiveId { get; set; }

        [QuestArrayValue]
        public string Title { get; set; }
    }
}
