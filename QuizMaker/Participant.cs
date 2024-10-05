namespace QuizMaker
{
    public class Participant : IResource
    {
        public string Name {get; set;}
        public int Id {get; set;}
        public int Age { get; set; }
        public ParticipantResult Result { get; set; }

        public override string ToString()
        {
            return  $"Name:               {Name}\n" +
                    $"Age:                {Age}\n" +
                    $"Last participated:  {Result.LastParticipationDate}\n" +
                    $"Total score:        {Result.TotalScore}";
        }
    }
}
