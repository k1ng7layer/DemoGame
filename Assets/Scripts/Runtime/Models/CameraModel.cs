using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Models
{
    public abstract class CameraModel
    {
        public abstract float FollowSpeed { get; set; }
        public abstract float Angle { get; set; }
        public float xAngle;
        public float yAngle;
        public float zAngle;
        public abstract Vector3 Offset { get; set; }
        protected GameObject target;
        protected GameObject Camera { get; set; }
        public CameraModel(GameObject cameraObj)
        {
            Camera = cameraObj;
        }


        public abstract void FollowTarget();
        public abstract void FollowTarget(GameObject obj);
        public void SetTarget(GameObject obj)
        {
            target = obj;
        }
    }
}
