using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTD.Models.ConversationModel
{
    public class Conversation : UTDModel
    {
        ConversationNode Root { get; set; }
    }
}
