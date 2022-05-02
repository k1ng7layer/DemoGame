using Assets.Scripts.Runtime.Configs;
using Assets.Scripts.Runtime.GameActions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Controllers
{

    public class RootController:MonoBehaviour
    {
        public CameraController cameraController { get; private set; }
        private static RootController _instance;
        [SerializeField] float _timeScale = 1;
        public static RootController Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<RootController>();
                }
                return _instance;
            }
        }

        private List<IController> _gameControllers;
        

        
        private void Awake()
        {
            
            Time.timeScale = _timeScale;
            var rootAsset = Resources.Load<RootAsset>("Root/Root");
            
            _gameControllers = rootAsset.controllersConfig.GetControllers();
            cameraController = rootAsset.controllersConfig.GetCameraController();
        }



        private void Start()
        {
            ActionConfig.ConfigureActions();
            foreach (var controller in _gameControllers)
            {
                controller.InitializeController();
            }
        }

        private void Update()
        {
            //Time.timeScale = _timeScale;
            foreach (var controller in _gameControllers)
            {
                controller.OnUpdateController();
            }
        }

        private void FixedUpdate()
        {
            foreach (var controller in _gameControllers)
            {
                controller.OnFixedUpdateController();
            }
        }

        private void LateUpdate()
        {
            foreach (var controller in _gameControllers)
            {
                controller.OnLateUpdateController();
            }
        }

        private void OnDestroy()
        {
            foreach (var controller in _gameControllers)
            {
                controller.OnDestroyController();
            }
        }
        private void OnDisable()
        {
            foreach (var controller in _gameControllers)
            {
                controller.OnDisableController();
            }
        }
        public void RunCoroutine(IEnumerator enumerator)
        {
            StartCoroutine(enumerator);
        }

        public void StopMyCoroutine(IEnumerator enumerator)
        {
            StopCoroutine(enumerator);
        }


    }
}
