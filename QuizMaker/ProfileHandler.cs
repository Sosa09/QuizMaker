using System.Diagnostics;
using System.Xml.Serialization;

namespace QuizMaker
{
    public class ProfileHandler
    {
        List<Participant> _participants;
        private XmlSerializer _xmlSerializer;

        public ProfileHandler()
        {
            _participants = new List<Participant>();
            _xmlSerializer = new XmlSerializer(_participants.GetType());
        }

        public void SaveProfile()
        {
            FileHandler.WriteToFile(Constant.DEFAULT_PROFILE_FILE_NAME, _xmlSerializer, _participants);
        }

        public void DeleteProfile(int id)
        {
            var participant = _participants.FirstOrDefault(x => x.Id == id);
            _participants.Remove(participant);
        }

        public List<Participant> GetProfiles()
        {

            return _participants;
        }
        public void AddProfile(Participant participant)
        {
            _participants.Add(participant);
        }
        public void AddFromFile(string path)
        {
            Debug.WriteLine(Directory.GetCurrentDirectory());
            StreamReader reader = FileHandler.GetStreamFromFile(path);
            
            if (reader != null && reader.BaseStream.Length != Constant.XML_FILE_LENGTH_ZERO)
            {                
                Debug.WriteLine(reader.ReadLine()); 
                var profiles = (List<Participant>)_xmlSerializer.Deserialize(reader);
                profiles.ForEach(profile => _participants.Add(profile));
            }            
            FileHandler.CloseStream(reader);
        }

        public Participant GetParticipant(int id)
        {
            Participant participant = null;
            try
            {
                participant = _participants.First(x => x.Id == id);
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
    }
}
