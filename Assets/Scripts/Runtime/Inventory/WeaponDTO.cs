using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Inventory
{
    [CreateAssetMenu(fileName = "new_Item", menuName = "Inventory/WeaponDTO")]
    public class WeaponDTO:ItemDTO
    {
        [SerializeField] private GameObject _itemPrefab;
        [SerializeField] private float _damage;
        public float Damagr => _damage;
        public GameObject Prefab => _itemPrefab;
        
    }
}
