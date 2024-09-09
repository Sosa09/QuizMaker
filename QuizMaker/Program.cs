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

            handler.Add(new Question { QuestionText = "This is my question", Answers = new List<Answer> { new Answer { AnswerText = "" }}});
            handler.Add(new Question { QuestionText = "This is my question", Answers = new List<Answer> { new Answer { AnswerText = "" }}});

            handler.saveData(path);
            handler.loadData(path);

            List<Question> questions = handler.GetQuestions();
            
        }
    }
}