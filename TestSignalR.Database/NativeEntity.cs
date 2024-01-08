using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSignalR.Database
{
    public abstract class NativeEntity
    {
        public int Id { get; set; }
        public abstract void UpdateProperties(NativeEntity entity);
    }
}
