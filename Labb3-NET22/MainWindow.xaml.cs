using Labb3_NET22.DataModels;
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
            //_initialContent = MainContent.Content;
        }

        public void RestoreInitialContent()
        {
            this.Content = _initialContent;
            //MainContent.Content = _initialContent;
        }

        private void PlayQuiz_Click(object sender, RoutedEventArgs e)
        {
            //this.Content = new Labb3_NET22.PlayQuiz.PlayQuizView();
            ShowPlaySelect();
        }

        private void EditQuiz_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new Labb3_NET22.Quizmenu.EditQuiz();
            //MainContent.Content = new EditQuiz();
        }

        private void CreateQuiz_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new Labb3_NET22.Quizmenu.CreateQuiz();
            //MainContent.Content = new CreateQuiz();
        }

        private void ExitQuiz_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // ADD: visa välj-quiz-meny
        public void ShowPlaySelect()
        {
            this.Content = new Labb3_NET22.PlayQuiz_SelectQuizView();
            //MainContent.Content = new PlayQuiz_SelectQuizView();
        }


        public void StartPlayWithQuiz(Quiz quiz)
        {
            //var playQuizView = new Labb3_NET22.PlayQuiz.PlayQuizView();
            //playQuizView.ViewModel = new Labb3_NET22.PlayQuiz.PlayQuizView(quiz); 
            //MainContent.Content = new PlayQuizViewModel(); ;
            this.Content = new Labb3_NET22.PlayQuiz.PlayQuizView(quiz);   //från playquiz metoden
        }
    }
}
