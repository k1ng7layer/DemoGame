using Assets.Scripts.Runtime.Configs;
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
    public enum AttackType
    {
        STAND,
        JUMP
    }
    public class PlayerCombatManager : CombatManager
    {
        private CombatModel _combatModel;
        private StatsModel _healthModel;
        protected override bool hasWeaponEquiped { get; set; }
        //private WeaponView _currentWeaponView;
        public override event Action<int> OnAttack;
        public override event Action<bool> OnTakingDamage;
        public override event Action<float> OnHealthChanged;
        public override event Action OnDeath;
        private float _damageMuiltiplier = 1;
        private LayerMask _targetLayer;
        //public bool _canAttack = true;

        private Animator _animator;

        private float _damagePoints;

        public PlayerCombatManager(Animator animator, PlayerConfig playerConfig)
        {
            _healthModel = new StatsModel(playerConfig.InitialHp);
            _combatModel = new MeleeCombaModel();
            _animator = animator;
            _targetLayer = playerConfig.TargetLayers;
        }

       
        private void ChangeConstraints()
        {

        }
        public override void PerformAttackRequest()
        {
            if (hasWeaponEquiped)
            {
                _combatModel.PerformAttack();
                //Debug.Log($"ATTACK IN JUMP");
                OnAttack?.Invoke(1);
                //_canAttack = false;
            }
           
        }

        public override void HandleIncomeDamage(List<DamageUnit> damageUnits, bool beginOrEnd)
        {
            if (beginOrEnd == true)
                HandleTakingDamageBegin(damageUnits);
            else HandleTakingDamageEnd();
        }

        public override void HandleAttackBegin(AttackType attackType)
        {
            Debug.Log("START DEALING DAMAGE");
          
            List<DamageUnit> damageUnits = new List<DamageUnit>();
            switch (attackType)
            {
                case AttackType.STAND:
                    damageUnits.Add(new DamageUnit(DamageType.PHYSCICAL, currentCombatWeapon.WeaponDamagePoints,0f));
                    break;
                case AttackType.JUMP:
                    damageUnits.Add(new DamageUnit(DamageType.PHYSCICAL, currentCombatWeapon.WeaponDamagePoints, 0.8f));
                    break;
                default:
                    break;
            }
            //damageUnits.Add(new DamageUnit(DamageType.PHYSCICAL, currentCombatWeapon.WeaponDamagePoints, currentCombatWeapon.DamageMultiplier));
            currentWeaponView.StartDealDamage(damageUnits, attackType, _targetLayer);
        }
        private void HandleTakingDamageBegin(List<DamageUnit> damageUnits)
        {
            float totalDamage = 0f;
            foreach (var unit in damageUnits)
            {
                if (unit.DamageType != DamageType.PHYSCICAL)
                    totalDamage += unit.DamagePoints;
                else totalDamage += unit.DamagePoints * (1 + unit.DamageMultiplier);


                _healthModel.DecreaseStatInstant(totalDamage);
                OnHealthChanged?.Invoke(_healthModel.Value);
                OnTakingDamage?.Invoke(true);
                if (_healthModel.Value <= 0)
                {
                    _animator.SetTrigger("Dying");
                    OnDeath?.Invoke();
                }
                else
                {
                    _animator.SetTrigger("TakeDamage");

                }
            }
        }
        private void HandleTakingDamageEnd()
        {
            OnTakingDamage?.Invoke(false);
        }
        public override void HandleAttackEnd()
        {
            
            Debug.Log("END DEALING DAMAGE");
            currentWeaponView.EndDealDamage();
            _canAttack = true;
        }
    }
}
       

