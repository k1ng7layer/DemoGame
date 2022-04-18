using Assets.Scripts.Runtime.Configs;
using Assets.Scripts.Runtime.Configs.Inventory;
using Assets.Scripts.Runtime.Controllers;
using Assets.Scripts.Runtime.GameActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UISystem.Common;
using UnityEngine;

namespace Assets.Scripts.Runtime.Inventory
{
    public enum WeaponTransformState
    {
        DEFAULT,
        ARMED,
    }
    public sealed class InventoryManager : InventoryManagerBase
    {
        //Temp
        private GameObject _defaultWeaponParentObject;
        private GameObject _armedWeaponParentObject;


        private List<InventoryItem> _inventoryItems;
        private Dictionary<ItemDTO, GameObject> _instantiatedEquipedItems;
        //private ItemDTO _equipedWeapon;
        private WeaponDTO _equipedWeapon;
        private ItemDTO _equipedHelmet;
        private ItemDTO _equipedBoots;
        private ItemDTO _equipedChest;
        private ItemDTO _equipedGloves;
        private int _inventoryCapacity;

        public override event Action OnWeaponDraw;
        public override event Action<WeaponDTO> OnWeaponChanged;

        public InventoryManager(InventoryDTO inventoryData) :base(inventoryData)
        {
            _instantiatedEquipedItems = new Dictionary<ItemDTO, GameObject>();
            _inventoryItems = new List<InventoryItem>(inventoryData.Capacity);
            _inventoryCapacity = inventoryData.Capacity;
            var stackableItems = inventoryData.GetInventoryItems().Where(i => i.Item.IsStackable == true).ToList();
            foreach (var item in stackableItems)
            {
                TryAddItem(item.Item, item.Quantity);
            }
            var notStackableItems = inventoryData.GetInventoryItems().Where(i => i.Item.IsStackable == false).ToList();
            foreach (var item in notStackableItems)
            {
                for (int i = 0; i < item.Quantity; i++)
                {
                    TryAddItem(item.Item, 1);
                }
            }
        }

        public override void InitializeController()
        {
            _defaultWeaponParentObject = playerObj.GetComponentInChildren<DefaultWeaponParent>().gameObject;
            _armedWeaponParentObject = playerObj.GetComponentInChildren<ArmedWeaponParent>().gameObject;
            UIActionContainer.ResolveAction<SwapInventoryItemsAction>().AddListener(SwapInventoryItems);
            UIActionContainer.ResolveAction<ItemEquipRequestAction>().AddListener(EquipItem);
            UIActionContainer.ResolveAction<ItemDescriptonRequestAction>().AddListener(DisplayItemDescription);
            UIActionContainer.ResolveAction<HideEquipedItemAction>().AddListener(HandleItemHideAction);
        }
            
