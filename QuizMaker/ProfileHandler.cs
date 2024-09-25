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

        public void UpdateProfile(Participant participant)
        {
            //_participants.Select(x => x.Equals(participant));
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
            StreamReader reader = FileHandler.GetStreamFromFile(path); ;            
            var profiles = (List<Participant>)_xmlSerializer.Deserialize(reader);
            profiles.ForEach(profile => _participants.Add(profile));
            FileHandler.CloseStream(reader);
        }

        public Participant GetParticipant(int id)
        {
            return _participants.First(x => x.Id == id);
        }
    }
}
