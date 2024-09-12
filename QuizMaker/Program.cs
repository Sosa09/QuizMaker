namespace QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = Constant.DEFAULT_WORKING_PATH;
            Participant participant = null;
            //Requesting partcipant name and age and pass it to RegisterParticpant in order to register the particpant to hold it's score and results
            //GOOD TO HAVE: config file to load user profile check if a player exists if not MANDATORY TO CREATE ONE
            
            var quiz = QuizLogic.LoadQuiz(path);
            if(quiz.Count == 0) 
                CreateQuiz(path);
            while (true)
            {
                UserInterface.DisplayQuizMenu(Constant.MENU_OPTION_LIST_ITEMS);
                string choice = UserInterface.GetParticipantMenuChoice();
                switch (choice)
                {
                    case "0":
                        HandlePlayQuizMenu(quiz, participant);
                        break;
                    case "1":
                        HandleScoreQuizMenu();
                        break;
                    case "2":
                        HandleManageParticipantsQuizMenu(ref participant);
                        break;
                    case "3":
                        HandleManageQuestionsQuizMenu();
                        break;
                    default:
                        break;
                }
                Console.Clear();
            }
        }

        private static void HandleManageQuestionsQuizMenu()
        {
            throw new NotImplementedException();
        }

        private static void HandleManageParticipantsQuizMenu(ref Participant? participant)
        {
            string name = UserInterface.GetParticipantName();
            int age = UserInterface.GetParticipantAge();
            participant = QuizLogic.RegisterParticipant(name, age);
        }

        private static void HandleScoreQuizMenu()
        {
            throw new NotImplementedException();
        }

        private static void HandlePlayQuizMenu(List<Question> quiz, Participant participant)
        {
            bool sessionActive = participant != null;
            while (sessionActive)
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
                UserInterface.IsSessionActive(ref sessionActive);
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