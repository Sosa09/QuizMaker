using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker
{
    public static class UserInterface
    {
        public static void DisplayQuestions(Question questions)
        {
            Console.WriteLine(questions.ToString());
            int index = 0;
            foreach (Answer answer in questions.Answers) 
            {
                Console.WriteLine($"{index += 1}: {answer}");
            }
        }

        public static string GetUserAnswer()
        {
            Console.WriteLine("Enter your response to select multiple response use , to seperate them");
            string answer = Console.ReadLine();
            return answer;
        }
    }
}
