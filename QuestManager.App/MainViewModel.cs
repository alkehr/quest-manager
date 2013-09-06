using QuestManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestManager.App
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            CurrentContent = new QuestsViewModel(new QuestManagerContext());
        }

        public object CurrentContent { get; set; }
    }
}
