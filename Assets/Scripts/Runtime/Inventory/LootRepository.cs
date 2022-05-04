using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Inventory
{
    public class LootRepository
    {
        public List<InventoryItem> Loot { get; private set; }

        public LootRepository(InventoryDTO inventoryDTO)
        {
            Loot = new List<InventoryItem>();
            foreach (var item in inventoryDTO.InventoryItems)
            {
                Loot.Add(item);
            }
        }
        public void RemoveItem(InventoryItem itemId)
        {
            var itemIndex = Loot.IndexOf(itemId);
            var quaqntity = Loot[itemIndex].Quantity;
            Loot[itemIndex] = Loot[itemIndex].ChangeQuantity(--quaqntity);
            if (quaqntity == 0)
            {
                Loot[itemIndex] = InventoryItem.SetEmptyItem();
                Loot.RemoveAt(itemIndex);
            }
                
            Debug.Log($"QUANTITY= {quaqntity}");

            
           // item.ChangeQuantity();

        }
    }
}
            
            
            
          

