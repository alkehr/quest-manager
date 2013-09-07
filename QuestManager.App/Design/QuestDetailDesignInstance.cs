using QuestManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestManager.App.Design
{
    public class QuestDetailDesignInstance : QuestDetailViewModel
    {
        public QuestDetailDesignInstance()
            : base(CreateDesignTimeQuest())
        {
        }

        private static Quest CreateDesignTimeQuest()
        {
            return new Quest
            {
                QuestId = 1,
                Name = "Design Instance Quest",
                Level = 15,
                Objectives = new List<Objective>
                {
                    new Objective{ ObjectiveId = 1, Title = "Objective #1" }
                },
                Rewards = new List<Reward>
                {
                    new Reward{ RewardId = 1, Type = "gold", Quantity = 50 }
                }
            };
        }
    }
}
