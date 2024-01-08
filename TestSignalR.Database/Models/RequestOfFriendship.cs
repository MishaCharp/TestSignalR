using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSignalR.Database.Models
{
    public class RequestOfFriendship : NativeEntity
    {
        public int SenderUserId { get; set; }
        public int ReceiverUserId { get; set; }

        public User SenderUser { get; set; }
        public User ReceiverUser { get; set; }

        public string Text { get; set; }

        public override void UpdateProperties(NativeEntity entity)
        {
            if (entity is RequestOfFriendship item)
            {
                SenderUser = item.SenderUser;
                ReceiverUser = item.ReceiverUser;
            }
        }
    }
}
