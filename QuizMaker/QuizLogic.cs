namespace QuizMaker
{
    public static class QuizLogic
    {
        static Random random;
        static Question GetRandomQuestion(List<Question> questions)
        {
            int randomQuestionIndex = random.Next(questions.Count);
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

        public static bool IsQuestionAnsweredCorrectly(Answer answer)
        {
            return answer.IsCorrectAnswer;
        }

        public static void AddOnePoint(Participant participant)
        {
            participant.Result.TotalScore++;
        }
    }
}
