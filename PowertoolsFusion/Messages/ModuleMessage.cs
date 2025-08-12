using BoneLib;
using LabFusion.Entities;
using LabFusion.Network;
using LabFusion.Representation;
using LabFusion.SDK.Modules;
using MelonLoader;
using PowertoolsFusion.Serializables;

namespace PowertoolsFusion.Messages {
    public abstract class ModuleMessage : ModuleMessageHandler{
        public abstract PermissionLevel MinimumPermissionLevel { get; protected set; }
        protected override void OnHandleMessage(ReceivedMessage received) {
            // Get Player Refs
            var data = received.ReadData<MessageNetSerializable>();

            var senderId = data.Sender;
            var message = data.Message;

            NetworkPlayerManager.TryGetPlayer(Player.RigManager, out var receiver);
            NetworkPlayerManager.TryGetPlayer(senderId, out var sender);
            FusionPermissions.FetchPermissionLevel(senderId, out var level, out _);
            bool senderHasPerms = level >= MinimumPermissionLevel || sender.PlayerID == receiver.PlayerID;
            if (senderHasPerms) {
                ReceivedMessageEvent(receiver, sender, message);
            }
        }

        protected virtual void ReceivedMessageEvent(NetworkPlayer receiver, NetworkPlayer sender, string message) {
            MelonLogger.Msg($"Receiver: ({receiver.Username}) Sender: ({sender.Username}) Message: ({message})");
        }
    }
}
