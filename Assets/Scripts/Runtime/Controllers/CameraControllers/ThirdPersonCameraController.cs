using Assets.Scripts.Runtime.Controllers.CameraControllers;
using Assets.Scripts.Runtime.GameActions;
using Assets.Scripts.Runtime.Models;
using Assets.Scripts.Runtime.Views;
using UnityEngine;

namespace Assets.Scripts.Runtime.Controllers
{
    public class ThirdPersonCameraController : CameraController
    {
        private float _xAngle;
        private float _yAngle;
        private float _zAngle;
        private Vector3 _offset;
        private ObstacleAvoider _obstacleAvoider;
        public ThirdPersonCameraController(CameraView cameraView) : base( cameraView)
        {
            
            this.cameraView = cameraView;
        }

        public override void InitializeController()
        {
            cameraModel = new TPSCameraModel(cameraView.gameObject);
            ActionContainer.ResolveAction<ChangeCameraTargetAction>().AddListener(ChangeTarget);
            
            _xAngle = cameraView.X_Angle;
            _yAngle = cameraView.Y_Angle;
            _zAngle = cameraView.Z_Angle;
            _offset = cameraView.Offset;
        }

        public override void OnDestroyController()
        {
            ActionContainer.ResolveAction<ChangeCameraTargetAction>().RemoveListener(ChangeTarget);
        }

        private void ChangeTarget(ChangeCameraTargetEventArgs args)
        {
            if (args.ReleaseAction)
            {
                _xAngle = cameraView.X_Angle;
                _yAngle = cameraView.Y_Angle;
                _zAngle = cameraView.Z_Angle;
                _offset = cameraView.Offset;
            }
            else
            {
                _xAngle = args.RotationAngles.x;
                _yAngle = args.RotationAngles.y;
                _zAngle = args.RotationAngles.z;
                _offset = args.Offset;
            }
            CurrentTarget = args.Target.gameObject;
            cameraModel.SetTarget(args.Target.gameObject);
        }
        public override void OnFixedUpdateController()
        {
            //cameraModel.xAngle = cameraView.X_Angle;
            //cameraModel.yAngle = cameraView.Y_Angle;
            //cameraModel.zAngle = cameraView.Z_Angle;
            //cameraModel.FollowSpeed = cameraView.Speed;
            //cameraModel.Offset = cameraView.Offset;
            cameraModel.xAngle = _xAngle;
            cameraModel.yAngle = _yAngle;
            cameraModel.zAngle = _zAngle;
            cameraModel.FollowSpeed = cameraView.Speed;
            cameraModel.Offset = _offset;
            cameraModel.FollowTarget(CurrentTarget);
            cameraModel.MakeObstacleTransparent();
        }
        public override void OnLateUpdateController()
        {
            
        }
        public override void OnUpdateController()
        {
         
        }
    }

}

                
                

                


            

