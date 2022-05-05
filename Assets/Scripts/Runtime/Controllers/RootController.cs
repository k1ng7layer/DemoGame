using Assets.Scripts.Runtime.Configs;
using Assets.Scripts.Runtime.Configs.LevelConfigs;
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

    public class RootController : MonoBehaviour
    {
        public CameraController cameraController { get; private set; }
        private static RootController _instance;
        private bool _run;
        private bool _init;
        [SerializeField] private ControllersConfig _config;
        [SerializeField] float _timeScale = 1;
       
        private SceneStarter _sceneStarter;
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
        public void StartRootController()
        {
            if (!_init)
            {
                _gameControllers = _config.GetControllers();
                cameraController = _config.GetCameraController();
                foreach (var item in _gameControllers)
                {
                    ActionConfig.ConfigureActions();
                    item.InitializeController();
                }
                _init = true;
                _run = true;
            }
        }
        public void SetUpController(ControllersConfig config)
        {
            _config = config;

        }

        private IEnumerator WaitForSceneStarterLoaded()
        {
            while (_sceneStarter==null)
            {
                _sceneStarter = FindObjectOfType<SceneStarter>();
                yield return null;
            }
        }
        private void Awake()
        {
            if (_init)
            {
               
            }
        } 
        private void Update()
        {
            if (_run)
            {
                //Time.timeScale = _timeScale;
                foreach (var controller in _gameControllers)
                {
                    controller.OnUpdateController();
                }
            }
          
        }

        private void FixedUpdate()
        {
            if (_run)
            {
                foreach (var controller in _gameControllers)
                {
                    controller.OnFixedUpdateController();
                }
            }
           
        }

        private void LateUpdate()
        {
            if (_run)
            {
                foreach (var controller in _gameControllers)
                {
                    controller.OnLateUpdateController();
                }
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


       

      

           
          
          



    
