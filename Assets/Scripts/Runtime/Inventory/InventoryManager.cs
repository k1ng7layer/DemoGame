using Assets.Scripts.Runtime.GameActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UISystem.Common;

namespace Assets.Scripts.Runtime.Inventory
{
    public sealed class InventoryManager : InventoryManagerBase
    {
        private List<InventoryItem> _inventoryItems;
        private ItemDTO _equipedWeapon;
        private ItemDTO _equipedHelmet;
        private ItemDTO _equipedBoots;
        private ItemDTO _equipedChest;
        private ItemDTO _equipedGloves;

        private int _inventoryCapacity;
        
        public InventoryManager(InventoryDTO inventoryData):base(inventoryData)
        {
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
            UIActionContainer.ResolveAction<SwapInventoryItemsAction>().AddListener(SwapInventoryItems);
            UIActionContainer.ResolveAction<ItemEquipRequestAction>().AddListener(EquipItem);
        }
        public override void OnDestroyController()
        {
            UIActionContainer.ResolveAction<SwapInventoryItemsAction>().RemoveListener(SwapInventoryItems);
            UIActionContainer.ResolveAction<ItemEquipRequestAction>().RemoveListener(EquipItem);
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
                        _equipedWeapon = item.Item;
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

    }
}
          
            
      



       
