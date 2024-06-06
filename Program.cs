using System.Xml.XPath;
using Microsoft.VisualBasic;

namespace QuizAppCs;

class Question{
    public string Text;
    public string[] Choices{ get; set;}
    public string Answer { get; set; }

    public Question(string text, string[] choices, string answer){
        this.Text = text;
        this.Choices = choices;
        this.Answer = answer;
    }
    public bool CheckAnswer(string answer){
        bool result = (this.Answer == answer);
        return result;
    }

}

class Quiz{

    private Question[] Questions { get; set; }

    public int QuestionIndex { get; set; }

    public int Score;
    public Quiz(Question[] questions)
    {
        this.Questions = questions;
        this.QuestionIndex = 0;
        this.Score = 0;
    }

    public Question GetQuestion(){
        return this.Questions[this.QuestionIndex];
    }

    public void Guess(string result){

        var question = this.GetQuestion();
        System.Console.WriteLine($"Question{QuestionIndex+1} = {question.CheckAnswer(result)}");
        if(question.CheckAnswer(result))
        Score++;
        this.QuestionIndex++;
    }


    public void DisplayQuestion(){

        var question = this.GetQuestion();
        System.Console.WriteLine($"Question{QuestionIndex+1} : {question.Text}");
        foreach (var choice in question.Choices)
            {
                System.Console.Write(choice);
                System.Console.Write("\t"); 
            }
        
        System.Console.WriteLine("\n");
        System.Console.Write("Your Answer:");
        string result = Console.ReadLine();
        this.Guess(result);
        
        if(this.QuestionIndex==Questions.Length){
            System.Console.WriteLine($"Your Score : {Score}/{Questions.Length}");
        }else{
            DisplayQuestion();
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, Quiz Start!");

        string[] cho = new string[4]{"C#", "Java", "Python","C++"};



        var q1 = new Question("The best Programming Language?", cho, "C#");
        var q2 = new Question("The best preferred Programming Language?", cho, "Python");
        var q3 = new Question("The best Programming Language which you earn money more?", cho, "Java");

        var questions = new Question[]{q1, q2, q3};
        Quiz quiz = new Quiz(questions);

        quiz.DisplayQuestion();
    }
        
}
