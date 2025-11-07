using Labb3_NET22.DataModels;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Labb3_NET22.Quizmenu
{
    /// <summary>
    /// Interaction logic for CreateQuiz.xaml
    /// </summary>
    public partial class CreateQuiz : UserControl
    {
        private Quiz _quiz = new Quiz("Untitled");

        public CreateQuiz()
        {
            InitializeComponent();
            TitleBox.Text = _quiz.Title;
            RefreshList();
        }

        private void RefreshList()
        {
            QuestionsList.ItemsSource = null;
            QuestionsList.ItemsSource = _quiz.Questions
                .Select((q, i) => $"[{i}] {q.Statement}")
                .ToList();
        }

        private void AddQuestion_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TitleBox.Text))
            {
                MessageBox.Show("Ange en quiz-titel.");
                return;
            }
            if (string.IsNullOrWhiteSpace(QuestionBox.Text) ||
                string.IsNullOrWhiteSpace(Ans0.Text) ||
                string.IsNullOrWhiteSpace(Ans1.Text) ||
                string.IsNullOrWhiteSpace(Ans2.Text))
            {
                MessageBox.Show("Fyll i fråga och tre svar.");
                return;
            }

            _quiz.Title = TitleBox.Text.Trim();
            int correct = CorrectCombo.SelectedIndex < 0 ? 0 : CorrectCombo.SelectedIndex;

            _quiz.AddQuestion(
                QuestionBox.Text.Trim(),
                correct,
                Ans0.Text.Trim(), Ans1.Text.Trim(), Ans2.Text.Trim()
            );

            QuestionBox.Clear(); Ans0.Clear(); Ans1.Clear(); Ans2.Clear();
            CorrectCombo.SelectedIndex = 0;

            RefreshList();
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_quiz.Title) || _quiz.Questions.Count == 0)
            {
                MessageBox.Show("Sätt titel och lägg till minst en fråga.");
                return;
            }
            await FileManager.SaveQuiz(_quiz);
            MessageBox.Show("Sparat.");
        }

        private void ClearAll_Click(object sender, RoutedEventArgs e)
        {
            _quiz = new Quiz("Untitled");
            TitleBox.Text = _quiz.Title;
            RefreshList();
        }

        private void BackToMenu_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow is MainWindow mw)
            {
                mw.RestoreInitialContent();
            }
        }
    }
}
