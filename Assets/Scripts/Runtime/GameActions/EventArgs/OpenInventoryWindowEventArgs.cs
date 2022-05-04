using Assets.Scripts.Runtime.Inventory;
using Assets.Scripts.Runtime.Views.UIViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Runtime.GameActions
{
    public class OpenInventoryWindowEventArgs
    {
        public List<InventoryItem> Loot { get; private set; }
        public OpenInventoryWindowEventArgs(List<InventoryItem> inventory)
        {
            Loot = inventory;
        }
    }
}
