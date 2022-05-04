using Assets.Scripts.Runtime.Controllers;
using Assets.Scripts.Runtime.Controllers.CameraControllers;
using System.Collections;
using System.Collections.Generic;
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
        private Vector3 _cameraObstacleCheckOffset = new Vector3(0f, 1f, 0f);
        private List<MeshRenderer> _obstacles = new List<MeshRenderer>();
        private Color _obstacleColor;
        private ObstacleAvoider _obstacleAvoider;
        private ObstacleAvoider ObstacleAvoider
        {
            get
            {
                if (_obstacleAvoider == null)
                {
                    _obstacleAvoider = new ObstacleAvoider(Camera, target.transform);
                }
                return _obstacleAvoider;
            }
        }
        protected GameObject target;
        protected GameObject Camera { get; set; }
        public CameraModel(GameObject cameraObj)
        {
            Camera = cameraObj;
            
        }

        public void MakeObstacleTransparent()
        {
            if(ObstacleAvoider != null)
                ObstacleAvoider.MakeObstacleTransparent(20);
        }
        public abstract void FollowTarget();
        public void FollowTarget(GameObject obj)
        {
            target = obj;
            FollowTarget();
        }
        public void SetTarget(GameObject obj)
        {
            target = obj;
            
        }
        
    }
}
