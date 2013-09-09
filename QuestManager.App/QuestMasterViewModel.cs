using System;
using System.Windows.Input;
using QuestManager.App.Properties;
using QuestManager.Data;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.ComponentModel;

namespace QuestManager.App
{
    public class QuestMasterViewModel : INotifyPropertyChanged
    {
        private readonly IQuestRepository _questRepository;

        private IEnumerable<QuestDetailViewModel> _quests;
        private QuestDetailViewModel _selectedQuest;
        private AddQuestCommand _addQuestCommand;

        public QuestMasterViewModel()
        {
        }

        public QuestMasterViewModel(IQuestRepository questRepository)
        {
            if (questRepository == null)
                throw new ArgumentNullException("questRepository");

            _questRepository = questRepository;
            RefreshQuests();
        }

        public event PropertyChangedEventHandler PropertyChanged;

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
                _selectedQuest = value;
                RaisePropertyChanged("SelectedQuest");
            }
        }

        public ICommand AddQuestCommand
        {
            get { return _addQuestCommand ?? (_addQuestCommand = new AddQuestCommand(this)); }
        }

        public string AddQuestLabel
        {
            get { return Resources.AddQuestLabel; }
        }

        public bool CanAddQuest()
        {
            return true;
        }

        public void AddQuest()
        {
            var questDetailViewModel = new QuestDetailViewModel(new Quest());

            var newDialog = new AddQuestDialog {DataContext = questDetailViewModel};
            newDialog.ShowDialog();

            if (newDialog.DialogResult == true)
            {
                _questRepository.Add(questDetailViewModel.Quest);
                _questRepository.SaveChanges();
                RefreshQuests();
            }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private void RefreshQuests()
        {
            Quests = _questRepository.GetAll().Select(q => new QuestDetailViewModel(q));
        }
    }
}
