using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Inventory
{
    [CreateAssetMenu(fileName ="new_Inventory", menuName ="Inventory/InventoryDTO")]
    public class InventoryDTO:ScriptableObject
    {
        [SerializeField]private List<InventoryItem> _inventoryItems = new List<InventoryItem>();
        public List<InventoryItem> InventoryItems => _inventoryItems;
        public List<InventoryItem> GetInventoryItems() => _inventoryItems;
        public int Capacity;
    }
}
