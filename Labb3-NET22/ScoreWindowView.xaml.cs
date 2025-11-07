using System.Windows;
using System.Windows.Controls;

namespace Labb3_NET22
{
    public partial class ScoreWindowView : UserControl
    {
        public ScoreWindowView(PlayQuizViewModel sw)
        {
            InitializeComponent();
            DataContext = sw;
        }

        private void BackToMenu_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (Application.Current.MainWindow is MainWindow mw)
            {
                mw.RestoreInitialContent();
            }


        }
    }
}