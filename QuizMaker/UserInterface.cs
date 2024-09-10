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

        public static string GetUserAnswer()
        {
            Console.WriteLine("Enter your answer by entering the index");
            string answer = Console.ReadLine();
            return answer;
        }

        public static void DisplayParticipantResult(Participant p)
        {
            Console.WriteLine($"Name:               {p.Name}\n" +
                              $"Age:                {p.Age}");
            Console.WriteLine($"Last participated:  {p.Result.LastParticipationDate}");
            Console.WriteLine($"Total score:        {p.Result.TotalScore}");
        }
    }
}
