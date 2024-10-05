using System.Xml.Serialization;

namespace QuizMaker
{
    public interface IDataHandler<T> where T : IResource
    {
        public List<T> Data { get; set; }
        public XmlSerializer XmlSerializer { get; set; }
        public void SaveData(string path);
        public void LoadData(string externalSource);
        public void AddData(T modelName);
        public void RemoveData();
        public void RemoveData(int key);
        public IResource GetData<T>(int key);
        public List<T> GetAllData<T>();
        public void SetData(string key, object value);
        public void AddDataFromExternalSource(StreamReader reader);

    }
}