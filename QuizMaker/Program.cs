namespace QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileName = "questions.xml";
            string path = $@"{fileName}";

            CreateQuiz(path);

            Participant participant = new Participant();
            participant.Name = "Soufiane";
            participant.Age = 32;
            participant.Result = new ParticipantResult();

            var quiz = QuizLogic.LoadQuiz(path);

            while (true)
            {
                Console.Clear();
                foreach (var q in quiz)
                {
                    UserInterface.DisplayQuestion(q);

                    var participantAnswerChoice = UserInterface.GetParticipantAnswer();

                    Answer answer = QuizLogic.GetAnswer(q, int.Parse(participantAnswerChoice));

                    QuizLogic.StoreParticipantAnswer(q, participant, answer);

                    if (QuizLogic.IsQuestionAnsweredCorrectly(answer))
                        QuizLogic.AddOnePoint(participant); 
                }
                QuizLogic.UpdateLastParticipationDate(participant);

                UserInterface.DisplayParticipantResult(participant);

                Console.ReadKey();
            }
        }
        private static void CreateQuiz(string path)
        {
            bool creatingNotEnded = true;
            while (creatingNotEnded)
            {
                string questionText = UserInterface.RequestNewQuestion();
                Question question = new Question();
                QuizLogic.AddNewQuestion(question, questionText);

                bool answerNotEnded = true;

                while (answerNotEnded)
                {
                    Answer answer = new Answer();                    
                    UserInterface.RequestNewAnswer(answer);
                    if (!QuizLogic.IsAnswerTextBlank(answer.AnswerText, ref answerNotEnded))
                        break;
                    QuizLogic.AddAnswerToQuestion(question, answer);                    
                }
                QuizLogic.StoreQuiz(question);
            }
            QuizLogic.SaveQuiz(path);
        }
        private static void DisplayQuizMenu(List<string> menuOptions)
        {
            throw new NotImplementedException();
        }
    }
}