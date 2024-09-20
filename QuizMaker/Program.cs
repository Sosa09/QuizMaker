using System.IO;

namespace QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //BY DEFAULT PATH WILL BE DEFINED BY SYSTEM WHICH IS THE LOCAL WORKING PATH OF THE PROGRAM
            string path = Constant.DEFAULT_WORKING_PATH;


            List<Participant> participants = QuizLogic.LoadProfiles();

            //CHECKING FOR PARTICIPANT PROFILES (CREATE LOCAL FUNCTION)
            UserInterface.LoadingProfilesText();

            if (QuizLogic.ProfileListEmpty())
            {
                UserInterface.MandatoryProfileCreactionText();
                CreateParticipant();
            }

            //Selection of profille (CREATE LOCAL FUNCTION)
            UserInterface.DisplayProfiles(participants);
            var particpantChoiceId = UserInterface.GetParticipantChoice();
            var participant = QuizLogic.SelectProfile(int.Parse(particpantChoiceId));
            
            //CHECKING FOR QUIZ LIST (CREATE LOCAL FUNCTION)
            var quiz = QuizLogic.LoadQuiz(path);
            if(quiz.Count == 0) 
                CreateQuiz(path);
      
            while (true)
            {
                UserInterface.DisplayQuizMenu(Constant.MENU_OPTION_LIST_ITEMS);
                string choice = UserInterface.GetParticipantChoice();
                switch (choice)
                {
                    case "0":
                        HandlePlayQuizMenu(quiz, participant);
                        break;
                    case "1":
                        HandleScoreQuizMenu();
                        break;
                    case "2":
                        HandleManageParticipantsQuizMenu(participants);
                        break;
                    case "3":
                        HandleManageQuestionsQuizMenu(path);
                        break;
                    default:
                        break;
                }
                Console.Clear();
            }
        }

        private static void HandleManageQuestionsQuizMenu(string path)
        {
            CreateQuiz(path);
        }

        //TODO PUT ALL CASES INTO FUNCTIONS DEPENDING IF IT IS LOGIC OR INTERFACE
        private static void HandleManageParticipantsQuizMenu(List<Participant> participants) 
        {
            UserInterface.DisplayQuizMenu(Constant.MENU_OPTION_PARTICIPANT_ITEMS);
            string menuChoice = UserInterface.GetParticipantChoice();
            string particpantChoiceId = string.Empty; //is the id of the participant selected from the list by the end user
            switch (menuChoice)
            {
                case "0":
                    CreateParticipant();
                    break;
                case "1":
                    UserInterface.DisplayRemoveProfileText();
                    //list profiles and decide which to remove
                    UserInterface.DisplayProfiles(participants);
                    particpantChoiceId = UserInterface.GetParticipantChoice();

                    //get the particpant based on the his id
                    QuizLogic.RemoveParticipantProfile(int.Parse(particpantChoiceId));
          
                    break;
                case "2":
                    //lists all profiles and lets the end user select a profile he wants to modify.
                    //ask to reenter name and age but RESULTS cannot be modified to avoid cheating
                    UserInterface.DisplayProfiles(participants);
                    particpantChoiceId = UserInterface.GetParticipantChoice();
                    string name = UserInterface.GetParticipantName();
                    int age = UserInterface.GetParticipantAge();
                    QuizLogic.UpdateParticipantProfile(int.Parse(particpantChoiceId), name, age);
                    break;
                case "3":
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
            throw new NotImplementedException();
        }

        private static void HandlePlayQuizMenu(List<Question> quiz, Participant participant)
        {
            bool sessionActive = QuizLogic.ParticipantExists(participant);
            
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

                sessionActive = !QuizLogic.ParticipantWantsToContinue(userDecision);
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
                creatingNotEnded = !QuizLogic.ParticipantWantsToContinue(userDecision);
                    
            }
            QuizLogic.SaveQuiz(path);
        }
        private static void CreateParticipant()
        {
            string name = UserInterface.GetParticipantName();
            int age = UserInterface.GetParticipantAge();
            QuizLogic.RegisterParticipantProfile(name, age);
        }
    }
}