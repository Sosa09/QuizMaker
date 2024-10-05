using System.Xml.Serialization;

namespace QuizMaker
{
    public interface IDataHandler
    {
        public XmlSerializer XmlSerializer { get; set; }
        public void SaveData(string path);
        public void LoadData(string externalSource);
        public void AddData(IResource modelName);
        public void RemoveData();
        public void RemoveData(int key);
        public T GetData<T>(int key) where T : IResource;
        public List<T> GetAllData<T>() where T : IResource;
        public void SetData(string key, object value);
        public void AddDataFromExternalSource(StreamReader reader);

    }
}