using BoneLib;
using LabFusion.Entities;
using LabFusion.Network;
using LabFusion.Representation;
using LabFusion.SDK.Modules;
using PowerTools.Tools;

namespace PowertoolsFusion.Messages {
    public class KillMessage : ModuleMessage {
        public override PermissionLevel MinimumPermissionLevel {
            get;
            protected set;
        } = PermissionLevel.OPERATOR;

        protected override void ReceivedMessageEvent(NetworkPlayer localPlayer, NetworkPlayer sender, string message) {
            base.ReceivedMessageEvent(localPlayer, sender, message);
            localPlayer.RigSkeleton.health?.Dying(100f);
            localPlayer.RigSkeleton.health?.Death();
            localPlayer.RigSkeleton.health?.Respawn();
        }
    }
}
