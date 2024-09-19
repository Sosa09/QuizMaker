using System.IO;

namespace QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //BY DEFAULT PATH WILL BE DEFINED BY SYSTEM WHICH IS THE LOCAL WORKING PATH OF THE PROGRAM
            string path = Constant.DEFAULT_WORKING_PATH;
            //SELECT THE PROFILE YOU WANT TO PLAY 
            Participant participant = null;

            List<Participant> participants = QuizLogic.LoadProfiles();
            //CHECKING FOR PARTICIPANT PROFILES
            UserInterface.LoadingProfilesText();

            if (QuizLogic.ProfileListEmpty())
            {
                UserInterface.MandatoryProfileCreactionText();
                CreateParticipant();
            }



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
                        if (participant == null)
                        {
                            participant = profileHandler.GetProfiles()[0];
                        }
                        HandlePlayQuizMenu(quiz, participant);
                        break;
                    case "1":
                        HandleScoreQuizMenu();
                        break;
                    case "2":
                        HandleManageParticipantsQuizMenu();
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
        private static void CreateParticipant()
        {
            string name = UserInterface.GetParticipantName();
            int age = UserInterface.GetParticipantAge();
            var participant = QuizLogic.RegisterParticipant(name, age);
        }
        //TODO PUT ALL CASES INTO FUNCTIONS DEPENDING IF IT IS LOGIC OR INTERFACE
        private static void HandleManageParticipantsQuizMenu()
        {
            UserInterface.DisplayQuizMenu(Constant.MENU_OPTION_PARTICIPANT_ITEMS);
            string choice = UserInterface.GetParticipantMenuChoice();
       
            switch (choice)
            {
                case "0":
                    CreateParticipant();
                    break;
                case "1":
                    //list profiles and decide which to remove
                    profileHandler.GetProfiles().ForEach(x => Console.WriteLine(x.Name));
                    Console.WriteLine("which one do you want to remove ?:");
                    //get the id of the particpant you wnat the profile to be removed
                    var particpantId = Console.ReadLine();
                    //get the particpant based on the his id
                    var participantToDelete = profileHandler.GetParticipant(int.Parse(particpantId));
                    //remove ht e participant from the list
                    profileHandler.DeleteProfile(participantToDelete);
                    break;
                case "2":
                    //list profiles and decide which to remove
                    profileHandler.GetProfiles().ForEach(x => Console.WriteLine(x.Name));
                    Console.WriteLine("which one do you want to remove ?:");
                    //get the id of the particpant you wnat the profile to be removed
                    particpantId = Console.ReadLine();
                    //get the particpant based on the his id
                    var participantToModify = profileHandler.GetParticipant(int.Parse(particpantId));
                    name = UserInterface.GetParticipantName();
                    age = UserInterface.GetParticipantAge();
                    participantToModify.Name = name;
                    participantToModify.Age = age;

                    break;
                case "3":
                    //list profiles and decide which to remove
                    profileHandler.GetProfiles().ForEach(x => Console.WriteLine(x.Name));
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

    }
}