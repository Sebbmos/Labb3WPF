namespace Labb3_NET22.DataModels;

public class Question
{
    public string Statement { get; set; }
    public string[] Answers { get; set; }
    public int CorrectAnswer { get; set; }

    public Question(string statement, int correctAnswer, params string[] answers)
    {
        Statement = statement;
        Answers = answers;
        CorrectAnswer = correctAnswer;
    }

    public bool IsCorrect(int selectedIndex)
    {
        return selectedIndex == CorrectAnswer;
    }
}