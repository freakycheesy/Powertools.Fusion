using LabFusion.Network.Serialization;
using LabFusion.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowertoolsFusion.Serializables {
    public class MessageNetSerializable : INetSerializable {
        public int? GetSize() => Sender.GetSize() + Message.ToString().GetSize();

        public PlayerID Sender = new();
        public string Message = "1234";

        public void Serialize(INetSerializer serializer) {
            serializer.SerializeValue(ref Sender);
            serializer.SerializeValue(ref Message);
        }
    }
}
