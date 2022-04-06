using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Inventory
{
    [CreateAssetMenu(fileName = "new_Item", menuName = "Inventory/ItemDTO")]
    public class ItemDTO:ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField][TextArea(0,10)] private string _description;
        public string Name => _name;
        public string Description => _description;
    }
}
