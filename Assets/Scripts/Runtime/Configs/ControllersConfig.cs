using Assets.Scripts.Runtime.Controllers;
using Assets.Scripts.Runtime.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Configs
{
    [CreateAssetMenu(fileName = "new controllers config", menuName = "Configs/ControllersConfig")]
    public class ControllersConfig : ControllersConfigBase
    {
        private CameraView _cameraView;
        private PlayerHandler playerHandler;
        
        [SerializeField] private PlayerConfig playerСonfig;
        private List<IController> _controllers;
        public override List<IController> GetControllers()
        {
            _cameraView = FindObjectOfType<CameraView>();
            _cameraController = new ThirdPersonCamera(_cameraView);
            var player = playerСonfig.SpawnPlayerViewObject();
            _cameraController.SetTarget(player.gameObject);
            playerHandler = new PlayerHandler(playerСonfig);
            _controllers = new List<IController>();
            _controllers.Add(playerHandler);
            _controllers.Add(_cameraController);
            
            return _controllers;
        }
    }
}
