using BoneLib;
using LabFusion.Entities;
using LabFusion.Network;
using LabFusion.SDK.Gamemodes;
using PowerTools;
using PowerTools.Tools;
using PowertoolsFusion.Messages;
using PowertoolsFusion.Serializables;
using UnityEngine;

namespace Powertools.Fusion.Tools {
    public class FusionTool : BaseTool {
        public override string ToolName => "Fusion Tools";

        public override void BoneMenuCreator() {
            base.BoneMenuCreator();
            AdminMenu();
        }
        public static int RigID = 0;

        private void AdminMenu() {
            var adminMenu = Page.CreatePage("Admin Panel", Color.green);
            adminMenu.CreateInt("Rig ID", Color.green, 0, 1, 0, 40, (a) => RigID = a);
            GamemodeManager.OnGamemodeStarted += GamemodeManager_OnGamemodeStarted;
            GamemodeManager.OnGamemodeStopped += GamemodeManager_OnGamemodeStopped;

            adminMenu.CreateFunction("Fling", Color.green, FlingPlayer);
            adminMenu.CreateFunction("Freeze Physics Rig", Color.green, FreezeRig);
            adminMenu.CreateFunction("Launch", Color.green, FlyUp);
            adminMenu.CreateFunction("Kill Rig", Color.green, Kill);
        }

        private void GamemodeManager_OnGamemodeStopped() {
            HealthSettings.GodMode.Value = GodModeSaved;
        }

        public static bool GodModeSaved;
        private void GamemodeManager_OnGamemodeStarted() {
            GodModeSaved = HealthSettings.GodMode.Value;
            while(GamemodeManager.IsGamemodeStarted)HealthSettings.GodMode.Value = false;
        }

        public override void OnSetEnabled(bool value) {
            base.OnSetEnabled(value);
        }

        public override void Reset() {
            base.Reset();
        }


        private void Kill() {
            SendMessage<KillMessage>((byte)RigID);
        }

        private void FreezeRig() {
            SendMessage<FreezeRigMessage>((byte)RigID);
        }
        private void FlyUp() {
            SendMessage<FlyUpMessage>((byte)RigID);
        }

        private void FlingPlayer() {
            SendMessage<FlingMessage>((byte)RigID);
        }

        public static void SendMessage<T>(byte targetId, NetworkChannel network = NetworkChannel.Reliable) where T : PowertoolsFusion.Messages.ModuleMessage {
            if (!(NetworkPlayerManager.TryGetPlayer(Player.RigManager, out var sender) && NetworkPlayerManager.TryGetPlayer(targetId, out _)))
                return;
            var data = new SenderNetSerializable() { Sender = sender.PlayerID };
            MessageRelay.RelayModule<T, SenderNetSerializable>(data, new MessageRoute(targetId, network));
        }

        public static void SendMessage<T>(RelayType relayType, NetworkChannel network = NetworkChannel.Reliable) where T : PowertoolsFusion.Messages.ModuleMessage {
            if (!NetworkPlayerManager.TryGetPlayer(Player.RigManager, out var sender))
                return;
            var data = new SenderNetSerializable() {Sender = sender.PlayerID };
            MessageRelay.RelayModule<T, SenderNetSerializable>(data, new MessageRoute(relayType, network));
        }
    }
}
