using System.IO;
using System.Xml.Serialization;

namespace QuizMaker
{
    public class QuestionHandler : IDataHandler
    {
        private List<Question> _questions;


        public XmlSerializer XmlSerializer { get;  set; }

        public QuestionHandler() 
        { 
            _questions = new List<Question>();
            XmlSerializer = new XmlSerializer(_questions.GetType());
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
        public void LoadData(string path)
        {
            StreamReader sr = FileHandler.GetStreamFromFile(path);
            AddFromFile(sr);
            FileHandler.CloseStream(sr);
        }


        public void SaveData(string path)
        {
            //TODO make sure file is not in use by another process
            FileHandler.WriteToFile(path, XmlSerializer, _questions);
        }

        public void AddData(Question modelName)
        {
            throw new NotImplementedException();
        }

        public void RemoveData()
        {
            throw new NotImplementedException();
        }

        public void RemoveData(int key)
        {
            throw new NotImplementedException();
        }

        public Question GetData(int key)
        {
            throw new NotImplementedException();
        }

        public List<Question> GetAllData()
        {
            throw new NotImplementedException();
        }

        public void SetData(string key, object value)
        {
            throw new NotImplementedException();
        }

        public void AddDataFromExternalSource(StreamReader reader)
        {
            if (reader != null && reader.BaseStream.Length != Constant.XML_FILE_LENGTH_ZERO)
            {
                var questionsFromFile = (List<Question>?)XmlSerializer.Deserialize(reader);
                foreach (Question question in questionsFromFile)
                    Add(question);
            }
        }

        public void AddData<Question>(Question modelName)
        {
            throw new NotImplementedException();
        }

        public Question GetData<T>(int key)
        {
            throw new NotImplementedException();
        }

        public List<Question> GetAllData<T>()
        {
            return _questions;
        }
    }
}
