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
        public List<InventoryItem> _inventoryItems { get; private set; }
        public GameObject LootCellPrefab { get; private set; }
        public MouseFollower MouseFollower { get; private set; }
        public DisplayLootItemsEventArgs(List<InventoryItem> loot, GameObject cellPrefab, MouseFollower mouseFollower)
        {
            _inventoryItems = loot;
            LootCellPrefab = cellPrefab;
            MouseFollower = mouseFollower;
        }
    }
}
