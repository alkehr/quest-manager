using QuestManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Data.Entity;
using System.Threading;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace QuestManager.App
{
    public class QuestsViewModel : INotifyPropertyChanged
    {
        //System.Windows.Data.CollectionViewSource categoryViewSource =
        //        ((System.Windows.Data.CollectionViewSource)(this.FindResource("categoryViewSource")));
 
        //    // Load is an extension method on IQueryable, 
        //    // defined in the System.Data.Entity namespace.
        //    // This method enumerates the results of the query, 
        //    // similar to ToList but without creating a list.
        //    // When used with Linq to Entities this method 
        //    // creates entity objects and adds them to the context.
        //    _context.Categories.Load();
 
        //    // After the data is loaded call the DbSet<T>.Local property 
        //    // to use the DbSet<T> as a binding source.
        //    categoryViewSource.Source = _context.Categories.Local;

        private QuestManagerContext _context; // = new QuestManagerContext();
        private ObservableCollection<Quest> _quests;
        private Quest _selectedQuest;

        public QuestsViewModel()
        {
            //Quests = new CollectionViewSource();
        }

        public QuestsViewModel(QuestManagerContext context)
        {
            _context = context;
            _context.Quests.Load();

            Quests = _context.Quests.Local;
            //var quests = new CollectionViewSource { Source = _context.Quests.Local };
            //Quests = quests;
        }

        public ObservableCollection<Quest> Quests
        {
            get { return _quests; }
            private set
            {
                _quests = value;
                RaisePropertyChanged("Quests");
            }
        }

        public Quest SelectedQuest
        {
            get { return _selectedQuest; }
            set
            {
                _context.SaveChanges();
                _selectedQuest = value;
                RaisePropertyChanged("SelectedQuest");
                RaisePropertyChanged("Objectives");
                RaisePropertyChanged("Rewards");
            }
        }

        public IEnumerable<Objective> Objectives
        {
            get { return SelectedQuest != null ? SelectedQuest.Objectives : null; }
        }

        public IEnumerable<Reward> Rewards
        {
            get { return SelectedQuest != null ? SelectedQuest.Rewards : null; }
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
