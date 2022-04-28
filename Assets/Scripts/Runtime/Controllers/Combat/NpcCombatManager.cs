using Assets.Scripts.Runtime.Configs;
using Assets.Scripts.Runtime.Models.Combat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Controllers.Combat
{
    public class NpcCombatManager : CombatManager
    {
        protected override bool hasWeaponEquiped { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override event Action<int> OnAttack;
        public override event Action<bool> OnTakingDamage;
        public override event Action<float> OnHealthChanged;
        public override event Action OnDeath;
        private LayerMask _targetLayers;

        private Animator _animator;
        private StatsModel _healthModel;

        public NpcCombatManager(Animator animator, NpcConfig npcConfig)
        {
            _healthModel = new StatsModel(npcConfig.MaxHp);
            _animator = animator;
            _targetLayers = npcConfig.TargetLayers;
        }
        public override void HandleAttackBegin(AttackType attackType)
        {
            Debug.Log("START DEALING DAMAGE");

            List<DamageUnit> damageUnits = new List<DamageUnit>();
            switch (attackType)
            {
                case AttackType.STAND:
                    damageUnits.Add(new DamageUnit(DamageType.PHYSCICAL, currentCombatWeapon.WeaponDamagePoints, 0f));
                    break;
                case AttackType.JUMP:
                    damageUnits.Add(new DamageUnit(DamageType.PHYSCICAL, currentCombatWeapon.WeaponDamagePoints, 0.8f));
                    break;
                default:
                    break;
            }
            //damageUnits.Add(new DamageUnit(DamageType.PHYSCICAL, currentCombatWeapon.WeaponDamagePoints, currentCombatWeapon.DamageMultiplier));
            currentWeaponView.StartDealDamage(damageUnits, attackType, _targetLayers);
        }
        public override void HandleAttackEnd()
        {
            currentWeaponView.EndDealDamage();
            _canAttack = true;
        }
        private void HandleTakingDamageBegin(List<DamageUnit> damageUnits)
        {
            float totalDamage = 0f;
            foreach (var unit in damageUnits)
            {
                if (unit.DamageType != DamageType.PHYSCICAL)
                    totalDamage += unit.DamagePoints;
                else totalDamage += unit.DamagePoints * (1+unit.DamageMultiplier);


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
        public override void HandleIncomeDamage(List<DamageUnit> damageUnits, bool beginOrEnd)
        {
            if (beginOrEnd == true)
                HandleTakingDamageBegin(damageUnits);
            else HandleTakingDamageEnd();
        }
        public override void PerformAttackRequest()
        {
            
        }
    }
}






         
           
           
               
           

