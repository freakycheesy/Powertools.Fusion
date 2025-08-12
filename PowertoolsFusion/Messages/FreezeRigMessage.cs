using BoneLib;
using LabFusion.Entities;
using LabFusion.Network;
using LabFusion.Representation;
using LabFusion.SDK.Modules;
using PowerTools.Tools;

namespace PowertoolsFusion.Messages {
    public class FreezeRigMessage : ModuleMessage {
        protected override void ReceivedMessageEvent(NetworkPlayer localPlayer, NetworkPlayer sender) {
            localPlayer.RigSkeleton.physicsPelvis.isKinematic = !localPlayer.RigSkeleton.physicsPelvis.isKinematic;
        }
    }
}
