using Assets.Scripts.Runtime.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Configs.LevelConfigs
{
    public class SceneStarter:MonoBehaviour
    {
        private RootController rootController;

        public void InitializeScene(ControllersConfig config)
        {
            var findedController = FindObjectOfType<RootController>();
            if (findedController != null)
            {
                Destroy(findedController.gameObject);
                rootController = null;
            }
              
            if (rootController == null)
            {
                GameObject obj = new GameObject("RootController");
                rootController = obj.AddComponent<RootController>();
                rootController.SetUpController(config);
                rootController.StartRootController();
            }
                
        }
    }
}

