namespace QuizMaker
{
    public static class Constant
    {
        public const string CONTINUE_QUIZ_CREATION = "Y or N";
        public const string DEFAULT_FILE_NAME = "question.xml";
        public const string DEFAULT_WORKING_PATH = $@"{DEFAULT_FILE_NAME}";
        public readonly static string[] MENU_OPTION_LIST_ITEMS = new string[] { "Play", "Score", "Manage Participants", "Manage Questions"};
        public readonly static string[] MENU_OPTION_PARTICIPANT_ITEMS = new string[] { "Create", "Remove", "Modify" };
        public readonly static string[] MENU_OPTION_PLAY_ITEMS = new string[] { "Solo", "Multi", "Train" };
        public readonly static string[] MENU_OPTION_QUESTION_ITEMS = new string[] { "Create", "Remove", "Modify", "Load"};
        public readonly static string[] MENU_OPTION_SCORE_ITEMS = new string[] { "LeaderBoard", "Progress"};
    }
}
