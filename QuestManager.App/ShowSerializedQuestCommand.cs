using System;
using System.Windows.Input;

namespace QuestManager.App
{
    public class ShowSerializedQuestCommand : ICommand
    {
        private readonly QuestDetailViewModel _questDetailViewModel;

        public ShowSerializedQuestCommand(QuestDetailViewModel questDetailViewModel)
        {
            _questDetailViewModel = questDetailViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return _questDetailViewModel.CanShowSerializedQuest();
        }

        public void Execute(object parameter)
        {
            _questDetailViewModel.ShowSerializedQuest();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}