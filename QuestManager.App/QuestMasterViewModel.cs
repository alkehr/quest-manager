using System;
using QuestManager.Data;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.ComponentModel;

namespace QuestManager.App
{
    public class QuestMasterViewModel : INotifyPropertyChanged
    {
        private IEnumerable<QuestDetailViewModel> _quests;
        private QuestDetailViewModel _selectedQuest;

        public QuestMasterViewModel()
        {
        }

        public QuestMasterViewModel(IQuestRepository questRepository)
        {
            if (questRepository == null)
                throw new ArgumentNullException("questRepository");

            Quests = questRepository.GetAll().Select(q => new QuestDetailViewModel(q));
        }
        
        public IEnumerable<QuestDetailViewModel> Quests
        {
            get { return _quests ?? Enumerable.Empty<QuestDetailViewModel>(); }
            protected set
            {
                _quests = value;
                RaisePropertyChanged("Quests");
                if (SelectedQuest == null)
                    SelectedQuest = Quests.FirstOrDefault();
            }
        }

        public QuestDetailViewModel SelectedQuest
        {
            get { return _selectedQuest; }
            set
            {
                //_context.SaveChanges();
                _selectedQuest = value;
                RaisePropertyChanged("SelectedQuest");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
