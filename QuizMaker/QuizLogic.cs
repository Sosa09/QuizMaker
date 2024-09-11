using System.IO;

namespace QuizMaker
{
    public static class QuizLogic
    {
        static Random _random = new Random();
        static DataHandler _handler = new DataHandler();
        static Question GetRandomQuestion(List<Question> questions)
        {
            int randomQuestionIndex = _random.Next(questions.Count);
            return questions[randomQuestionIndex];
        }
        public static void StoreParticipantAnswer(Question question, Participant participant, Answer answer)
        {
            participant.Result.QuestionAnswered.Add(new Question
            {
                QuestionText = question.QuestionText,
                Answers = new List<Answer> { answer }
            });
        }
        public static void UpdateLastParticipationDate(Participant participant)
        {
            participant.Result.LastParticipationDate = DateTime.Now;
        }

        public static bool IsQuestionAnsweredCorrectly(Answer answer)
        {
            return answer.IsCorrectAnswer;
        }

        public static void AddOnePoint(Participant participant)
        {
            participant.Result.TotalScore++;
        }

        public static Answer GetAnswer(Question question, int particpantAnswerChoice)
        {
            return question.Answers[particpantAnswerChoice];
        }

        public static void SaveQuiz(string path)
        {
            _handler.saveData(path);
        }

        internal static void AddNewQuestion(Question question, string questionText)
        {
            question.QuestionText = questionText;
        }

        internal static void AddAnswerToQuestion(Question question, Answer answer)
        {
            if (question != null)
                if (answer != null)
                    question.Answers = new List<Answer>();
                question.Answers.Add(answer);
        }

        internal static bool IsAnswerTextBlank(string answerText, ref bool answerNotEnded)
        {
            if (answerText == string.Empty)
                return !answerNotEnded;
            return answerNotEnded;
        }

        internal static void StoreQuiz(Question question)
        {
            _handler.Add(question);
        }

        public static List<Question> LoadQuiz(string path)
        {
            _handler.loadData(path);
            return _handler.GetQuestions();
        }

    }
}
