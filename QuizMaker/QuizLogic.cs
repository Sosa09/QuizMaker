using System.IO;

namespace QuizMaker
{
    public static class QuizLogic
    {
        static Random _random = new Random();
        static DataHandler _handler = new DataHandler();
        static ProfileHandler _profileHandler = new ProfileHandler();
        public static Question GetRandomQuestion()
        {
            var questions = _handler.GetQuestions();
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
            _handler.SaveData(path);
        }

        public static void AddNewQuestion(Question question, string questionText)
        {
            question.QuestionText = questionText;
        }

        public static void AddAnswerToQuestion(Question question, Answer answer)
        {
            if (question != null && answer != null)
                question.Answers.Add(answer);
        }

        public static bool IsAnswerTextBlank(string answerText, ref bool answerNotEnded)
        {
            if (answerText == string.Empty)
                return !answerNotEnded;
            return answerNotEnded;
        }

        public static void StoreQuiz(Question question)
        {
            _handler.Add(question);
        }

        public static List<Question> LoadQuiz(string path)
        {
            _handler.LoadData(path);
            return _handler.GetQuestions();
        }

        public static Participant RegisterParticipant(string name, int age)
        {
            Participant participant = new();
            participant.Name = name;
            participant.Age = age;
            participant.Result = new ParticipantResult();
            return participant;
        }

        public static bool ParticipantWantsToContinue(string decision)
        {
            return decision != null && decision == "N" ? true : false;
        }

        internal static bool ParticipantExists(Participant participant)
        {
            return participant != null;
        }

        public static Participant LoadParticipantProfile(int id)
        {
            return _profileHandler.GetParticipant(id);
        }
        public static void SaveProfile()
        {
            _profileHandler.SaveProfile();
        }
        public static bool ProfileListEmpty()
        {
            return _profileHandler.GetProfiles().Count() == 0;
        }
        internal static List<Participant> LoadProfiles()
        {
            return _profileHandler.GetProfiles();
        }
    }
}
