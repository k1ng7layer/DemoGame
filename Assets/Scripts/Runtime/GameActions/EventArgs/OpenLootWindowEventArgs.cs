using Assets.Scripts.Runtime.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Runtime.GameActions
{
    public class OpenLootWindowEventArgs
    {
        public LootRepository Loot { get; private set; }
        public List<InventoryItem> LootItems { get; private set; }
        public OpenLootWindowEventArgs(LootRepository inventory, List<InventoryItem> lootItems )
        {
            Loot = inventory;
            LootItems = lootItems;
        }
    }
    
}
