using Assets.Scripts.Runtime.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Controllers.Interactions
{
    public class InteractionController : IController
    {
        private Transform _playerObj;
        public InteractionController(Transform playerObject)
        {
            _playerObj = playerObject;
        }
        public void InitializeController()
        {
            
        }

        public void OnDestroyController()
        {
            
        }
        public void UseItem()
        {
            LayerMask mask = LayerMask.GetMask("Interactable");
            var items = Physics.OverlapSphere(_playerObj.position, 1f, mask);
            if (items.Length > 0)
            {
                var item = items[0];
                if (item.TryGetComponent<IUsable>(out IUsable interactable))
                {
                    interactable.Use(_playerObj);
                }
            }
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
