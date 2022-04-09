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
        private UIController _uiController;
        
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private UIConfig _uIConfig;
        private List<IController> _controllers;
        public override List<IController> GetControllers()
        {
            _cameraView = FindObjectOfType<CameraView>();
            _cameraController = new ThirdPersonCamera(_cameraView);
            var player = _playerConfig.SpawnPlayerViewObject();
            _cameraController.SetTarget(player.gameObject);
            playerHandler = new PlayerHandler(_playerConfig);
            _uiController = new UIController(_uIConfig);
            _controllers = new List<IController>();

            //Добавление контроллеров
            _controllers.Add(playerHandler);
            _controllers.Add(_cameraController);
            _controllers.Add(_uiController);
            
            return _controllers;
        }
    }
}
