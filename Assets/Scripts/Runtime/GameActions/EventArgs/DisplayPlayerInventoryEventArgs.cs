using Assets.Scripts.Runtime.Inventory;
using Assets.Scripts.Runtime.Views.UIViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Runtime.GameActions.EventArgs
{
    public class DisplayPlayerInventoryEventArgs
    {
        public List<InventoryItem> InventoryItems { get; private set; }
        public MouseFollower MouseFollower { get; set; }
        public DisplayPlayerInventoryEventArgs(List<InventoryItem> inventoryItems, MouseFollower mouseFollower)
        {
            InventoryItems = inventoryItems;
            MouseFollower = mouseFollower;
        }
    }
}
