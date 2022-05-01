using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Controllers.Combat
{
    public class WeaponCombatModel
    {
        public WeaponCombatModel(GameObject weaponGameObject, float weaponDamagePoints, WeaponType weaponType, float damageMultiplier, WeaponAttackType weaponAttackType)
        {
            WeaponGameObject = weaponGameObject;
            WeaponDamagePoints = weaponDamagePoints;
            WeaponType = weaponType;
            DamageMultiplier = damageMultiplier;
            WeaponAttackType = weaponAttackType;
        }

        public GameObject WeaponGameObject { get; private set; }
        public float WeaponDamagePoints { get; private set; }
        public WeaponType WeaponType { get; private set; }
        public float DamageMultiplier { get; private set; }
        public WeaponAttackType WeaponAttackType { get; private set; }
    }
}
