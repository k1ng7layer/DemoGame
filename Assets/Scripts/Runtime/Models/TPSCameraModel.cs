using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Models
{
    public class TPSCameraModel : CameraModel
    {
        public TPSCameraModel(GameObject cameraObj) : base(cameraObj)
        {

        }

        public override float FollowSpeed { get; set; }
        public override float Angle { get; set; }
        public override Vector3 Offset { get; set; }
        private Vector3 _velocity = Vector3.zero;



        public override void FollowTarget()
        {

            if (Camera != null && target != null)
            {
                Debug.Log($"speed = {FollowSpeed}, angle = {Angle}, offset = {Offset}");
                Quaternion rotation = Quaternion.Euler(new Vector3(xAngle, yAngle, zAngle));
                Camera.transform.rotation = rotation;
                //Camera.transform.position = Vector3.Lerp(Camera.transform.position, target.transform.position + Offset, FollowSpeed * Time.deltaTime);
                //Camera.transform.Translate(Vector3.Lerp(Camera.transform.position, target.transform.position + Offset, FollowSpeed * Time.deltaTime));
                Camera.transform.position = Vector3.SmoothDamp(Camera.transform.position,target.transform.position+Offset,ref _velocity, FollowSpeed*Time.deltaTime);
            }
        }

        public override void FollowTarget(GameObject obj)
        {
            target = obj;
            FollowTarget();
        }
    }
}