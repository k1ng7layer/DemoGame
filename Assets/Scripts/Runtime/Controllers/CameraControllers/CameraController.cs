using Assets.Scripts.Runtime.Models;
using Assets.Scripts.Runtime.Views;
using Assets.Scripts.Runtime.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Controllers
{
    public abstract class CameraController : IController
    {
        protected CameraModel cameraModel;
        protected CameraView cameraView;
        public Camera CameraObject
        {
            get
            {
                return cameraView.transform.GetOrCreateComponent<Camera>();
            }
        }
        public GameObject CurrentTarget { get; set; }
        //protected CameraView CameraObject { get; set; }

        public CameraController(CameraView cameraView)
        {
            
        }
        public void FollowTarget()
        {
            cameraModel.FollowTarget(CurrentTarget);
        }
        public void SetTarget(GameObject target)
        {
            CurrentTarget = target;
        }

        public virtual void InitializeController()
        {

        }

        public virtual void OnUpdateController()
        {

        }

        public virtual void OnFixedUpdateController()
        {

        }

        public virtual void OnDestroyController()
        {

        }

        public virtual void OnDisableController()
        {

        }

        public virtual void OnLateUpdateController()
        {

        }
    }
}
