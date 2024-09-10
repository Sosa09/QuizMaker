using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker
{
    public class ParticipantResult
    {
        public int TotalScore;
        List<Question> QuestionAnswered;
        public DateTime LastParticipationDate;

        public ParticipantResult()
        {
            QuestionAnswered = new List<Question>();
            LastParticipationDate = DateTime.Now;
        }
    }
}
