using Labb3_NET22.DataModels;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Labb3_NET22
{


    public class PlayQuizViewModel : INotifyPropertyChanged
    {
        public Quiz Quiz { get; set; }
        public Question CurrentQuestion { get; set; }
        public int SelectedAnswerIndex { get; set; }
        public int CorrectAnswers { get; set; }
        public int TotalAnswerd { get; set; }

        public bool isFinished = false;

        public List<Question> QuestionAnswerd = new List<Question>();

        public string ScoreText
        {
            get
            {
                int percent = 0;
                if (TotalAnswerd > 0)
                {
                    percent = (int)((double)CorrectAnswers / TotalAnswerd * 100);
                }
                return $"Rätt: {CorrectAnswers} / {TotalAnswerd} ({percent}%)";
            }
        }

        public PlayQuizViewModel()   //gammalt demo används inte i applikationen
        {
            Quiz = new Quiz("TestQuiz");
            Quiz.AddQuestion("hur många liv sägs det att en katt har?", 1, "1", "9", "7", "4");
            Quiz.AddQuestion("Vem spelar Jack i filmen Titanic?", 2, "Brad Pitt", "Christopher Nolan", "Leonardo DiCaprio", "Robin Kamo");
            Quiz.AddQuestion("Vad heter karaktären som dödar Qui-Gon Jinn i filmen Star Wars Phantom Menace?", 1, "Boba Fett", "Darth Maul", "Darth Sidious", "Anakin Skywalker");
            Quiz.AddQuestion("Vad står WPF för?", 3, "Windows Presentation Fixer", "Windowed Presentation Formula", "Whatever Presentation Founder", "Windows Presentation Foundation");
            CurrentQuestion = Quiz.GetRandomQuestion();
            SelectedAnswerIndex = -1;
            OnPropertyChange("CurrentQuestion");
        }
        public PlayQuizViewModel(Quiz quiz)
        {
            Quiz = quiz;
            SelectedAnswerIndex = -1;
            CurrentQuestion = Quiz.GetRandomQuestion();
            OnPropertyChange("CurrentQuestion");
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChange([CallerMemberName] string name = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public void NextQuestion(int selectedIndex)
        {
            TotalAnswerd++;
            if (CurrentQuestion.IsCorrect(selectedIndex))
            {
                CorrectAnswers++;
            }

            QuestionAnswerd.Add(CurrentQuestion);

            bool isUsed = true;

            while (isUsed)
            {
                CurrentQuestion = Quiz.GetRandomQuestion();

                var nextQuest = QuestionAnswerd.Any(q => q.Statement == CurrentQuestion.Statement);

                if (QuestionAnswerd.Count == Quiz.Questions.Count)
                {
                    isFinished = true;
                    isUsed = false;
                    break;
                }

                if (nextQuest == true)
                {
                    CurrentQuestion = Quiz.GetRandomQuestion();

                }
                else
                {
                    isUsed = false;
                    break;
                }

            }
            OnPropertyChange("CurrentQuestion");
            OnPropertyChange("ScoreText");

        }



    }

}

