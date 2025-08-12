using LabFusion.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PowertoolsFusion.Messages {
    public class FlyUpMessage : ModuleMessage {
        protected override void ReceivedMessageEvent(NetworkPlayer localPlayer, NetworkPlayer sender) {
            for (int i = 0; i < 50; i++) {
                localPlayer.RigSkeleton.physicsPelvis.position += Vector3.up * 2;
            }
        }
    }
}
