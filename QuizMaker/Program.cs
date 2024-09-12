namespace QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = Constant.DEFAULT_WORKING_PATH;

            //Requesting partcipant name and age and pass it to RegisterParticpant in order to register the particpant to hold it's score and results
            //GOOD TO HAVE: config file to load user profile
            string name = UserInterface.GetParticipantName();
            int age = UserInterface.GetParticipantAge();
            Participant participant = QuizLogic.RegisterParticipant(name, age);
            
            var quiz = QuizLogic.LoadQuiz(path);
            if(quiz.Count == 0) 
                CreateQuiz(path);

            while (true)
            {
                Console.Clear();
                UserInterface.DisplayQuizMenu(Constant.MENU_OPTION_LIST_ITEMS);
                //TODO: add while loop for the quiz it self 
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
                UserInterface.ConfirmUserInputToContinue();               
            }
        }
        private static void CreateQuiz(string path)
        {
            bool creatingNotEnded = true;
            while (creatingNotEnded)
            {
                string questionText = UserInterface.RequestNewQuestion();
                Question question = new();
                question.Answers = new();
                QuizLogic.AddNewQuestion(question, questionText);

                bool answerNotEnded = true;

                while (answerNotEnded)
                {
                    Answer answer = new Answer();                    
                    UserInterface.RequestNewAnswer(answer);
              
                    QuizLogic.AddAnswerToQuestion(question, answer);
                    if (UserInterface.ParticipantEndedCreatingAnswers())
                        break;
                }
                QuizLogic.StoreQuiz(question);
                if (UserInterface.ParticipantEndedCreatingAnswers())
                    break;
            }
            QuizLogic.SaveQuiz(path);
        }
    }
}