using System.Xml.Serialization;

namespace QuizMaker
{
    public class DataHandler
    {
        private List<Question> _questions;
        private XmlSerializer _xmlSerializer;
        public DataHandler() 
        { 
            _questions = new List<Question>();
            _xmlSerializer = new XmlSerializer(_questions.GetType());
        }
        /// <summary>
        /// add a Question object to the List object
        /// </summary>
        /// <param name="question">object containing all question elements</param>
        public void Add(Question question)
        {
            _questions.Add(question);
        }
        private void AddFromFile(StreamReader reader)
        {
            if (reader != null)
            {
                var questionsFromFile = (List<Question>?)_xmlSerializer.Deserialize(reader);
                foreach (Question question in questionsFromFile)
                    Add(question);
            }

        }
        /// <summary>
        /// Removes a Question object from the List object
        /// </summary>
        /// <param name="question">object containing all question elements</param>
        public void Remove(Question question)
        {
            _questions.Remove(question);
        }
        /// <summary>
        /// clears the question lists
        /// </summary>
        public void Clear()
        {
            _questions.Clear();
        }
        /// <summary>
        /// 
        /// </summary>
        public void loadData(string path)
        {
            StreamReader sr;
            FileHandler.ReadFromFile(path, out sr);
            AddFromFile(sr);
        }
        public void saveData(string path)
        {
            FileHandler.WriteToFile(path, _xmlSerializer, _questions);
        }
        public List<Question> GetQuestions()
        {
            return _questions;
        }
    }
}
