using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTD.Models.TagModel;
using UTD.Models.UserModel;

namespace UTD.Models.ConversationModel
{
    public class DocumentVersion : Votable
    {
        public string Text { get; set; }
        public User Author { get; set; }
        public DateTime Timestamp { get; } = DateTime.Now;

        public DocumentVersion(User author, string text)
        {
            this.Author = author;
            this.Text = text;
        }

        public static List<DocumentVersion> CreateVersionList(User author, string text)
        {
            return new List<DocumentVersion> { new DocumentVersion(author, text) };
        }
    }
}
