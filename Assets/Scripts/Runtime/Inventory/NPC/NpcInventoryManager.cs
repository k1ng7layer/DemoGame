using Assets.Scripts.Runtime.Configs;
using Assets.Scripts.Runtime.Configs.Inventory;
using Assets.Scripts.Runtime.Controllers;
using Assets.Scripts.Runtime.Controllers.Combat;
using Assets.Scripts.Runtime.GameActions;
using Assets.Scripts.Runtime.Views.UIViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Inventory
{
    public class NpcInventoryManager:InventoryManagerBase
    {
        private WeaponDTO _equipedWeapon;
        private GameObject _defaultWeaponParentObject;
        private GameObject _armedWeaponParentObject;
        private Dictionary<ItemDTO, GameObject> _instantiatedEquipedItems;
        private WeaponTransformState _currentWeaponTransformState;
       
        public override event Action<bool> OnWeaponDrawRequest;
        public override event Action<bool> OnWeaponStateChanged;
        public override event Action<WeaponCombatModel> OnWeaponViewAssign;

     
        public NpcInventoryManager(WeaponDTO weaponDTO, GameObject npcObject, InventoryDTO inventoryDTO):base(inventoryDTO)
        {
            _instantiatedEquipedItems = new Dictionary<ItemDTO, GameObject>();
            _defaultWeaponParentObject = npcObject.GetComponentInChildren<DefaultWeaponParent>().gameObject;
            _armedWeaponParentObject = npcObject.GetComponentInChildren<ArmedWeaponParent>().gameObject;
            _equipedWeapon = weaponDTO;
            

        }
        public override void InitializeController()
        {
            var weaponGameObject = CreateWeaponInstance(_equipedWeapon);
            _instantiatedEquipedItems.Add(_equipedWeapon, weaponGameObject);
            var weaponView = weaponGameObject.GetComponent<WeaponView>();
            OnWeaponViewAssign?.Invoke(new WeaponCombatModel(weaponGameObject, _equipedWeapon.Damagr, _equipedWeapon.WeaponType, 2f, _equipedWeapon.WeaponAttackType));
        }
        public void Initialize()
        {
            var weaponGameObject = CreateWeaponInstance(_equipedWeapon);
            _instantiatedEquipedItems.Add(_equipedWeapon, weaponGameObject);
            var weaponView = weaponGameObject.GetComponent<WeaponView>();
            OnWeaponViewAssign?.Invoke(new WeaponCombatModel(weaponGameObject, _equipedWeapon.Damagr, _equipedWeapon.WeaponType, 2f, _equipedWeapon.WeaponAttackType));
        }

        private GameObject CreateWeaponInstance(WeaponDTO item)
        {

            var weaponTransformData = WeaponPositionsHandler.GetWeaponData(CharacterType.NORMAL_HUMAN, item.WeaponType);
            var weapon = GameObjectFactory.Instantiate<GameObject>(item.Prefab, _defaultWeaponParentObject.transform);
            weapon.transform.localPosition = weaponTransformData.DefaultPosition;
            weapon.transform.localRotation = Quaternion.Euler(weaponTransformData.DefaultRotation);
            weapon.transform.localScale = weaponTransformData.DefaultScale;
            return weapon;
        }
        private void ChangeWeaponTransformState(WeaponDTO weapon, WeaponTransformState transformState)
        {
            if (_instantiatedEquipedItems.TryGetValue(_equipedWeapon, out GameObject weaponObj)) 
            {
                var weaponTransformData = WeaponPositionsHandler.GetWeaponData(CharacterType.NORMAL_HUMAN, _equipedWeapon.WeaponType);
                switch (transformState)
                {
                    case WeaponTransformState.DEFAULT:
                        weaponObj.transform.SetParent(_defaultWeaponParentObject.transform);
                        weaponObj.transform.localPosition = weaponTransformData.DefaultPosition;
                        weaponObj.transform.localRotation = Quaternion.Euler(weaponTransformData.DefaultRotation);
                        weaponObj.transform.localScale = weaponTransformData.DefaultScale;
                        break;
                    case WeaponTransformState.ARMED:
                        weaponObj.transform.SetParent(_armedWeaponParentObject.transform);
                        weaponObj.transform.localPosition = weaponTransformData.ArmedPosition;
                        weaponObj.transform.localRotation = Quaternion.Euler(weaponTransformData.ArmedRotation);
                        weaponObj.transform.localScale = weaponTransformData.ArmedScale;
                        break;
                    default:
                        break;
                }
                _currentWeaponTransformState = transformState;
            }
        }
        public override void HideCurrentWeapon()
        {
            if (_equipedWeapon != null)
                ChangeWeaponTransformState(_equipedWeapon, WeaponTransformState.DEFAULT);
            //OnWeaponStateChanged?.Invoke(false);
        }
        public override void DrawCurrentWeapon()
        {
            if (_equipedWeapon != null)
            {
                ChangeWeaponTransformState(_equipedWeapon, WeaponTransformState.ARMED);
            }
        }

        protected override bool TryAddItem(ItemDTO item, int quantity)
        {
            throw new NotImplementedException();
        }

        protected override bool TryGetInventoryItem(int id, out InventoryItem inventoryItem)
        {
            throw new NotImplementedException();
        }

        protected override void RemoveItem(int id)
        {
            throw new NotImplementedException();
        }

        protected override void SwapInventoryItems(OnItemSwapEventArgs eventArgs)
        {
            throw new NotImplementedException();
        }

        protected override void EquipItem(ItemEquipRequestEventArgs eventArgs)
        {
            throw new NotImplementedException();
        }

        public override void OpenInventory()
        {
            throw new NotImplementedException();
        }

       

      

        public override void WeaponDrawRequest()
        {
            
        }

        public override void WeaponHideRequest()
        {
            
        }
    }
}
