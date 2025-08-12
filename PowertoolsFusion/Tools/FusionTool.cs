using BoneLib;
using LabFusion.Entities;
using LabFusion.Network;
using LabFusion.SDK.Gamemodes;
using PowerTools;
using PowerTools.Tools;
using PowertoolsFusion.Messages;
using PowertoolsFusion.Serializables;
using PowertoolsFusion.Tools.Menus;
using UnityEngine;

namespace Powertools.Fusion.Tools {
    public class FusionTool : BaseTool {
        public override string ToolName => "Fusion Tools";

        public override void BoneMenuCreator() {
            base.BoneMenuCreator();
            new AdminMenu(Page);
        }

        public override void OnSetEnabled(bool value) {
            base.OnSetEnabled(value);
        }

        public override void Reset() {
            base.Reset();
        }

        public static void SendMessage<T>(byte targetId, string message = "", NetworkChannel network = NetworkChannel.Reliable) where T : PowertoolsFusion.Messages.ModuleMessage {
            if (!(NetworkPlayerManager.TryGetPlayer(Player.RigManager, out var sender) && NetworkPlayerManager.TryGetPlayer(targetId, out _)))
                return;
            if (string.IsNullOrEmpty(message))
                message = typeof(T).FullName.ToLower();
;            var data = new MessageNetSerializable() { Sender = sender.PlayerID, Message = message };
            MessageRelay.RelayModule<T, MessageNetSerializable>(data, new MessageRoute(targetId, network));
        }

        public static void SendMessage<T>(RelayType relayType, string message = null, NetworkChannel network = NetworkChannel.Reliable) where T : PowertoolsFusion.Messages.ModuleMessage {
            if (!NetworkPlayerManager.TryGetPlayer(Player.RigManager, out var sender))
                return;
            if (string.IsNullOrEmpty(message))
                message = typeof(T).FullName.ToLower();
            var data = new MessageNetSerializable() { Sender = sender.PlayerID, Message = message};

            MessageRelay.RelayModule<T, MessageNetSerializable>(data, new MessageRoute(relayType, network));
        }
    }
}
