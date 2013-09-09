using System.Windows;

namespace QuestManager.App
{
    /// <summary>
    /// Interaction logic for AddQuestDialog.xaml
    /// </summary>
    public partial class AddQuestDialog
    {
        public AddQuestDialog()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
