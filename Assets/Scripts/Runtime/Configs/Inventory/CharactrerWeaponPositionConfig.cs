using Assets.Scripts.Runtime.Configs.InventoryConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Configs.Inventory
{
    [CreateAssetMenu(fileName = "new_weapon_config", menuName = "Configs/Weapon Positions Config")]
    public class CharactrerWeaponPositionConfig:ScriptableObject
    {
        [SerializeField] private List<WeaponPositionTableDTO> _weaponTransformData = new List<WeaponPositionTableDTO>();
        public List<WeaponPositionTableDTO> WeaponTransformData => _weaponTransformData;

    }
}
