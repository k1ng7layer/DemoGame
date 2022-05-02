using Assets.Scripts.Runtime.Models;
using Assets.Scripts.Runtime.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Controllers
{
    public class ThirdPersonCameraController : CameraController
    {

        public ThirdPersonCameraController(CameraView cameraView) : base( cameraView)
        {
            
            this.cameraView = cameraView;
        }

        public override void InitializeController()
        {
            cameraModel = new TPSCameraModel(cameraView.gameObject);
            //cameraModel.SetTarget(CurrentTarget);
        }


        public override void OnFixedUpdateController()
        {
            cameraModel.xAngle = cameraView.X_Angle;
            cameraModel.yAngle = cameraView.Y_Angle;
            cameraModel.zAngle = cameraView.Z_Angle;
            cameraModel.FollowSpeed = cameraView.Speed;
            cameraModel.Offset = cameraView.Offset;
            cameraModel.FollowTarget(CurrentTarget);
        }
        public override void OnLateUpdateController()
        {
            
            

        }
        public override void OnUpdateController()
        {
         
        }
    }

}
