using QuestManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace QuestManager.App.Design
{
    internal sealed class QuestMasterDesignInstance : QuestMasterViewModel
    {
        public QuestMasterDesignInstance()
        {
            Quests = new List<QuestDetailViewModel>
            {
                new QuestDetailViewModel(new Quest { QuestId = 1, Name = "Quest #1", Level = 1 }),
                new QuestDetailViewModel(new Quest { QuestId = 2, Name = "Quest #2", Level = 2 }),
                new QuestDetailViewModel(new Quest { QuestId = 3, Name = "Quest #3", Level = 3 }),
                new QuestDetailViewModel(new Quest { QuestId = 4, Name = "Quest #4", Level = 4 }),
            };
        }
    }
}
