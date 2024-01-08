using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TestSignalR.Database.Models
{
    public class Message : NativeEntity
    {
        public User SenderUser { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }

        [JsonIgnore]
        public List<Dialog> Dialogs { get; set; }
        [JsonIgnore]
        public List<DialogMessage> DialogMessages { get; set; }

        public override void UpdateProperties(NativeEntity entity)
        {
            if (entity is Message item)
            {
                SenderUser = item.SenderUser;
                Text = item.Text;
                DateTime = item.DateTime;
            }
        }
    }
}
