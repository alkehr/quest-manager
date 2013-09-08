using QuestManager.Data;

namespace QuestManager.App
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            CurrentContent = new QuestMasterViewModel(new QuestRepository(new QuestManagerContext()));
        }

        public object CurrentContent { get; set; }
    }
}
