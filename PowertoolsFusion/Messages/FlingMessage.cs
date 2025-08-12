using LabFusion.Entities;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PowertoolsFusion.Messages {
    public class FlingMessage : ModuleMessage {
        protected override void ReceivedMessageEvent(NetworkPlayer localPlayer, NetworkPlayer sender) {
            Vector3.Scale(new Vector3(1, 1, 1), new Vector3(1, 1, 1));
            var vec = GenerateRandomVector3(-6000, 6000);
            vec.y = Random.Range(2000, 6000);
            localPlayer.RigSkeleton.physicsPelvis.AddForce(vec, ForceMode.Impulse);
        }
        public static Vector3 GenerateRandomVector3(int minRange = 1, int maxRange = 30) {
            return new Vector3(Random.Range(minRange, maxRange), Random.Range(minRange, maxRange), Random.Range(minRange, maxRange));
        }
    }
}
