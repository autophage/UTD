using UTD.Models.TagModel;

namespace UTD.Models.ConversationModel
{
    public class ConversationNode : Votable
    {
        public ConversationNode Parent { get; set; }
        List<ConversationNode> Children { get; set; } = new List<ConversationNode>();
        List<DocumentVersion> Versions { get; set; } = new List<DocumentVersion>();

        public ConversationNode()
        {
            this.Parent = this;
        }

        public ConversationNode Reply(DocumentVersion replyContents)
        {
            var reply = new ConversationNode { Parent = this };
            reply.Versions.Add(replyContents);
            this.Children.Append(reply);
            return reply;
        }
    }
}