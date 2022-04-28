using Assets.Scripts.Runtime.Extensions;
using Assets.Scripts.Runtime.GameActions.EventArgs;
using Assets.Scripts.Runtime.Views.UIViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Runtime.Controllers.Combat
{
    public enum DamageType
    {
        PHYSCICAL,
        MAGIC,
    }
    public abstract class CombatManager
    {
        public bool _canAttack = true;
        protected abstract bool hasWeaponEquiped { get; set; }
        protected WeaponCombatModel currentCombatWeapon;
        protected WeaponView currentWeaponView;
        public abstract event Action<int> OnAttack;
        public abstract event Action<bool> OnTakingDamage;
        public abstract event Action OnDeath;
        //Временно!!
        public abstract event Action<float> OnHealthChanged;
        public abstract void PerformAttackRequest();
        public abstract void HandleAttackBegin(AttackType attackType);
        public abstract void HandleAttackEnd();
        public abstract void HandleIncomeDamage(List<DamageUnit> damageUnits, bool value);
        public void SetWeaponReady(bool value)
        {
            hasWeaponEquiped = value;
        }
        public void SetWeapon(WeaponCombatModel weaponCombatModel)
        {
            currentCombatWeapon = weaponCombatModel;
            currentWeaponView = weaponCombatModel.WeaponGameObject.transform.GetOrCreateComponent<WeaponView>();
        }
    }
}
       
          
            
