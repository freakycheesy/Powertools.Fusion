using LabFusion.Entities;
using LabFusion.Representation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PowertoolsFusion.Messages {
    public class FlyUpMessage : ModuleMessage {
        public override PermissionLevel MinimumPermissionLevel {
            get;
            protected set;
        } = PermissionLevel.OPERATOR;
        protected override void ReceivedMessageEvent(NetworkPlayer localPlayer, NetworkPlayer sender, string message) {
            for (int i = 0; i < 50; i++) {
                localPlayer.RigSkeleton.physicsPelvis.AddForce(Vector3.up * 2);
            }
        }
    }
}
