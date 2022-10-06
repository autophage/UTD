using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTD.Models.ConversationModel;

namespace UTD.Models.UserModel
{
    public class User : UTDModel
    {
        public List<DocumentVersion> UserName { get; set; } = new();
        public List<User> UsersVouchedFor { get; set; } = new();
        public List<User> VouchedForBy { get; set; } = new();
    }
}
