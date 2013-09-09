using System.Data.Entity;
using System.Windows;
using QuestManager.Data;

namespace QuestManager.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Database.SetInitializer(new CreateDatabaseIfNotExists<QuestManagerContext>());
        }
    }
}
