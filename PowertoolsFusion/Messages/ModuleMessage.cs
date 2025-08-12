using BoneLib;
using LabFusion.Entities;
using LabFusion.Network;
using LabFusion.Representation;
using LabFusion.SDK.Modules;

namespace PowertoolsFusion.Messages {
    public class ModuleMessage : ModuleMessageHandler{
        protected override void OnHandleMessage(ReceivedMessage received) {
            // Get Player Refs
            NetworkPlayerManager.TryGetPlayer(Player.RigManager, out var localPlayer);
            NetworkPlayerManager.TryGetPlayer(received.Bytes[0], out var receiver);
            NetworkPlayerManager.TryGetPlayer(received.Bytes[1], out var sender);
            FusionPermissions.FetchPermissionLevel(sender.PlayerID, out var level, out _);
            bool isReceivedPlayerLocal = receiver == localPlayer;
            bool hasPerms = level >= PermissionLevel.OPERATOR || sender.PlayerID == receiver.PlayerID;
            if (isReceivedPlayerLocal && hasPerms) {
                ReceivedMessageEvent(localPlayer, sender);
            }
        }

        protected virtual void ReceivedMessageEvent(NetworkPlayer localPlayer, NetworkPlayer sender) {
        }
    }
}
