using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Resources;
using System.Threading.Tasks;
using System.Windows;

namespace QuestManager.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static ResourceManager _resourceManager;
        public static ResourceManager ResourceManager
        {
            get { return _resourceManager ?? (_resourceManager = new ResourceManager("QuestManager.App.Properties.Resources", typeof(App).Assembly)); }
        } 
    }
}
