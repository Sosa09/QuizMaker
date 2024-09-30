namespace QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //BY DEFAULT PATH WILL BE DEFINED BY SYSTEM WHICH IS THE LOCAL WORKING PATH OF THE PROGRAM
            string quizPath = Constant.DEFAULT_QUIZ_FILE_NAME;
            var participants = QuizLogic.LoadProfiles(Constant.DEFAULT_PROFILE_FILE_NAME);
            bool userPressedBack = false; //
            //CHECKING FOR PARTICIPANT PROFILES (CREATE LOCAL FUNCTION)
            UserInterface.LoadingProfilesText();

            if (QuizLogic.ProfileListEmpty())
            {
                UserInterface.MandatoryProfileCreactionText();
                CreateParticipant();
            }

            string participantChoiceId = string.Empty;
            Participant participant = null;
            bool userInputNotValidated = true;
            while (userInputNotValidated)
            {
                //Selection of profile (CREATE LOCAL FUNCTION)
                UserInterface.DisplayProfiles(participants);
                participantChoiceId = UserInterface.GetParticipantChoice();
                if (QuizLogic.UserInputIsValidated(participantChoiceId))
                {                    
                    participant = QuizLogic.SelectProfile(int.Parse(participantChoiceId));
                    if (participant == Constant.PARTICPANT_NOT_FOUND)
                    {
                        UserInterface.DisplayProfileNotFoundMessage(participantChoiceId);
                        continue;
                    }
                    userInputNotValidated = false;
                    continue;
                }
                UserInterface.DisplayUserInputIsNotValidNumberMessage(participantChoiceId);                
            }
            
            while (true)
            {
                UserInterface.DisplayMenuOptions(Constant.MENU_OPTION_HOME_ITEMS);
                string menuUserChoice = UserInterface.GetParticipantChoice();
                if (!QuizLogic.UserInputIsValidated(menuUserChoice)) 
                {
                    UserInterface.DisplayUserInputIsNotValidNumberMessage(menuUserChoice);
                    continue; 
                }
                if (int.Parse(menuUserChoice) > Constant.MENU_OPTION_HOME_MAX_INDEX) 
                { 
                    UserInterface.DisplayOptionNotFoundMessage(menuUserChoice);
                    continue;
                }
                switch (menuUserChoice)
                {
                    case Constant.USER_SELECTED_PLAY:
                        HandlePlayQuizMenu(participant, quizPath, userPressedBack);
                        break;
                    case Constant.USER_SELECTED_SCORE:
                        HandleScoreQuizMenu(userPressedBack);
                        break;
                    case Constant.USER_SELECTED_MANAGE_PARTICPANTS:
                        HandleManageParticipantsQuizMenu(participants, userPressedBack);
                        break;
                    case Constant.USER_SELECTED_MANAGE_QUESTIONS:
                        HandleManageQuestionsQuizMenu(quizPath, userPressedBack);
                        break;
                    default:
                        break;
                }
                Console.Clear();
            }
        }
        private static void HandleManageQuestionsQuizMenu(string path, bool userPressedBack)
        {
            while (!userPressedBack)
            {
                //TODO: Let the user choose a file or quiz he want or maybe some of the questiosn and not all            
                var menuUserChoice = RequestUserMenuOptionChoice(Constant.MENU_OPTION_QUESTION_ITEMS);
                if (!QuizLogic.UserInputIsValidated(menuUserChoice))
                {
                    UserInterface.DisplayUserInputIsNotValidNumberMessage(menuUserChoice);
                    continue;
                }
                if (int.Parse(menuUserChoice) > Constant.MENU_OPTION_QUESTION_MAX_INDEX)
                {
                    UserInterface.DisplayOptionNotFoundMessage(menuUserChoice);
                    continue;
                }
                var quiz = QuizLogic.LoadQuiz(path); //TODO: repetitive code with line 110
                switch (menuUserChoice)
                {
                    case Constant.USER_SELECTED_CREATE:
                        CreateQuiz(path);
                        break;
                    case Constant.USER_SELECTED_REMOVE:
                        //TODO implement remove question if the admin decides it is not relevant anymore
                        break;
                    case Constant.USER_SELECTED_LOAD:
                        //A user can have multiple files of questions so he can load more than one if he wants to (Yet to be implemented)
                        quiz = QuizLogic.LoadQuiz(path);
                        break;
                    case Constant.USER_SELECTED_BACK_TO_MAIN_MENU:
                        userPressedBack = true;
                        break;
                    default:
                        break;
                }

            }     
        }
        private static void HandleManageParticipantsQuizMenu(List<Participant> participants, bool userPressedBack) 
        {
            while (!userPressedBack)
            {
                var menuUserChoice = RequestUserMenuOptionChoice(Constant.MENU_OPTION_PARTICIPANT_ITEMS);
                if (!QuizLogic.UserInputIsValidated(menuUserChoice))
                {
                    UserInterface.DisplayUserInputIsNotValidNumberMessage(menuUserChoice);
                    continue;
                }
                if (int.Parse(menuUserChoice) > Constant.MENU_OPTION_PARTICIPANT_MAX_INDEX)
                {
                    UserInterface.DisplayOptionNotFoundMessage(menuUserChoice);
                    continue;
                }
                switch (menuUserChoice)
                {
                    case Constant.USER_SELECTED_CREATE_PARTICIPANT:
                        CreateParticipant();
                        break;
                    case Constant.USER_SELECTED_REMOVE_PARTICIPANT:
                        UserInterface.DisplayRemoveProfileText();
                        //list profiles and decide which to remove
                        UserInterface.DisplayProfiles(participants);
                        string particpantChoiceId = UserInterface.GetParticipantChoice();
                        //get the particpant based on the his id
                        QuizLogic.RemoveParticipantProfile(int.Parse(particpantChoiceId));
                        break;
                    case Constant.USER_SELECTED_GET_PROFILES:
                        //list profiles and their details
                        UserInterface.DisplayProfiles(participants);
                        break;
                    case Constant.USER_SELECTED_BACK_TO_MAIN_MENU:
                        userPressedBack = true;
                        break;
                    default:
                        break;
                }
  
            }
        }
        private static void HandleScoreQuizMenu(bool userPressedBack)
        {
            var profiles = QuizLogic.GetProfiles();
            UserInterface.DisplayLeaderBoardResult(profiles);
            Console.ReadKey();
        }
        private static void HandlePlayQuizMenu(Participant participant, string path, bool userPressedBack)
        {
            while (!userPressedBack)
            {
                var menuUserChoice = RequestUserMenuOptionChoice(Constant.MENU_OPTION_PLAY_ITEMS);
                if (!QuizLogic.UserInputIsValidated(menuUserChoice))
                {
                    UserInterface.DisplayUserInputIsNotValidNumberMessage(menuUserChoice);
                    continue;
                }
                if (int.Parse(menuUserChoice) > Constant.MENU_OPTION_PLAY_MAX_INDEX)
                {
                    UserInterface.DisplayOptionNotFoundMessage(menuUserChoice);
                    continue;
                }
                var quiz = QuizLogic.LoadQuiz(path); //TODO: repetitive code with line 52
                switch (menuUserChoice)
                {
                    case Constant.USER_SELECTED_SOLO:
                        //TODO: create a function for better readability and also to use it for the multiplayer                
                        foreach (var q in quiz)
                        {
                            Console.Clear();
                            while (true)
                            {
                                UserInterface.DisplayQuestion(q);
                                var participantAnswerChoice = UserInterface.GetParticipantAnswer();
                                if(!QuizLogic.UserInputIsValidated(participantAnswerChoice))
                                {
                                    UserInterface.DisplayUserInputIsNotValidNumberMessage(participantAnswerChoice);
                                    continue;
                                }
                                if(int.Parse(participantAnswerChoice) >= q.Answers.Count)
                                {
                                    UserInterface.DisplayOptionNotFoundMessage(participantAnswerChoice);
                                    continue;
                                }
                                Answer answer = QuizLogic.GetAnswer(q, int.Parse(participantAnswerChoice));
                                QuizLogic.StoreParticipantAnswer(q, participant, answer);
                                if (QuizLogic.IsQuestionAnsweredCorrectly(answer))
                                    QuizLogic.AddOnePoint(participant);
                                break;
                            }          
                        }
                        QuizLogic.UpdateLastParticipationDate(participant);
                        UserInterface.DisplayParticipantResult(participant);
                        break;
                    case Constant.USER_SELECTED_MULTI:
                        //placeholder for multiplayer
                        break;
                    case Constant.USER_SELECTED_RANDOM:
                        //placeholder for random question
                        break;
                    case Constant.USER_SELECTED_BACK_TO_MAIN_MENU:
                        userPressedBack = true;
                        break;
                    default:
                        break;
                }
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
            UserInterface.DisplayMenuOptions(options);
            return UserInterface.GetParticipantChoice();
        }
    }
}