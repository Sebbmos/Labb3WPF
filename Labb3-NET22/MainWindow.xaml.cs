using System.Windows;

namespace Labb3_NET22
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ShowMainMenu();
        }

        public void ShowMainMenu()
        {

            MainContent.Content = null;
        }


        private void PlayQuiz_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new Labb3_NET22.PlayQuiz.PlayQuizView();
        }

        private void EditQuiz_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CreateQuiz_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ExitQuiz_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
