using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TestSignalR.Database.Models
{
    public class DialogMessage : NativeEntity
    {
        public Dialog Dialog { get; set; }

        public int MessageId { get; set; }
        public Message Message { get; set; }

        public override void UpdateProperties(NativeEntity entity)
        {
            if (entity is DialogMessage item)
            {
                Dialog = item.Dialog;
                Message = item.Message;
            }
        }
    }
}
