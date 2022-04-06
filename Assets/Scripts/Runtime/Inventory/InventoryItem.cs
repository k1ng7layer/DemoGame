using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Inventory
{
    [Serializable]
    public struct InventoryItem
    {
        [SerializeField] private ItemDTO _item;
        [SerializeField] private int _quantity;
        private bool _isEmpty;
        public ItemDTO Item => _item;
        public int Quantity => _quantity;
        public bool IsEmpty => _isEmpty;
        

        public InventoryItem(ItemDTO item, int quantity)
        {
            if (item != null && quantity != 0)
                _isEmpty = false;
            else _isEmpty = true;
            _item = item;
            _quantity = quantity;
        }

        public static InventoryItem SetEmptyItem()
        {
            return new InventoryItem()
            {
                _item = null,
                _quantity = 0,
            };
        }
          
       
        
    }
}
