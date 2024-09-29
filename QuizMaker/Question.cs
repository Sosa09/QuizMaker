namespace QuizMaker
{
    public class Question : IResource
    {
        public string QuestionText;
        public List<Answer> Answers;
        public override string ToString()
        {
            return QuestionText;
        }
    }
}
