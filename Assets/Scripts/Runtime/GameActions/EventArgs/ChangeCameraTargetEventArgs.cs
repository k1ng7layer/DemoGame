using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.GameActions
{
    public class ChangeCameraTargetEventArgs
    {
        public Transform Target { get; private set; }
        public Vector3 RotationAngles { get; private set; }
        public Vector3 Offset { get; private set; }
        public bool ReleaseAction { get; private set; }
        public ChangeCameraTargetEventArgs(Transform target, Vector3 rotAngles, Vector3 offset)
        {
            Target = target;
            RotationAngles = rotAngles;
            Offset = offset;
        }
        public ChangeCameraTargetEventArgs(Transform target,bool releaseCamera)
        {
            ReleaseAction = releaseCamera;
            Target = target;
        }
    }
}
