using LabFusion.Entities;
using LabFusion.Network.Serialization;
using LabFusion.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowertoolsFusion.Serializables {
    public class SenderNetSerializable : INetSerializable {
        public int? GetSize() => Receiver.GetSize() + Sender.GetSize();

        public PlayerID Receiver = new();
        public PlayerID Sender = new();

        public void Serialize(INetSerializer serializer) {
            serializer.SerializeValue(ref Receiver);
            serializer.SerializeValue(ref Sender);
        }
    }
}
