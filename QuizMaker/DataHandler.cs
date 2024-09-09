using System.Xml.Serialization;

namespace QuizMaker
{
    public class DataHandler
    {
        private List<Question> _questions;
        public DataHandler() 
        { 
            _questions = new List<Question>();
        }
        /// <summary>
        /// add a Question object to the List object
        /// </summary>
        /// <param name="question">object containing all question elements</param>
        public void Add(Question question)
        {
            _questions.Add(question);
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
        public void loadData()
        {
            //xml parser deserialize
            FileHandler.ReadFromFile("");
        }
        public void saveData()
        {
            //xml parser serialize
            XmlSerializer xmlSerializer = new XmlSerializer(_questions.GetType());
            xmlSerializer.Serialize(Console.Out, _questions);
            FileHandler.WriteToFile("questions.xml", xmlSerializer, _questions);
        }
    }
}
