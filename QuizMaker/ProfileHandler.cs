using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker
{
    internal class ProfileHandler
    {
        List<Participant> _participants = new List<Participant>();
        public void CreateProfile(Participant participant)
        {

        }

        public void UpdateProfile(Participant participant)
        {

        }

        public void DeleteProfile(Participant participant)
        {

        }

        public List<Participant> GetProfiles()
        {
            return _participants;
        }
        public void AddParticipant(Participant participant)
        {

        }

        public Participant GetParticipant(int id )
        {
            return _participants[id];
        }
    }
}
