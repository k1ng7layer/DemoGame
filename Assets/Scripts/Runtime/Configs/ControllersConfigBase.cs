using Assets.Scripts.Runtime.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Configs
{
    public abstract class ControllersConfigBase : ScriptableObject
    {
        protected CameraController _cameraController;
        public abstract List<IController> GetControllers();
        public CameraController GetCameraController()
        {
            return _cameraController;
        }
    }
}
