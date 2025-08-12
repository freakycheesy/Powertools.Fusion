using BoneLib.BoneMenu;
using LabFusion.SDK.Gamemodes;
using Powertools.Fusion.Tools;
using PowerTools.Tools;
using PowertoolsFusion.Messages;
using UnityEngine;

namespace PowertoolsFusion.Tools.Menus {
    public class AdminMenu {
        public static int RigID = 0;
        public AdminMenu(Page Page) {
            var page = Page.CreatePage("Admin Panel", Color.green);
            page.CreateInt("Rig ID", Color.green, 0, 1, 0, 40, (a) => RigID = a);
            GamemodeManager.OnGamemodeStarted += GamemodeManager_OnGamemodeStarted;
            GamemodeManager.OnGamemodeStopped += GamemodeManager_OnGamemodeStopped;

            page.CreateFunction("Fling", Color.green, FlingPlayer);
            page.CreateFunction("Freeze Physics Rig", Color.green, FreezeRig);
            page.CreateFunction("Launch", Color.green, FlyUp);
            page.CreateFunction("Disable Godmode", Color.green, DisableGodmode);
            page.CreateFunction("Kill Rig", Color.green, Kill);
        }
        public static bool GodModeSaved;
        private void GamemodeManager_OnGamemodeStarted() {
            GodModeSaved = HealthSettings.GodMode.Value;
            while (GamemodeManager.IsGamemodeStarted)
                HealthSettings.GodMode.Value = false;
        }
        private void GamemodeManager_OnGamemodeStopped() {
            HealthSettings.GodMode.Value = GodModeSaved;
        }
        private void DisableGodmode() {
            FusionTool.SendMessage<DisableGodmode>((byte)RigID);
        }
        private void Kill() {
            FusionTool.SendMessage<KillMessage>((byte)RigID);
        }

        private void FreezeRig() {
            FusionTool.SendMessage<FreezeRigMessage>((byte)RigID);
        }
        private void FlyUp() {
            FusionTool.SendMessage<FlyUpMessage>((byte)RigID);
        }

        private void FlingPlayer() {
            FusionTool.SendMessage<FlingMessage>((byte)RigID);
        }

    }
}
