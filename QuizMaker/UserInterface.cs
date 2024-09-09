using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker
{
    public static class UserInterface
    {
        public static void DisplayQuestions(List<Question> questions)
        {
            foreach (Question question in questions)
            {
                Console.WriteLine(question.ToString());
                foreach(Answer answer in question.Answers)
                {
                    Console.WriteLine(answer.ToString());
                }
            }
        }
    }
}
