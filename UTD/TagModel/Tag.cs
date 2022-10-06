using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTD.Models.UserModel;

namespace UTD.Models.TagModel
{
    public class Tag : Votable
    {
        public Taggable Target { get; set; }
        public User Tagger { get; set; }
        public TagString TagString { get; set; }
    }
}
