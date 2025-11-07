using System.Windows;

namespace Labb3_NET22
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private object _initialContent;

        public MainWindow()
        {
            InitializeComponent();
            _initialContent = this.Content;
        }

        public void RestoreInitialContent()
        {
            this.Content = _initialContent;
        }

        private void PlayQuiz_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new Labb3_NET22.PlayQuiz.PlayQuizView();
        }

        private void EditQuiz_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new Labb3_NET22.Quizmenu.EditQuiz();
        }

        private void CreateQuiz_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new Labb3_NET22.Quizmenu.CreateQuiz();
        }

        private void ExitQuiz_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
