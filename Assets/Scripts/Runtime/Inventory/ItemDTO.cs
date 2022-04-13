using Assets.Scripts.Runtime.Views.UIViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Runtime.Inventory
{
    [CreateAssetMenu(fileName = "new_Item", menuName = "Inventory/ItemDTO")]
    public class ItemDTO:ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField][TextArea(0,10)] private string _description;
        [SerializeField] private Sprite _itemImage;
        [SerializeField] private bool _isStackable;
        [SerializeField] private SlotType _slotType;
        public string Name => _name;
        public string Description => _description;
        public Sprite ItemImage => _itemImage;
        public bool IsStackable => _isStackable;
        public SlotType Slot => _slotType;
       [SerializeField] public int Id => GetInstanceID();
    }
}
