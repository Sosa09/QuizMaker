namespace QuizMaker
{
    public class Question : IResource
    {
        public string QuestionText { get; set; }
        public List<Answer> Answers { get; set; }

        public int Id { get; set; }

        public override string ToString()
        {
            return QuestionText;
        }
    }
}
