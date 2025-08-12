using BoneLib;
using LabFusion.Entities;
using LabFusion.Network;
using LabFusion.Representation;
using LabFusion.SDK.Modules;
using PowerTools;
using PowerTools.Tools;

namespace PowertoolsFusion.Messages {
    public class DisableGodmode : ModuleMessage {
        public override PermissionLevel MinimumPermissionLevel {
            get;
            protected set;
        } = PermissionLevel.OPERATOR;

        protected override void ReceivedMessageEvent(NetworkPlayer localPlayer, NetworkPlayer sender, string message) {
            HealthSettings.GodMode.Value = false;
            Main.Save();
        }
    }
}
