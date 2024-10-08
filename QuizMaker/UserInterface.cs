﻿namespace QuizMaker
{
    public static class UserInterface
    {
        public static void DisplayQuestion(Question questions)
        {
            Console.WriteLine(questions.ToString());
            int index = 0;
            foreach (Answer answer in questions.Answers) 
            {
                Console.WriteLine($"{index++}: {answer}");
            }
        }
        public static string GetParticipantAnswer()
        {
            Console.WriteLine("Enter your answer by entering the index");
            string partipantAnswer = Console.ReadLine();
            return partipantAnswer;
        }
        public static void DisplayParticipantResult(Participant p)
        {
            Console.WriteLine(p.ToString());
        }
        public static void DisplayLeaderBoardResult(List<Participant> profiles)
        {
            profiles.ForEach(p => Console.WriteLine(p.ToString()));
        }
        public static void DisplayFeatureNotAvailableMessage()
        {
            Console.WriteLine("The feature you try to access is not available yet, try again with the next version.");
        }
        public static string RequestNewQuestion()
        {
            Console.WriteLine("Enter a Question: ");
            string answer = Console.ReadLine();
            return answer;
        }
        public static Answer RequestNewAnswer(Answer answer)
        {    
            Console.WriteLine("Enter an answer: ");
            answer.AnswerText = Console.ReadLine();

            Console.WriteLine($"is this the correct answer to your question: {Constant.CONTINUE_QUIZ}");
            answer.IsCorrectAnswer = Console.ReadLine() == "Y" ? true : false;

            return answer;
        }
        /// <summary>
        /// Displays the menu with different optiosn such as
        /// Random Question
        /// Create Question
        /// Show LeaderBoard
        /// Save
        /// Load
        /// </summary>
        /// <param name="menuOptions"></param>
        /// <exception cref="NotImplementedException"></exception>
        public static void DisplayQuizMenu(string[] menuOptions)
        {
            Console.Clear();
            int index = 0;
            foreach(string option in menuOptions)
            {
                Console.WriteLine($"{index++}: {option}");
                
            }
        }
        public static string GetParticipantChoice()
        {
            Console.WriteLine("What is your choice? \n");
            return Console.ReadLine();
        }
        public static string GetParticipantName()
        {
            Console.WriteLine("Enter your name: ");
            return Console.ReadLine();
        }
        public static int GetParticipantAge()
        {
            Console.WriteLine("Enter your Age: ");
            return int.Parse(Console.ReadLine());
        }
        internal static string ContinueCurrentLoopSession(string loopName = "")
        {
            Console.WriteLine($"Do you want continue {loopName} ? {Constant.CONTINUE_QUIZ}");
            string particpantAnswer = Console.ReadLine();
            return particpantAnswer;
        }
        internal static void LoadingProfilesText()
        {
            Console.WriteLine($"Getting Profiles from {Constant.DEFAULT_PROFILE_FILE_NAME}");
        }
        internal static void DisplayMandatoryToCreateProfileMessage()
        {
            Console.Clear();
            Console.WriteLine("No profiles were found to start the game please create a profile.");
        }
        internal static void DisplayProfiles(List<Participant> participants)
        {
            Console.Clear();
            Console.WriteLine($"Profies found in {Constant.DEFAULT_PROFILE_FILE_NAME}");
            Console.WriteLine("ID: 0: CREATE");
            foreach (Participant participant in participants)
            {
                Console.WriteLine($"ID: {participant.Id}: {participant.Name}");
            }
        }
        internal static void DisplayRemoveProfileText()
        {
            Console.WriteLine("which one do you want to remove :");
        }
        internal static void DisplayQuestionsNotFoundMessage()
        {
            Console.Clear();
            Console.WriteLine("No questions were found please proceed to create question first.");
        }
        internal static void DisplayProfileNotFoundMessage(string participantChoiceId)
        {
            Console.Clear();
            Console.Error.WriteLine($"Profile with id {participantChoiceId} not found, Try again");
            Console.ReadKey();
        }
        internal static void DisplayUserInputIsNotValidNumberMessage(string userInput)
        {
            Console.Clear();
            Console.Error.WriteLine($"{userInput} not a valid number!, Try again");
            Console.ReadKey();
        }
        internal static void DisplayOptionNotFoundMessage(string userInput)
        {
            Console.Clear();
            Console.Error.WriteLine($"{userInput} not found, Try again");
            Console.ReadKey();
        }
    }
}
