using Assets.Scripts.Runtime.Inventory;
using Assets.Scripts.Runtime.Views.UIViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.GameActions
{
    public class DisplayLootItemsEventArgs
    {
        public LootRepository SourceInventory { get; private set; }
        
        public MouseFollower MouseFollower { get; private set; }
        public List<InventoryItem> InventoryItems { get; private set; }
        public DisplayLootItemsEventArgs(LootRepository loot, MouseFollower mouseFollower)
        {
            SourceInventory = loot;
           
            MouseFollower = mouseFollower;
        }
        public DisplayLootItemsEventArgs(List<InventoryItem> inventoryItems, MouseFollower mouseFollower)
        {
            InventoryItems = inventoryItems;
            MouseFollower = mouseFollower;
        }
    }
}
