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
            rootController = FindObjectOfType<RootController>();
       
            if (rootController != null)
            {
                rootController.SetUpController(config);
                rootController.StartRootController();
            }

        }
    }
}
                

