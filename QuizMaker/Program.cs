namespace QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //BY DEFAULT PATH WILL BE DEFINED BY SYSTEM WHICH IS THE LOCAL WORKING PATH OF THE PROGRAM
            string path = Constant.DEFAULT_WORKING_PATH;

            //CHECKING FOR PARTICIPANT PROFILES (CREATE LOCAL FUNCTION)
            UserInterface.LoadingProfilesText();

            if (QuizLogic.ProfileListEmpty())
            {
                UserInterface.MandatoryProfileCreactionText();
                CreateParticipant();
            }
            var participants = QuizLogic.GetProfiles();
            //Selection of profille (CREATE LOCAL FUNCTION)
            UserInterface.DisplayProfiles(participants);
            var particpantChoiceId = UserInterface.GetParticipantChoice();
            var participant = QuizLogic.SelectProfile(int.Parse(particpantChoiceId));           

            while (true)
            {
                UserInterface.DisplayQuizMenu(Constant.MENU_OPTION_LIST_ITEMS);
                string choice = UserInterface.GetParticipantChoice();
                switch (choice)
                {
                    case Constant.USER_SELECTED_PLAY:
                        HandlePlayQuizMenu(quiz, participant);
                        break;
                    case Constant.USER_SELECTED_SCORE:
                        HandleScoreQuizMenu();
                        break;
                    case Constant.USER_SELECTED_MANAGE_PARTICPANTS:
                        HandleManageParticipantsQuizMenu(participants);
                        break;
                    case Constant.USER_SELECTED_MANAGE_QUESTIONS:
                        HandleManageQuestionsQuizMenu(quiz,path);
                        break;
                    default:
                        break;
                }
                Console.Clear();
            }
        }
        //TODO Remopve repetitive asking for userid by creating a proper method
        private static void HandleManageQuestionsQuizMenu(List<Question> quiz, string path)
        {
            //TODO Let the user choose a file or quiz he want or maybe some of the questiosn and not all            
            var menuChoice = RequestUserMenuOptionChoice(Constant.MENU_OPTION_PLAY_ITEMS);           
            switch (menuChoice)
            {
                case Constant.USER_SELECTED_CREATE:
                    CreateQuiz(path);
                    break;
                case Constant.USER_SELECTED_REMOVE:
                    //TODO implement remove question if the admin decides it is not relevant anymore
                    break;
                case Constant.USER_SELECTED_MODIFY:             
                    //TODO implement mopdify question in case of wrong input or answer in the questions!
                    break;
                case Constant.USER_SELECTED_LOAD:
                    //A user can have multiple files of questions so he can load more than one if he wants to (Yet to be implemented)
                    quiz = QuizLogic.LoadQuiz(path);
                    break;
            }
        }

        //TODO store the instructions in the cases into relevant local methods
        private static void HandleManageParticipantsQuizMenu(List<Participant> participants) 
        {
            var menuChoice = RequestUserMenuOptionChoice(Constant.MENU_OPTION_PARTICIPANT_ITEMS);
            string particpantChoiceId = string.Empty; //is the id of the participant selected from the list by the end user
            switch (menuChoice)
            {
                case Constant.USER_SELECTED_CREATE_PARTICIPANT:
                    CreateParticipant();
                    break;
                case Constant.USER_SELECTED_REMOVE_PARTICIPANT:
                    UserInterface.DisplayRemoveProfileText();
                    //list profiles and decide which to remove
                    UserInterface.DisplayProfiles(participants);
                    particpantChoiceId = UserInterface.GetParticipantChoice();
                    //get the particpant based on the his id
                    QuizLogic.RemoveParticipantProfile(int.Parse(particpantChoiceId));          
                    break;
                case Constant.USER_SELECTED_GET_PROFILES:
                    //list profiles and their details
                    UserInterface.DisplayProfiles(participants);
                    break;
                default:
                    break;
            }
            Console.ReadKey();

        }
        private static void HandleScoreQuizMenu()
        {
            var profiles = QuizLogic.GetProfiles();
            UserInterface.DisplayLeaderBoardResult(profiles);
            Console.ReadKey();
        }
        private static void HandlePlayQuizMenu(List<Question> quiz, Participant participant)
        {
            bool sessionActive = QuizLogic.ParticipantExists(participant);

            string menuChoice = RequestUserMenuOptionChoice(Constant.MENU_OPTION_PLAY_ITEMS);
            switch (menuChoice)
            {
                case Constant.USER_SELECTED_SOLO:
                    //TODO: create a function for better readability and also to use it for the multiplayer
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
                        string userDecision = UserInterface.ContinueCurrentLoopSession(Constant.QUESTIONS);

                        sessionActive = QuizLogic.ParticipantWantsToContinue(userDecision);
                    }
                    break;
                case Constant.USER_SELECTED_MULTI:
                    //placeholder for multiplayer
                    break; 
                case Constant.USER_SELECTED_RANDOM:
                    //placeholder for random question
                    break;
                default: 
                    break;
            }            
        }
        private static void CreateQuiz(string path)
        {
            bool creatingNotEnded = true;
            while (creatingNotEnded)
            {
                string questionText = UserInterface.RequestNewQuestion();
                string userDecision;
                Question question = new();
                question.Answers = new();
                QuizLogic.AddNewQuestion(question, questionText);

                bool answerNotEnded = true;

                while (answerNotEnded)
                {
                    Answer answer = new Answer();                    
                    UserInterface.RequestNewAnswer(answer);
              
                    QuizLogic.AddAnswerToQuestion(question, answer);
                    userDecision = UserInterface.ContinueCurrentLoopSession(Constant.ANSWERS);
                    if(!QuizLogic.ParticipantWantsToContinue(userDecision))
                            break;
                }
                QuizLogic.StoreQuiz(question);
                userDecision = UserInterface.ContinueCurrentLoopSession(Constant.QUESTIONS);
                creatingNotEnded = QuizLogic.ParticipantWantsToContinue(userDecision);                    
            }
            QuizLogic.SaveQuiz(path);
        }
        private static void CreateParticipant()
        {
            string name = UserInterface.GetParticipantName();
            int age = UserInterface.GetParticipantAge();
            QuizLogic.RegisterParticipantProfile(name, age);
        }
        private static string RequestUserMenuOptionChoice(string[] options)
        {
            UserInterface.DisplayQuizMenu(options);
            return UserInterface.GetParticipantChoice();
        }
    }
}