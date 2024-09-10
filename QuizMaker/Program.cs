namespace QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileName = "questions.xml";
            string path = $@"{fileName}";

            DataHandler handler = new DataHandler();
            
            Participant participant = new Participant();
            participant.Name = "Soufiane";
            participant.Age = 32;
            participant.Result = new ParticipantResult();
     
            handler.loadData(path);
            while (true)
            {
                Console.Clear();
                foreach (var q in handler.GetQuestions())
                {
                    UserInterface.DisplayQuestion(q);

                    var participantAnswerChoice = UserInterface.GetUserAnswer();
                    Answer answer = q.Answers[int.Parse(participantAnswerChoice)];

                    if (QuizLogic.IsQuestionAnsweredCorrectly(answer))
                        QuizLogic.AddOnePoint(participant); 
                }

                UserInterface.DisplayParticipantResult(participant);
                Console.ReadKey();
            }
        }        
    }
}