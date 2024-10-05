using System.Diagnostics;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Xml.Serialization;

namespace QuizMaker
{
    public class ProfileHandler : IDataHandler
    {
        List<Participant> _participants;
        public XmlSerializer XmlSerializer { get; set; }

        public ProfileHandler()
        {
            _participants = new List<Participant>();
            XmlSerializer = new XmlSerializer(_participants.GetType());
        }
        public void SaveData(string path)
        {
            FileHandler.WriteToFile(Constant.DEFAULT_PROFILE_FILE_NAME, XmlSerializer, _participants);
        }

        public void LoadData(string externalSource)
        {
            StreamReader reader = FileHandler.GetStreamFromFile(externalSource);
            AddDataFromExternalSource(reader);
            FileHandler.CloseStream(reader);
        }

        public void AddData(IResource resource)
        {
            Participant participant = resource as Participant;
            _participants.Add(participant);
        }

        public void RemoveData(int key)
        {
            var participant = _participants.FirstOrDefault(x => x.Id == key);
            _participants.Remove(participant);
        }

        public Participant GetData<IResource>(int key) where IResource : Participant
        {
            Participant participant = null;
            try
            {
                participant = _participants.First(x => x.Id == key);
            }
            catch (ArgumentNullException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return participant;
        }

        public List<Participant> GetAllData<T>() where T : Participant
        {            
            return _participants;
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
                var profiles = (List<Participant>)XmlSerializer.Deserialize(reader);
                profiles.ForEach(profile => _participants.Add(profile));
            }
        }

        public void RemoveData()
        {
            throw new NotImplementedException();
        }

        T IDataHandler.GetData<T>(int key)
        {
            throw new NotImplementedException();
        }
    }
}
