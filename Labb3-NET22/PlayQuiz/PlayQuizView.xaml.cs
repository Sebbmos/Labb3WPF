using System;
using System.Windows;
using System.Windows.Controls;

namespace Labb3_NET22.PlayQuiz
{
    /// <summary>
    /// Interaction logic for PlayQuizView.xaml
    /// </summary>
    public partial class PlayQuizView : UserControl
    {
        public PlayQuizViewModel ViewModel { get; set; }
        public PlayQuizView(Labb3_NET22.DataModels.Quiz quiz)
        {
            InitializeComponent();
            ViewModel = new PlayQuizViewModel(quiz);
            DataContext = ViewModel;
        }

        public void AnswerButton_Click(Object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int selectedIndex = int.Parse(button.Tag.ToString());
            ViewModel.NextQuestion(selectedIndex);

            if (ViewModel.isFinished)
            {
                if (Application.Current.MainWindow is MainWindow mw)
                {
                    mw.Content = new Labb3_NET22.ScoreWindowView(ViewModel);

                }
            }
        }


    }


}
