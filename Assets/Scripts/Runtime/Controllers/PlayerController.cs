using Assets.Scripts.Runtime.Configs;
using Assets.Scripts.Runtime.Inventory;
using Assets.Scripts.Runtime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Controllers
{
    public abstract class PlayerController : IController
    {
        protected MovementModel _movementModel;
        protected InputTypeBase _input;
        protected InventoryManagerBase _inventoryManager;
        public event Action OnPlayerDeath;
        public PlayerController(PlayerConfig playerConfig)
        {
            //_movementModel = playerConfig.BuildMovementModel();
        }

        public abstract void MovePlayer(Vector3 direction);
        
        protected void SetPlayerDeath()
        {
            OnPlayerDeath?.Invoke();
        }
        public virtual void InitializeController()
        {
            
        }

        public virtual void OnDestroyController()
        {
            
        }

        public void OnDisableController()
        {
            
        }

        public virtual void OnFixedUpdateController()
        {
            
        }

        public void OnLateUpdateController()
        {
            
        }

        public virtual void OnUpdateController()
        {
            
        }
    }
}
