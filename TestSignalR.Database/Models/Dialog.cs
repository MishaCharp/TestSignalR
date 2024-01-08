using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TestSignalR.Database.Models
{
    public class Dialog : NativeEntity
    {
        public Friendship Friendship { get; set; }
        public Message LastMessage { get; set; }


        [JsonIgnore]
        public List<DialogMessage> DialogMessages { get; set; }

        public override void UpdateProperties(NativeEntity entity)
        {
            if (entity is Dialog item)
            {
                Friendship = item.Friendship;
                LastMessage = item.LastMessage;
            }
        }
    }
}
