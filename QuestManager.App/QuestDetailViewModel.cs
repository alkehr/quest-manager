using QuestManager.App.Properties;
using QuestManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestManager.App
{
    public class QuestDetailViewModel
    {
        private readonly Quest _quest;

        public QuestDetailViewModel(Quest quest)
        {
            _quest = quest;
        }

        public string ObjectivesLabel
        {
            get { return Resources.ObjectivesLabel; }
        }

        public string RewardsLabel
        {
            get { return Resources.RewardsLabel; }
        }

        public string Name
        {
            get { return _quest.Name; }
        }

        public int QuestId
        {
            get { return _quest.QuestId; }
        }

        public int Level
        {
            get { return _quest.Level; }
        }
        public IEnumerable<Reward> Rewards
        {
            get { return _quest.Rewards; }
        }

        public IEnumerable<Objective> Objectives
        {
            get { return _quest.Objectives; }
        }
    }
}
