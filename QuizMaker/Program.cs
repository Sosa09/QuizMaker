using System.Threading.Channels;

namespace QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileName = "questions.xml";

            string path = $@"{fileName}";

            DataHandler handler = new DataHandler();

            handler.Add(new Question { QuestionText = "This is my question", Answers = new List<Answer> { new Answer { AnswerText = "new answer" }, new Answer { AnswerText = "new answer" } } });
            handler.Add(new Question { QuestionText = "This is my question", Answers = new List<Answer> { new Answer { AnswerText = "new answer" }, new Answer { AnswerText = "new answer" } } });
            handler.Add(new Question { QuestionText = "This is my question", Answers = new List<Answer> { new Answer { AnswerText = "new answer" }, new Answer { AnswerText = "new answer" } } });
            

            handler.saveData(path);
            handler.loadData(path);

            List<Question> questions = handler.GetQuestions();
            UserInterface.DisplayQuestions(questions);
            
        }
    }
}