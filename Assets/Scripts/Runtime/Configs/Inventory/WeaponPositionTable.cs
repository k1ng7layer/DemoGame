using Assets.Scripts.Runtime.Configs.InventoryConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Runtime.Configs.Inventory
{
    public class WeaponPositionTable
    {

        private Dictionary<WeaponType, WeaponTransformData> _weaponPositions;
        public WeaponPositionTable()
        {
            _weaponPositions = new Dictionary<WeaponType, WeaponTransformData>();
        }
        public void AddTransformData(WeaponType weaponType, WeaponTransformData weaponTransformData)
        {
            _weaponPositions.Add(weaponType, weaponTransformData);
        }
        public WeaponTransformData GetTransformData(WeaponType weaponType)
        {
            if (_weaponPositions.TryGetValue(weaponType, out WeaponTransformData data))
            {
                return data;
            }
            return default;
        }
    }
}
