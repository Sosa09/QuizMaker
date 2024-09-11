namespace QuizMaker
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
            Console.WriteLine($"Name:               {p.Name}\n" +
                              $"Age:                {p.Age}");
            Console.WriteLine($"Last participated:  {p.Result.LastParticipationDate}");
            Console.WriteLine($"Total score:        {p.Result.TotalScore}");
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

            Console.WriteLine($"is this the correct answer to your question: {Constant.CONTINUE_QUIZ_CREATION}");
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
        private static void DisplayQuizMenu(List<string> menuOptions)
        {
            throw new NotImplementedException();
        }
    }
}
