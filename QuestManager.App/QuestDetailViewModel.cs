using System.IO;
using System.Windows.Input;
using QuestManager.App.Properties;
using QuestManager.Data;
using System.Collections.Generic;
using System.Text;
using QuestManager.Serialization;

namespace QuestManager.App
{
    public class QuestDetailViewModel
    {
        private readonly Quest _quest;
        private ShowSerializedQuestCommand _showSerializedQuestCommand;

        public QuestDetailViewModel(Quest quest)
        {
            _quest = quest;
        }

        public ICommand ShowSerializedQuestCommand
        {
            get
            {
                return _showSerializedQuestCommand ??
                       (_showSerializedQuestCommand = new ShowSerializedQuestCommand(this));
            }
        }

        public string NameLabel
        {
            get { return Resources.QuestNameLabel; }
        }

        public string ObjectivesLabel
        {
            get { return Resources.ObjectivesLabel; }
        }

        public string RewardsLabel
        {
            get { return Resources.RewardsLabel; }
        }

        public string OkLabel
        {
            get { return Resources.OkLabel; }
        }

        public string CancelLabel
        {
            get { return Resources.CancelLabel; }
        }

        public string Name
        {
            get { return _quest.Name; }
            set { _quest.Name = value; }
        }

        public Quest Quest
        {
            get { return _quest; }
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

        private string _serializedQuest;
        public string SerializedQuest
        {
            get
            {
                if (string.IsNullOrEmpty(_serializedQuest))
                {
                    var sb = new StringBuilder();
                    var x = new QuestTextWriter(new StringWriter(sb));
                    x.Write(_quest);
                    _serializedQuest = sb.ToString();
                }

                return _serializedQuest;
            }
        }

        public bool CanShowSerializedQuest()
        {
            return _quest != null;
        }

        public void ShowSerializedQuest()
        {
            var dialog = new SerializedQuestDialog { DataContext = this };

            dialog.ShowDialog();
        }
    }
}
