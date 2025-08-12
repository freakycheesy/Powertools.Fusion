using BoneLib;
using BoneLib.Notifications;
using LabFusion.Entities;
using LabFusion.Network;
using LabFusion.Representation;
using LabFusion.Safety;
using LabFusion.SDK.Modules;
using PowerTools;
using PowerTools.Tools;

namespace PowertoolsFusion.Messages {
    public class NotifcationMessage : ModuleMessage {
        public override PermissionLevel MinimumPermissionLevel {
            get;
            protected set;
        } = PermissionLevel.GUEST;

        protected override void ReceivedMessageEvent(NetworkPlayer localPlayer, NetworkPlayer sender, string message) {
            base.ReceivedMessageEvent(localPlayer, sender, message);
            foreach (var Profanity in ProfanityListManager.List.Words)
                message = message.Contains(Profanity) ? "CENSORED" : message;
            Notifier.Send(new() {
                Title = sender.Username,
                Message = $"{sender.Username} says: \"{message}\"",
            });
        }
    }
}
