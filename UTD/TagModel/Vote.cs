using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTD.Models.UserModel;

namespace UTD.Models.TagModel
{
    public class Vote : Tag
    {
        public VoteType Type { get; set; }
    }

    public enum VoteType
    {
        Up,
        Down
    }
}
