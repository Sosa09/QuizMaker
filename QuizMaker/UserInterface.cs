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

        public static string RequestNewQuestion()
        {
            Console.WriteLine("Enter a Question: ");
            string answer = Console.ReadLine();
            return answer;
        }

        public static Answer RequestNewAnswer(Answer answer)
        {    
            Console.WriteLine("Enter an answer: (LEAVE IT BLANK TO END)");
            answer.AnswerText = Console.ReadLine();

            Console.WriteLine("is this the correct answer to your question: Y or N");
            answer.IsCorrectAnswer = Console.ReadLine() == "Y" ? true : false;

            return answer;
        }
    }
}
