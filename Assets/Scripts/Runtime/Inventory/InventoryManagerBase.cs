using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Runtime.Inventory
{
    public abstract class InventoryManagerBase
    {
        public InventoryManagerBase(InventoryDTO inventoryDTO)
        {

        }
        protected abstract bool TryAddItem(ItemDTO item, int quantity);
        protected abstract bool TryGetInventoryItem(int id, out InventoryItem inventoryItem);
        protected abstract void RemoveItem(int id);
    }
}
