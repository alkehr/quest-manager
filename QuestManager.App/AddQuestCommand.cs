using System;
using System.Windows.Input;

namespace QuestManager.App
{
    public class AddQuestCommand : ICommand
    {
        private readonly QuestMasterViewModel _questMasterViewModel;

        public AddQuestCommand(QuestMasterViewModel questMasterViewModel)
        {
            _questMasterViewModel = questMasterViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return _questMasterViewModel.CanAddQuest();
        }

        public void Execute(object parameter)
        {
            _questMasterViewModel.AddQuest();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}