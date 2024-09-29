namespace QuizMaker
{
    public static class Constant
    {
        public const string CONTINUE_QUIZ = "Y or N";
        public const string DEFAULT_QUIZ_FILE_NAME = "question.xml";
        public const string DEFAULT_PROFILE_FILE_NAME = "profiles.xml";
        public const string QUESTIONS = "creating Questions";
        public const string ANSWERS = "creating Answers";
        public const int MAX_PARTICIPANT_RANDOM_IDS = 5000;
        public const string DEFAULT_WORKING_PATH = $@"";
        internal static long XML_FILE_LENGTH_ZERO = 0;

        public readonly static string[] MENU_OPTION_LIST_ITEMS = new string[] { "Play", "Score", "Manage Participants", "Manage Questions"};
        public const string USER_SELECTED_PLAY = "1";
        public const string USER_SELECTED_SCORE = "2";
        public const string USER_SELECTED_MANAGE_PARTICPANTS = "3";
        public const string USER_SELECTED_MANAGE_QUESTIONS = "4";
        
        public readonly static string[] MENU_OPTION_PARTICIPANT_ITEMS = new string[] { "Create", "Remove", "Get Profiles" };
        public const string USER_SELECTED_CREATE = "1";
        public const string USER_SELECTED_REMOVE = "2";
        public const string USER_SELECTED_GET_PROFILES = "3";

        public readonly static string[] MENU_OPTION_PLAY_ITEMS = new string[] { "Solo", "Multi", "Random" };
        public const string USER_SELECTED_SOLO = "1"; 
        public const string USER_SELECTED_MULTI = "2"; 
        public const string USER_SELECTED_RANDOM = "3";

        public readonly static string[] MENU_OPTION_QUESTION_ITEMS = new string[] { "Create", "Remove","Load"};
        public const string USER_SELECTED_CREATE_PARTICIPANT = "1";
        public const string USER_SELECTED_REMOVE_PARTICIPANT = "2";
        public const string USER_SELECTED_LOAD = "3";

        public readonly static string[] MENU_OPTION_SCORE_ITEMS = new string[] { "LeaderBoard", "Progress"};
        public const string USER_SELECTED_LEADERBOARD = "1";
        public const string USER_SELECTED_PROGRESS = "2";
    }
}
