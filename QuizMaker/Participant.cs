namespace QuizMaker
{
    public class Participant : IResource
    {
        public string Name;
        public int Id;
        public int Age;
        public ParticipantResult Result;

        public override string ToString()
        {
            return  $"Name:               {Name}\n" +
                    $"Age:                {Age}" +
                    $"Last participated:  {Result.LastParticipationDate}" +
                    $"Total score:        {Result.TotalScore}";
        }
    }
}
