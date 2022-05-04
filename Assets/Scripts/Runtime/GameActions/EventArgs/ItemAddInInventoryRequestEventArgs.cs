using Assets.Scripts.Runtime.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Runtime.GameActions
{
    public class ItemAddInInventoryRequestEventArgs
    {
        public InventoryItem RequestedItem { get; private set; }
        public LootRepository Holder { get; private set; }
        public ItemAddInInventoryRequestEventArgs(InventoryItem item, LootRepository holder)
        {
            RequestedItem = item;
            Holder = holder;
        }
    }
}
