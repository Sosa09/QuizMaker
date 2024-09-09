using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker
{
    public class Question
    {
        public string QuestionText;
        public List<Answer> Answers;
        public override string ToString()
        {
            return QuestionText;
        }
    }
}
