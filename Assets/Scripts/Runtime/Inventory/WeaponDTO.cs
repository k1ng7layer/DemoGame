using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Runtime.Inventory
{
    [CreateAssetMenu(fileName = "new_Item", menuName = "Inventory/WeaponDTO")]
    public class WeaponDTO:ItemDTO
    {
        
        [SerializeField] private float _damage;
        
        public float Damagr => _damage;
        
        
        
    }
}