        public override void OnDestroyController()
        {
            UIActionContainer.ResolveAction<SwapInventoryItemsAction>().RemoveListener(SwapInventoryItems);
            UIActionContainer.ResolveAction<ItemEquipRequestAction>().RemoveListener(EquipItem);
            UIActionContainer.ResolveAction<ItemDescriptonRequestAction>().RemoveListener(DisplayItemDescription);
            UIActionContainer.ResolveAction<HideEquipedItemAction>().RemoveListener(HandleItemHideAction);
        }
        public override void OpenInventory()
        {

            OpenLootWindowEventArgs eventArgs = new OpenLootWindowEventArgs(_inventoryItems);
            ActionContainer.ResolveAction<OpenPlayerInventoryAction>().Dispatch(eventArgs);
        }
        protected override void RemoveItem(int id)
        {
            _inventoryItems[id] = InventoryItem.SetEmptyItem();
        }
        protected override bool TryAddItem(ItemDTO item, int quantity)
        {
            if (_inventoryItems.Count < _inventoryCapacity&&item!=null&&quantity!=0)
            {
                _inventoryItems.Add(new InventoryItem(item, quantity));
                return true;
            }
            else
            {
                return false;
            }
            
        }
        protected override bool TryGetInventoryItem(int id, out InventoryItem inventoryItem)
        {
            var item = _inventoryItems[id];
            if (!item.IsEmpty)
            {
                inventoryItem = item;
                return true;
            }
            else
            {
                inventoryItem = default;
                return false;
            }
        }
        protected override void SwapInventoryItems(OnItemSwapEventArgs eventArgs)
        {
            //Debug.Log($"TRY TO SWAP = A = {eventArgs.ItemA_Index}, B ={eventArgs.ItemB_Index} ");
            var temp = _inventoryItems[eventArgs.ItemA_Index];
            var itemB = _inventoryItems[eventArgs.ItemB_Index];
            _inventoryItems[eventArgs.ItemA_Index] = itemB;
            _inventoryItems[eventArgs.ItemB_Index] = temp;
        }
        protected override void EquipItem(ItemEquipRequestEventArgs eventArgs)
        {
            var item = _inventoryItems.Where(i => i.Item.Id == eventArgs.ItemId).FirstOrDefault();
            if (eventArgs.TargetSlot == item.Item.Slot)
            {
                switch (item.Item.Slot)
                {
                    case Views.UIViews.SlotType.WEAPON:
                        if (_equipedWeapon != null)
                        {
                            if (_instantiatedEquipedItems.TryGetValue(_equipedWeapon, out GameObject gameObject))
                            {
                                GameObject.Destroy(gameObject);
                            }
                        }
                      
                        _equipedWeapon = (WeaponDTO)item.Item;
                        var weaponGameObject = CreateWeaponInstance(_equipedWeapon);
                        OnWeaponChanged?.Invoke(_equipedWeapon);
                        
                        _instantiatedEquipedItems.Remove(_equipedWeapon);
                        _instantiatedEquipedItems.Add(_equipedWeapon, weaponGameObject);
                        break;
                    case Views.UIViews.SlotType.HELMET:
                        _equipedHelmet = item.Item;
                        break;
                    case Views.UIViews.SlotType.CHEST:
                        _equipedChest = item.Item;
                        break;
                    case Views.UIViews.SlotType.BOOTS:
                        _equipedBoots = item.Item;
                        break;
                    case Views.UIViews.SlotType.GLOVES:
                        _equipedGloves = item.Item;
                        break;
                    default:
                        break;
                }
                
                ItemEquipEventArgs equipEventArgs = new ItemEquipEventArgs(item.Item.Id, item.Item.Slot);
                UIActionContainer.ResolveAction<ItemEquipAction>().Dispatch(equipEventArgs);
            }
        }
        private GameObject CreateWeaponInstance(ItemDTO item)
        {
          
            var weaponTransformData = WeaponPositionsHandler.GetWeaponData(CharacterType.CHIBI, WeaponType.SWORD);
            var weapon = GameObjectFactory.Instantiate<GameObject>(item.Prefab, _defaultWeaponParentObject.transform);
            weapon.transform.localPosition = weaponTransformData.DefaultPosition;
            weapon.transform.localRotation = Quaternion.Euler(weaponTransformData.DefaultRotation);
            weapon.transform.localScale = weaponTransformData.DefaultScale;
            return weapon;
        }
        private void HandleItemHideAction(ItemInfoRequestEventArgs eventArgs)
        {
            var item = _inventoryItems.Where(i => i.Item.Id == eventArgs.ItemId).FirstOrDefault();
            if(_instantiatedEquipedItems.TryGetValue(item.Item, out GameObject obj))
            {
                GameObject.Destroy(obj);
                _instantiatedEquipedItems.Remove(item.Item);
                _equipedWeapon = null;
            }
        }
        private void DestroyCurrentWeaponObject()
        {

        }
        public override void DrawCurrentWeapon()
        {
            if (_equipedWeapon != null)
                ChangeWeaponTransformState(_equipedWeapon, WeaponTransformState.ARMED);
        }
        public override void HideCurrentWeapon()
        {
            if (_equipedWeapon != null)
                ChangeWeaponTransformState(_equipedWeapon, WeaponTransformState.DEFAULT);
        }
        private void ChangeWeaponTransformState(WeaponDTO weapon, WeaponTransformState transformState)
        {
            if (_instantiatedEquipedItems.TryGetValue(_equipedWeapon, out GameObject weaponObj))
            {
                var weaponTransformData = WeaponPositionsHandler.GetWeaponData(CharacterType.CHIBI, _equipedWeapon.WeaponType);
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
            }
        }
        private void HandleSwapEquipedItems(ItemDTO item)
        {
            
            if (_instantiatedEquipedItems.TryGetValue(item, out GameObject obj))
            {
                GameObject.Destroy(obj);
                _instantiatedEquipedItems.Remove(item);
            }
        }
        private void DisplayItemDescription(ItemDescriptionRequestEventArgs eventArgs)
        {
            var item = _inventoryItems.Where(i => i.Item.Id == eventArgs.Item_id).FirstOrDefault();
            DisplayItemDescriptionEventArgs displayItem = new DisplayItemDescriptionEventArgs(item.Item.Id, item.Item.Name, item.Item.Description);
            UIActionContainer.ResolveAction<DisplayItemDescriptionAction>().Dispatch(displayItem);
        }
        public override void WeaponDrawRequest()
        {
            if (_equipedWeapon != null)
                OnWeaponDraw?.Invoke();
        }
    }
}


        
     
   
                       
          
          

       
          
            
      



       
