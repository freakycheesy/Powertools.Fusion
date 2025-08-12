using BoneLib;
using LabFusion.Entities;
using LabFusion.Network;
using LabFusion.Representation;
using LabFusion.SDK.Modules;
using PowertoolsFusion.Serializables;

namespace PowertoolsFusion.Messages {
    public class ModuleMessage : ModuleMessageHandler{
        protected override void OnHandleMessage(ReceivedMessage received) {
            // Get Player Refs
            var data = received.ReadData<SenderNetSerializable>();

            var senderId = data.Sender;

            NetworkPlayerManager.TryGetPlayer(Player.RigManager, out var localPlayer);
            NetworkPlayerManager.TryGetPlayer(senderId, out var sender);
            FusionPermissions.FetchPermissionLevel(senderId, out var level, out _);
            bool senderHasPerms = level >= PermissionLevel.OPERATOR || sender.PlayerID == localPlayer.PlayerID;
            if (senderHasPerms) {
                ReceivedMessageEvent(localPlayer, sender);
            }
        }

        protected virtual void ReceivedMessageEvent(NetworkPlayer localPlayer, NetworkPlayer sender) {
        }
    }
}
