namespace QuizMaker
{
    public static class Constant
    {
        public const string CONTINUE_QUIZ = "Y or N";
        public const string DEFAULT_QUIZ_FILE_NAME = "question.xml";
        public const string DEFAULT_PROFILE_FILE_NAME = "profiles.xml";
        public const string QUESTIONS = "creating Questions";
        public const string ANSWERS = "creating Answers";
        public const string DEFAULT_WORKING_PATH = $@"{DEFAULT_QUIZ_FILE_NAME}";
        public readonly static string[] MENU_OPTION_LIST_ITEMS = new string[] { "Play", "Score", "Manage Participants", "Manage Questions"};
        public readonly static string[] MENU_OPTION_PARTICIPANT_ITEMS = new string[] { "Create", "Remove", "Modify", "Get" };
        public readonly static string[] MENU_OPTION_PLAY_ITEMS = new string[] { "Solo", "Multi", "Random" };
        public readonly static string[] MENU_OPTION_QUESTION_ITEMS = new string[] { "Create", "Remove", "Modify", "Load"};
        public readonly static string[] MENU_OPTION_SCORE_ITEMS = new string[] { "LeaderBoard", "Progress"};
    }
}
