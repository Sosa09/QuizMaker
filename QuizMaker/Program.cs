namespace QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileName = "questions.xml";

            string path = @$"..\..\{fileName}";

            DataHandler handler = new DataHandler();

            handler.Add(new Question { Description = "", Id = 1, Name = "This is my question" });
            handler.Add(new Question { Description = "", Id = 1, Name = "This is my question" });

            handler.saveData();
        }
    }
}