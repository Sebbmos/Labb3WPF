using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Labb3_NET22
{
    /// <summary>
    /// Interaction logic for PlayQuiz_SelectQuizView.xaml
    /// </summary>
    public partial class PlayQuiz_SelectQuizView : UserControl
    {
        public PlayQuiz_SelectQuizView()
        {
            InitializeComponent();
            LoadFiles();
        }

        private void LoadFiles()
        {
            FilesList.ItemsSource = FileManager.GetSavedQuizFiles().ToList();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e) => LoadFiles();

        private async void Start_Click(object sender, RoutedEventArgs e)
        {
            if (FilesList.SelectedItem is not string path)
            {
                MessageBox.Show("Välj en fil först.");
                return;
            }

            var quiz = await FileManager.LoadQuiz(path);
            if (quiz == null)
            {
                MessageBox.Show("Kunde inte läsa quiz-filen.");
                return;
            }

            if (Application.Current.MainWindow is MainWindow mw)
            {
                mw.StartPlayWithQuiz(quiz);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow is MainWindow mw)
                mw.RestoreInitialContent();
        }
    }
}
