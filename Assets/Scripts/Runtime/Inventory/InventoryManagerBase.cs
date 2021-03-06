using Assets.Scripts.Runtime.Controllers.Combat;
using Assets.Scripts.Runtime.GameActions;
using Assets.Scripts.Runtime.GameActions.EventArgs;
using Assets.Scripts.Runtime.Views.UIViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Inventory
{
    public abstract class InventoryManagerBase:IController
    {
        public abstract event Action<bool> OnWeaponDrawRequest;
        public abstract event Action<bool> OnWeaponStateChanged;
        public abstract event Action<WeaponCombatModel> OnWeaponViewAssign;
        protected GameObject playerObj;
        public InventoryManagerBase(InventoryDTO inventoryDTO)
        {

        }
        public void AttachPlayerObject(GameObject playerObj)
        {
            this.playerObj = playerObj;
        }
        protected abstract bool TryAddItem(ItemDTO item, int quantity);
        protected abstract bool TryGetInventoryItem(int id, out InventoryItem inventoryItem);
        protected abstract void RemoveItem(int id);
        protected abstract void SwapInventoryItems(OnItemSwapEventArgs eventArgs);
        protected abstract void EquipItem(ItemEquipRequestEventArgs eventArgs);
        public abstract void OpenInventory();
        public abstract void DrawCurrentWeapon();
        public abstract void HideCurrentWeapon();
        public abstract void WeaponDrawRequest();
        public abstract void WeaponHideRequest();
        public virtual void InitializeController()
        {
            
        }
        public void OnUpdateController()
        {
            
        }
        public void OnFixedUpdateController()
        {
            
        }
        public virtual void OnDestroyController()
        {
            
        }
        public void OnDisableController()
        {
            
        }
        public void OnLateUpdateController()
        {
            
        }
    }
}






        
