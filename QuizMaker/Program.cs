namespace QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //BY DEFAULT PATH WILL BE DEFINED BY SYSTEM WHICH IS THE LOCAL WORKING PATH OF THE PROGRAM
            string quizPath = Constant.DEFAULT_QUIZ_FILE_NAME;
            string participantPath = Constant.DEFAULT_PROFILE_FILE_NAME;
            var participants = QuizLogic.LoadProfiles(participantPath);
        
            //CHECKING FOR PARTICIPANT PROFILES (CREATE LOCAL FUNCTION)
            UserInterface.LoadingProfilesText();

            if (QuizLogic.IsProfileListEmpty())
            {
                UserInterface.DisplayMandatoryToCreateProfileMessage();
                ProcessParticipantCreation(participantPath);
            }

            Participant participant = null;
            //Selection of profile (CREATE LOCAL FUNCTION)
            UserInterface.DisplayProfiles(participants);
            ProcessParticpantSelection(ref participant, participantPath);

            while (true)
            {
                UserInterface.DisplayQuizMenu(Constant.MENU_OPTION_HOME_ITEMS);                
                string menuUserChoice = UserInterface.GetParticipantChoice();           
                if (!QuizLogic.IsUserInputValid(menuUserChoice)) 
                {
                    UserInterface.DisplayUserInputIsNotValidNumberMessage(menuUserChoice);
                    continue; 
                }
                if (int.Parse(menuUserChoice) > Constant.MENU_OPTION_HOME_ITEMS_LENGTH) 
                { 
                    UserInterface.DisplayOptionNotFoundMessage(menuUserChoice);
                    continue;
                }
                switch (menuUserChoice)
                {
                    case Constant.USER_SELECTED_PLAY:
                        HandlePlayQuizMenu(participant, quizPath);
                        break;
                    case Constant.USER_SELECTED_SCORE:
                        HandleScoreQuizMenu(participant);
                        break;
                    case Constant.USER_SELECTED_MANAGE_PARTICPANTS:
                        HandleManageParticipantsQuizMenu(participants, participantPath);
                        break;
                    case Constant.USER_SELECTED_MANAGE_QUESTIONS:
                        HandleManageQuestionsQuizMenu(quizPath);
                        break;
                    default:
                        break;
                }
                Console.Clear();
            }
        }
        private static void HandleManageQuestionsQuizMenu(string path)
        {
            bool isBackOptionPressed = false;
            while (!isBackOptionPressed)
            {
                //TODO: Let the user choose a file or quiz he want or maybe some of the questiosn and not all            
                var menuUserChoice = RequestUserMenuOptionChoice(Constant.MENU_OPTION_QUESTION_ITEMS);
                if (!QuizLogic.IsUserInputValid(menuUserChoice))
                {
                    UserInterface.DisplayUserInputIsNotValidNumberMessage(menuUserChoice);
                    continue;
                }
                if (int.Parse(menuUserChoice) > Constant.MENU_OPTION_QUESTION_ITEMS_LENGTH)
                {
                    UserInterface.DisplayOptionNotFoundMessage(menuUserChoice);
                    continue;
                }
                var quiz = QuizLogic.LoadQuiz(path);
                switch (menuUserChoice)
                {
                    case Constant.USER_SELECTED_CREATE:
                        ProcessQuizCreation(path);
                        break;
                    case Constant.USER_SELECTED_REMOVE:
                        //TODO implement remove question if the admin decides it is not relevant anymore
                        break;
                    case Constant.USER_SELECTED_LOAD:
                        //A user can have multiple files of questions so he can load more than one if he wants to (Yet to be implemented)
                        quiz = QuizLogic.LoadQuiz(path);
                        break;
                    case Constant.USER_SELECTED_MAIN_MENU:
                        isBackOptionPressed = true;
                        break;
                    default: break;
                }
                Console.ReadKey();
            }     
        }
        private static void HandleManageParticipantsQuizMenu(List<Participant> participants, string path) 
        {
            bool isBackOptionPressed = false;
            while (!isBackOptionPressed)
            {
                var menuUserChoice = RequestUserMenuOptionChoice(Constant.MENU_OPTION_PARTICIPANT_ITEMS);
                if (!QuizLogic.IsUserInputValid(menuUserChoice))
                {
                    UserInterface.DisplayUserInputIsNotValidNumberMessage(menuUserChoice);
                    continue;
                }
                if (int.Parse(menuUserChoice) > Constant.MENU_OPTION_PARTICIPANT_ITEMS_LENGTH)
                {
                    UserInterface.DisplayOptionNotFoundMessage(menuUserChoice);
                    continue;
                }
                switch (menuUserChoice)
                {
                    case Constant.USER_SELECTED_CREATE_PARTICIPANT:
                        ProcessParticipantCreation(path);
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
                    case Constant.USER_SELECTED_MAIN_MENU:
                        isBackOptionPressed = true;
                        break;
                    default:
                        break;
                }
                Console.ReadKey();
            }
        }
        private static void HandleScoreQuizMenu(Participant p)
        {
            bool isBackOptionPressed = false;
            while(!isBackOptionPressed)
            {           
                string menuChoice = RequestUserMenuOptionChoice(Constant.MENU_OPTION_SCORE_ITEMS);
                if (!QuizLogic.IsUserInputValid(menuChoice))
                {
                    UserInterface.DisplayUserInputIsNotValidNumberMessage(menuChoice);
                    continue;
                }
                switch (menuChoice)
                {
                    case Constant.USER_SELECTED_PARTICIPANT_SCORE:
                        //TODO: display current particpant score per quiz
                        UserInterface.DisplayParticipantResult(p);
                        break;
                    case Constant.USER_SELECTED_LEADERBOARD:
                        //TODO: display all scores with the highest score being on top for all profiles
                        var profiles = QuizLogic.GetProfiles();
                        UserInterface.DisplayLeaderBoardResult(profiles);
                        Console.ReadKey();
                        break;
                    case Constant.USER_SELECTED_MAIN_MENU:
                        isBackOptionPressed = true;
                        break;
                    default : break;
                }
            }
        }
        private static void HandlePlayQuizMenu(Participant participant, string path)
        {
            bool isBackOptionPressed = false;
            while (!isBackOptionPressed)
            {
                var menuUserChoice = RequestUserMenuOptionChoice(Constant.MENU_OPTION_PLAY_ITEMS);
                if (!QuizLogic.IsUserInputValid(menuUserChoice))
                {
                    UserInterface.DisplayUserInputIsNotValidNumberMessage(menuUserChoice);
                    continue;
                }
                if (int.Parse(menuUserChoice) > Constant.MENU_OPTION_PLAY_ITEMS_LENGTH)
                {
                    UserInterface.DisplayOptionNotFoundMessage(menuUserChoice);
                    continue;
                }
                var quiz = QuizLogic.LoadQuiz(path);

                switch (menuUserChoice)
                {
                    case Constant.USER_SELECTED_SOLO:                                        
                        foreach (var question in quiz)
                        {
                            HandlePlayLoop(question, participant);
                        }     
                        break;
                    case Constant.USER_SELECTED_MULTI:
                        //placeholder for multiplayer

                        break;
                    case Constant.USER_SELECTED_RANDOM:
                        var randomQuestion = QuizLogic.GetRandomQuestion();
                        HandlePlayLoop(randomQuestion, participant);

                        break;
                    case Constant.USER_SELECTED_MAIN_MENU:
                        isBackOptionPressed = true;
                        break;
                    default:
                        break;
                }
                Console.ReadKey();
            }            
        }
        private static void ProcessQuizCreation(string path)
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
                    if(!QuizLogic.DoesParticipantWantsToContinue(userDecision))
                            break;
                }
                QuizLogic.StoreQuiz(question);
                userDecision = UserInterface.ContinueCurrentLoopSession(Constant.QUESTIONS);
                creatingNotEnded = QuizLogic.DoesParticipantWantsToContinue(userDecision);                    
            }
            QuizLogic.SaveQuiz(path);
        }
        private static void ProcessParticipantCreation(string path)
        {
            string name = UserInterface.GetParticipantName();
            int age = UserInterface.GetParticipantAge();
            QuizLogic.RegisterParticipantProfile(name, age, path);
        }
        private static void ProcessParticpantSelection(ref Participant participant, string participantPath)
        {
            string participantChoiceId = string.Empty;
            bool userInputNotValidated = true;
            while (userInputNotValidated)
            {                
                participantChoiceId = UserInterface.GetParticipantChoice();
                if (QuizLogic.IsUserInputValid(participantChoiceId))
                {
                    if (participantChoiceId == Constant.CREATE_PROFILE_SELECTED)
                    {
                        ProcessParticipantCreation(participantPath);
                        continue;
                    }
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
        }
        private static string RequestUserMenuOptionChoice(string[] options)
        {
            UserInterface.DisplayQuizMenu(options);
            return UserInterface.GetParticipantChoice();
        }
        private static void HandlePlayLoop(Question q, Participant p)
        {
            while (true)
            {
                UserInterface.DisplayQuestion(q);
                var participantAnswerChoice = UserInterface.GetParticipantAnswer();
                if (!QuizLogic.IsUserInputValid(participantAnswerChoice))
                {
                    UserInterface.DisplayUserInputIsNotValidNumberMessage(participantAnswerChoice);
                    continue;
                }
                if (int.Parse(participantAnswerChoice) >= q.Answers.Count)
                {
                    UserInterface.DisplayOptionNotFoundMessage(participantAnswerChoice);
                    continue;
                }
                else
                {
                    Answer answer = QuizLogic.GetAnswer(q, int.Parse(participantAnswerChoice));
                    QuizLogic.StoreParticipantAnswer(q, p, answer);
                    if (QuizLogic.IsQuestionAnsweredCorrectly(answer))
                        QuizLogic.AddOnePoint(p);
                    break;
                }
            }
            QuizLogic.UpdateLastParticipationDate(p);
            UserInterface.DisplayParticipantResult(p);
        }
    }
}