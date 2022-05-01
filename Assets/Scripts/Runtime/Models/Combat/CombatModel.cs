using Assets.Scripts.Runtime.Controllers.Combat;
using Assets.Scripts.Runtime.Views.UIViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Models.Combat
{
    public abstract class CombatModel
    {
        protected WeaponCombatModel _weaponCombatModel;
        protected WeaponView _currentWeaponView;
        protected LayerMask _targetLayer;
        public CombatModel(WeaponCombatModel weaponCombatModel, LayerMask targetLayer)
        {
            _weaponCombatModel = weaponCombatModel;
            _weaponCombatModel.WeaponGameObject.GetComponent<WeaponView>();
            _targetLayer = targetLayer;
        }
        public abstract void PerformAttack(AttackType attackType);
        public abstract void PerformAttack(AttackType attackType, Transform target);
        public abstract void DrawWeapon();
        public abstract void HideWeapon();
        public abstract void OnInterruptAttack();
        public abstract void PerformAttack(Transform target);
    }
}
