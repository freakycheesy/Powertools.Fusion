using BoneLib;
using LabFusion.Entities;
using LabFusion.Network;
using LabFusion.Representation;
using LabFusion.SDK.Modules;
using PowerTools.Tools;

namespace PowertoolsFusion.Messages {
    public class FreezeRigMessage : ModuleMessage {
        public override PermissionLevel MinimumPermissionLevel {
            get;
            protected set;
        } = PermissionLevel.OPERATOR;
        protected override void ReceivedMessageEvent(NetworkPlayer localPlayer, NetworkPlayer sender, string message) {
            base.ReceivedMessageEvent(localPlayer, sender, message);
            localPlayer.RigSkeleton.physicsPelvis.isKinematic = !localPlayer.RigSkeleton.physicsPelvis.isKinematic;
        }
    }
}
