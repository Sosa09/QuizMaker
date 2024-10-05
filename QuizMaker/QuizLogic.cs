namespace QuizMaker
{
    public static class QuizLogic
    {
        static readonly Random _random = new Random();
        static readonly DataHandler<Question> _questionDataHandler = new DataHandler<Question>();
        static readonly DataHandler<Participant> _participantDataHandler = new DataHandler<Participant>();
        public static Question GetRandomQuestion()
        {
            var questions = _questionDataHandler.GetAllData();
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
            _questionDataHandler.SaveData(path);
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
            _questionDataHandler.AddData(question);
        }

        public static List<Question> LoadQuiz(string path)
        {
            _questionDataHandler.LoadData(path);
            return _questionDataHandler.GetAllData();
        }
        public static List<Participant> LoadProfiles(string path)
        {
            _participantDataHandler.LoadData(path);
            return _participantDataHandler.GetAllData();
        }
        public static void UpdateParticipantProfile(int id,string name, int age)
        {
            var participant = _participantDataHandler.GetData(id);
            participant.Name = name;
            participant.Age = age;
        }
        public static void RegisterParticipantProfile(string name, int age, string path)
        {
            Participant participant = new();
            participant.Id = _random.Next(0,Constant.MAX_PARTICIPANT_RANDOM_IDS);
            participant.Name = name;
            participant.Age = age;
            participant.Result = new ParticipantResult();
            _participantDataHandler.AddData(participant);     
        }

        public static bool ParticipantWantsToContinue(string decision)
        {
            return decision != null && decision == "Y" ? true : false;
        }

        internal static bool ParticipantExists(Participant participant)
        {
            return participant != null;
        }

        public static Participant GetParticipantProfile(int id)
        {
            return _participantDataHandler.GetData(id);
        }
        public static void RemoveParticipantProfile(int id)
        {
            _participantDataHandler.RemoveData(id);
        }
        public static void SaveProfile(string path)
        {
            _participantDataHandler.SaveData(path);
        }
        public static bool IsProfileListEmpty()
        {
            return _participantDataHandler.GetAllData().Count() == 0;
        }
        internal static List<Participant> GetProfiles()
        {
            return _participantDataHandler.GetAllData();
        }
        internal static Participant? SelectProfile(int particpantChoiceId)
        {
            return _participantDataHandler.GetData(particpantChoiceId);
        }

        public static bool IsUserInputValid(string choice)
        {
            return int.TryParse(choice, out _);
        }
    }
}
