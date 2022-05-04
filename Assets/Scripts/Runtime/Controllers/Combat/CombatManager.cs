using Assets.Scripts.Runtime.Extensions;
using Assets.Scripts.Runtime.GameActions.EventArgs;
using Assets.Scripts.Runtime.Inventory;
using Assets.Scripts.Runtime.Models.Combat;
using Assets.Scripts.Runtime.Views.UIViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

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
        protected CombatModel _combatModel;
        protected InventoryManagerBase _inventoryManager;
        protected Transform _playerTransform;
        protected LayerMask _targetLayers;
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
        public CombatManager(InventoryManagerBase inventoryManager, Transform playerTransform)
        {
            _inventoryManager = inventoryManager;
            _playerTransform = playerTransform;
        }
        public void SetWeapon(WeaponCombatModel weaponCombatModel)
        {
            currentCombatWeapon = weaponCombatModel;
            currentWeaponView = weaponCombatModel.WeaponGameObject.transform.GetOrCreateComponent<WeaponView>();
            switch (weaponCombatModel.WeaponAttackType)
            {
                case WeaponAttackType.RANGE:
                    _combatModel = new RangedCombatModel(_inventoryManager, _playerTransform, weaponCombatModel,_targetLayers);
                    break;
                case WeaponAttackType.MELEE:
                    //Debug.Log($"_combatModel = {weaponCombatModel}, _targetLayers = {_targetLayers},_inventoryManager = {_inventoryManager} ");
                    _combatModel = new MeleeCombaModel(weaponCombatModel, _targetLayers, _inventoryManager);
                    break;
                default:
                    break;
            }

        }
        public abstract void DrawWeapon();
        public abstract void SetTarget(Transform target);
        public abstract void RestoreHealth(float value, float time);
        
    }
}
       
          
            
