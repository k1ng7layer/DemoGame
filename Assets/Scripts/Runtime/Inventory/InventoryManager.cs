using Assets.Scripts.Runtime.GameActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UISystem.Common;

namespace Assets.Scripts.Runtime.Inventory
{
    public class InventoryManager : InventoryManagerBase
    {
        private List<InventoryItem> _inventoryItems;
        private int capacity;
        
        public InventoryManager(InventoryDTO inventoryData):base(inventoryData)
        {
            _inventoryItems = new List<InventoryItem>(inventoryData.Capacity);
            capacity = inventoryData.Capacity;
            foreach (var item in inventoryData.GetInventoryItems())
            {
                TryAddItem(item.Item, item.Quantity);
            }
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
            if (_inventoryItems.Count < capacity&&item!=null&&quantity!=0)
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

       
    }
}
