using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTD.Models.ConversationModel;
using UTD.Models.TagModel;

namespace UTD.Models.GoalModel
{
    public class Goal : Votable
    {
        public List<DocumentVersion> Name = new();
        public Conversation Conversation { get; set; } = new Conversation();

        //TODO: Location handling.  Single location for goal?  Multiple?  Edit chain functionality?
    }
}
