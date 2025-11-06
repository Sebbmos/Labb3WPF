namespace Labb3_NET22.DataModels;

public class Question
{
    public string Statement { get; }
    public string[] Answers { get; }
    public int CorrectAnswer { get; }

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