using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UISystem.Actions;
using UISystem.Common;
using UnityEngine;

namespace Assets.Scripts.Runtime.Controllers
{
    public class GameStateController : IController
    {
        private float _currentTimeScale;
        public GameStateController()
        {
                
        }
        private void SetTimeScale(float timeScale)
        {
            _currentTimeScale = timeScale;
            Time.timeScale = timeScale;
        }
        public void InitializeController()
        {
            //Debug.Log("SDSDSDSDD");
            UIActionContainer.ResolveAction<UIOpenAction>().AddListener(SetTimeScale);
        }

        public void OnDestroyController()
        {
            UIActionContainer.ResolveAction<UIOpenAction>().RemoveListener(SetTimeScale);
        }

        public void OnDisableController()
        {
            
        }

        public void OnFixedUpdateController()
        {
            
        }

        public void OnLateUpdateController()
        {
            
        }

        public void OnUpdateController()
        {
            
        }
    }
}
