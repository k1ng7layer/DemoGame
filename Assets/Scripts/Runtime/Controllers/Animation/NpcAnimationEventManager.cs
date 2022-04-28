using Assets.Scripts.Runtime.Controllers.Combat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Controllers.Animation
{
    public class NpcAnimationEventManager : AnimationEventManager
    {
        public override event Action OnWeaponDraw;
        public override event Action OnWeaponHide;
        public override event Action<AttackType> OnStartDealingDamage;
        public override event Action OnEndDealingDamage;
        [SerializeField] private Animator _animator;
        [Header("Combat Settigns")]
        [SerializeField] private float _weaponDrawTiming;
        [SerializeField] private AnimationClip _weaponDrawClip;
        [SerializeField] private AnimationClip _weaponHideClip;
        [SerializeField] private float _weaponHideTiming;
        [SerializeField] private AnimationClip _attackClip1;
        [SerializeField] private float _attackTiming_Clip1_BEGIN;
        [SerializeField] private float _attackTiming_Clip1_END;
        [SerializeField] private AnimationClip _attackClip2;
        [SerializeField] private float _attackTiming_Clip2_BEGIN;
        [SerializeField] private float _attackTiming_Clip2_END;
        private void Awake()
        {
            _animator = this.GetComponent<Animator>();
        }
        private void Start()
        {
            var weaponDrawClip = _animator.runtimeAnimatorController.animationClips.Where(c => c.name == _weaponDrawClip.name).FirstOrDefault();
            AnimationEvent weaponDrawEvent = new AnimationEvent();
            weaponDrawEvent.time = _weaponDrawTiming;
            weaponDrawEvent.functionName = "WeaponDraw";
            //weaponDrawEvent.intParameter = _animator.GetInstanceID();
            weaponDrawClip.AddEvent(weaponDrawEvent);

            var weaponHideClip = _animator.runtimeAnimatorController.animationClips.Where(c => c.name == _weaponHideClip.name).FirstOrDefault();
            AnimationEvent weaponHideEvent = new AnimationEvent();
            weaponHideEvent.time = _weaponHideTiming;
            weaponHideEvent.functionName = "WeaponHide";
            //weaponHideEvent.intParameter = _animator.GetHashCode();
            weaponHideClip.AddEvent(weaponHideEvent);


            //BEGIN ATTACK EVENTS
            var weaponDealingDamageClip1 = _animator.runtimeAnimatorController.animationClips.Where(c => c.name == _attackClip1.name).FirstOrDefault();
            AnimationEvent weaponBeginDealingDamageEvent1 = new AnimationEvent();
            weaponBeginDealingDamageEvent1.time = _attackTiming_Clip1_BEGIN;
            weaponBeginDealingDamageEvent1.functionName = "DealingDamageStart";
            weaponBeginDealingDamageEvent1.intParameter = _animator.GetHashCode();
            weaponDealingDamageClip1.AddEvent(weaponBeginDealingDamageEvent1);

            var weaponDealingDamageClip2 = _animator.runtimeAnimatorController.animationClips.Where(c => c.name == _attackClip2.name).FirstOrDefault();
            AnimationEvent weaponBeginDealingDamageEvent2 = new AnimationEvent();
            weaponBeginDealingDamageEvent2.time = _attackTiming_Clip2_BEGIN;
            weaponBeginDealingDamageEvent2.functionName = "DealingDamageStart2";
            weaponBeginDealingDamageEvent2.intParameter = _animator.GetHashCode();
            weaponDealingDamageClip2.AddEvent(weaponBeginDealingDamageEvent2);

            //END ATTACK EVENTS
            AnimationEvent weaponEndDealingDamageEvent1 = new AnimationEvent();
            weaponEndDealingDamageEvent1.time = _attackTiming_Clip1_END;
            weaponEndDealingDamageEvent1.functionName = "DealingDamageEnd";
            weaponEndDealingDamageEvent1.intParameter = _animator.GetHashCode();
            weaponDealingDamageClip1.AddEvent(weaponEndDealingDamageEvent1);

            AnimationEvent weaponEndDealingDamageEvent2 = new AnimationEvent();
            weaponEndDealingDamageEvent2.time = _attackTiming_Clip2_END;
            weaponEndDealingDamageEvent2.functionName = "DealingDamageEnd";
            weaponEndDealingDamageEvent2.intParameter = _animator.GetHashCode();
            weaponDealingDamageClip2.AddEvent(weaponEndDealingDamageEvent2);
        }

        private void WeaponDraw(int aniamtorCode)
        {
            Debug.Log($"WeaponDraw = invoked by animator  = {_animator.GetInstanceID()}, aniamtorCode = {aniamtorCode}");
            //if (_animator.GetHashCode() == aniamtorCode)
                    OnWeaponDraw?.Invoke();
        }
        private void WeaponHide(int aniamtorCode)
        {
            Debug.Log("WeaponHide");
            //if (_animator.GetHashCode() == aniamtorCode)
                OnWeaponHide?.Invoke();
        }
        private void DealingDamageStart(int aniamtorCode)
        {
            if (_animator.GetHashCode() == aniamtorCode)
                OnStartDealingDamage?.Invoke(AttackType.STAND);
        }
        private void JumpAttackBegin(int aniamtorCode)
        {
            if (_animator.GetHashCode() == aniamtorCode)
                OnStartDealingDamage?.Invoke(AttackType.JUMP);
        }
        private void JumpAttackEnd(int aniamtorCode)
        {
            if (_animator.GetHashCode() == aniamtorCode)
                OnEndDealingDamage?.Invoke();
        }
        private void DealingDamageStart2(int aniamtorCode)
        {
            if (_animator.GetHashCode() == aniamtorCode)
                OnStartDealingDamage?.Invoke(AttackType.STAND);
        }
        private void DealingDamageEnd(int aniamtorCode)
        {
            if (_animator.GetHashCode() == aniamtorCode)
                OnEndDealingDamage?.Invoke();
        }
    }
}
