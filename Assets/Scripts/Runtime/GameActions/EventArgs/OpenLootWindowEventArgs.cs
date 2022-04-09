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
        public List<InventoryItem> Loot { get; private set; }
        public OpenLootWindowEventArgs(List<InventoryItem> inventory)
        {
            Loot = inventory;
        }
    }
    
}
