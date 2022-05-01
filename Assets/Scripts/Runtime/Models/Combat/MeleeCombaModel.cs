using Assets.Scripts.Runtime.Controllers.Combat;
using Assets.Scripts.Runtime.Inventory;
using Assets.Scripts.Runtime.Views.UIViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Models.Combat
{
    public class MeleeCombaModel : CombatModel
    {
        private InventoryManagerBase _inventoryManager;
        public MeleeCombaModel(WeaponCombatModel weaponCombatModel, LayerMask targetMask, InventoryManagerBase inventoryManager) : base(weaponCombatModel, targetMask)
        {
            _inventoryManager = inventoryManager;
            _currentWeaponView = weaponCombatModel.WeaponGameObject.GetComponent<WeaponView>();
            _targetLayer = targetMask;
        }

        public override void DrawWeapon()
        {
            _inventoryManager.DrawCurrentWeapon();
        }

        public override void HideWeapon()
        {
            
        }

        public override void OnInterruptAttack()
        {
            throw new NotImplementedException();
        }

        public override void PerformAttack(AttackType attackType)
        {
         
        }

        public override void PerformAttack(Transform target)
        {
            throw new NotImplementedException();
        }

        public override void PerformAttack(AttackType attackType, Transform target)
        {
            Debug.Log("START DEALING DAMAGE");

            List<DamageUnit> damageUnits = new List<DamageUnit>();
            switch (attackType)
            {
                case AttackType.STAND:
                    damageUnits.Add(new DamageUnit(DamageType.PHYSCICAL, _weaponCombatModel.WeaponDamagePoints, 0f));
                    break;
                case AttackType.JUMP:
                    damageUnits.Add(new DamageUnit(DamageType.PHYSCICAL, _weaponCombatModel.WeaponDamagePoints, 0.8f));
                    break;
                default:
                    break;
            }
            //damageUnits.Add(new DamageUnit(DamageType.PHYSCICAL, currentCombatWeapon.WeaponDamagePoints, currentCombatWeapon.DamageMultiplier));
            _currentWeaponView.StartDealDamage(damageUnits, attackType, _targetLayer);
        }
    }
}
