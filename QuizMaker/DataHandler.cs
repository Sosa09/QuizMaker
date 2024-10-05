using System.Diagnostics;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Xml.Serialization;

namespace QuizMaker
{
    public class DataHandler<T> : IDataHandler<T> where T : IResource
    {
 
        public XmlSerializer XmlSerializer { get; set; }
        public List<T> Data { get; set; }

        public DataHandler()
        {
            Data = new List<T>();
            XmlSerializer = new XmlSerializer(Data.GetType());
        }
        public void SaveData(string path)
        {
            FileHandler.WriteToFile(Constant.DEFAULT_PROFILE_FILE_NAME, XmlSerializer, Data);
        }

        public void LoadData(string externalSource)
        {
            StreamReader reader = FileHandler.GetStreamFromFile(externalSource);
            AddDataFromExternalSource(reader);
            FileHandler.CloseStream(reader);
        }

        public void AddData(T data)
        {
            Data.Add(data);
        }

        public void RemoveData(int key)
        {
            var participant = Data.FirstOrDefault(x => x.Id == key);
            Data.Remove(participant);
        }

        public T GetData(int key)
        {
            T collection = default(T);
            try
            {
                collection = Data.First(x => x.Id == key);

            }
            catch (ArgumentNullException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return collection;
            
        }
        public List<T> GetAllData()
        {
            return Data;
        }
        public void SetData(string key, object value)
        {
            throw new NotImplementedException();
        }

        public void AddDataFromExternalSource(StreamReader reader)
        {
            if (reader != null && reader.BaseStream.Length != Constant.XML_FILE_LENGTH_ZERO)
            {
                Debug.WriteLine(reader.ReadLine());
                var elements = (List<T>)XmlSerializer.Deserialize(reader);
                elements.ForEach(profile => Data.Add(profile));
            }
        }

        public void RemoveData()
        {
            throw new NotImplementedException();
        }

    }
}
