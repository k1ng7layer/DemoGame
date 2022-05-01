using Assets.Scripts.Runtime.Configs.InventoryConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Runtime.Configs.Inventory
{
    public static class WeaponPositionsHandler
    {
        private static Dictionary<CharacterType, WeaponPositionTable> _characterWeaponPos = new Dictionary<CharacterType, WeaponPositionTable>();
        //public WeaponPositionsHandler(List<WeaponPositionTableDTO> positionTableDTOs)
        //{
           
           
        //}
        public static void Initialize(List<WeaponPositionTableDTO> positionTableDTOs)
        {
            foreach (var table in positionTableDTOs)
            {
                var transformTable = new WeaponPositionTable();
                var weaponTransformData = new WeaponTransformData(
                    table.DefaultPosition,
                    table.ArmedPosition,
                    table.DefaultRotation,
                    table.ArmedRotation,
                    table.DefaultScale,
                    table.ArmedScale);
                transformTable.AddTransformData(table.WeaponType, weaponTransformData);
                if(_characterWeaponPos.TryGetValue(table.CharacterModelType, out WeaponPositionTable positionTable))
                {
                    positionTable.AddTransformData(table.WeaponType, weaponTransformData);
                }
                else
                {
                    AddWeaponData(table.CharacterModelType, transformTable);
                }
               
            }
        }
        public static void AddWeaponData(CharacterType characterType, WeaponPositionTable weaponPositionTable)
        {
          
            _characterWeaponPos.Add(characterType, weaponPositionTable);
        }
        public static WeaponTransformData GetWeaponData(CharacterType characterType, WeaponType weaponType)
        {
            if (_characterWeaponPos.TryGetValue(characterType, out WeaponPositionTable table))
            {
                return table.GetTransformData(weaponType);
            }
            return default;
        }
    }
}
