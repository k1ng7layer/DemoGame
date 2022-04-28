using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.GameActions.EventArgs
{
    public class OnWeaponEquipEventArgs
    {
        public OnWeaponEquipEventArgs(GameObject weaponGameObject, float weaponDamagePoints, WeaponType weaponType)
        {
            WeaponGameObject = weaponGameObject;
            WeaponDamagePoints = weaponDamagePoints;
            WeaponType = weaponType;
        }

        public GameObject WeaponGameObject { get; private set; }
        public float WeaponDamagePoints { get; private set; }
        public WeaponType WeaponType { get; private set; }
      
    }
}
