namespace QuizMaker
{
    public class ParticipantResult
    {
        public int TotalScore;
        public List<Question> QuestionAnswered;
        public DateTime LastParticipationDate;

        public ParticipantResult()
        {
            QuestionAnswered = new List<Question>();            
        }
    }
}
