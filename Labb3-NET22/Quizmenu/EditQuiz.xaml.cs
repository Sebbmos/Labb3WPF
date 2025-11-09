using Labb3_NET22.DataModels;
using Microsoft.Win32;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Labb3_NET22.Quizmenu
{
    /// <summary>
    /// Interaction logic for EditQuiz.xaml
    /// </summary>
    public partial class EditQuiz : UserControl
    {
        private Quiz? _quiz;
        private int _selectedIndex = -1;

        public EditQuiz()
        {
            InitializeComponent();
            CorrectCombo.SelectedIndex = 0;
            LoadFileList();
        }

        private void LoadFileList()
        {
            FilesList.ItemsSource = FileManager.GetSavedQuizFiles().ToList();
        }

        private async void Open_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog
            {
                InitialDirectory = FileManager.Folder,
                Filter = "Quiz (*.json)|*.json|All files|*.*"
            };
            if (dlg.ShowDialog() == true)
            {
                _quiz = await FileManager.LoadQuiz(dlg.FileName);
                TitleBox.Text = _quiz?.Title ?? "";
                RefreshQuestions();
                LoadFileList();
            }
        }

        private async void LoadSelected_Click(object sender, RoutedEventArgs e)
        {
            if (FilesList.SelectedItem is string path)
            {
                _quiz = await FileManager.LoadQuiz(path);
                TitleBox.Text = _quiz?.Title ?? "";
                RefreshQuestions();
            }
        }

        private void RefreshQuestions()
        {
            QuestionsList.ItemsSource = null;
            if (_quiz == null) return;
            QuestionsList.ItemsSource = _quiz.Questions.Select((q, i) => $"[{i}] {q.Statement}").ToList();
            _selectedIndex = -1;
            QuestionBox.Clear(); Ans0.Clear(); Ans1.Clear(); Ans2.Clear();
            CorrectCombo.SelectedIndex = 0;
        }

        private void QuestionsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_quiz == null) return;
            _selectedIndex = QuestionsList.SelectedIndex;
            if (_selectedIndex < 0 || _selectedIndex >= _quiz.Questions.Count) return;

            var q = _quiz.Questions[_selectedIndex];
            TitleBox.Text = _quiz.Title;
            QuestionBox.Text = q.Statement;
            Ans0.Text = q.Answers[0];
            Ans1.Text = q.Answers[1];
            Ans2.Text = q.Answers[2];
            CorrectCombo.SelectedIndex = q.CorrectAnswer;
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (_quiz == null)
            {
                MessageBox.Show("Ladda ett quiz först.");
                return;
            }
            if (_selectedIndex < 0)
            {
                MessageBox.Show("Välj en fråga i listan.");
                return;
            }
            if (string.IsNullOrWhiteSpace(TitleBox.Text) ||
                string.IsNullOrWhiteSpace(QuestionBox.Text) ||
                string.IsNullOrWhiteSpace(Ans0.Text) ||
                string.IsNullOrWhiteSpace(Ans1.Text) ||
                string.IsNullOrWhiteSpace(Ans2.Text))
            {
                MessageBox.Show("Fyll i titel, fråga och tre svar.");
                return;
            }

            _quiz.Title = TitleBox.Text.Trim();
            var q = _quiz.Questions[_selectedIndex];
            q.Statement = QuestionBox.Text.Trim();
            q.Answers[0] = Ans0.Text.Trim();
            q.Answers[1] = Ans1.Text.Trim();
            q.Answers[2] = Ans2.Text.Trim();
            q.CorrectAnswer = CorrectCombo.SelectedIndex < 0 ? 0 : CorrectCombo.SelectedIndex;

            RefreshQuestions();
            QuestionsList.SelectedIndex = _selectedIndex;
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            if (_quiz == null)
            {
                MessageBox.Show("Inget quiz laddat.");
                return;
            }
            if (string.IsNullOrWhiteSpace(_quiz.Title))
            {
                MessageBox.Show("Sätt en titel.");
                return;
            }
            await FileManager.SaveQuiz(_quiz);
            MessageBox.Show("Sparat.");
            LoadFileList();
        }

        private void CorrectCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow is MainWindow mw)
            {
                mw.RestoreInitialContent();
            }
        }
    }
}
