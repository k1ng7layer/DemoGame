using Assets.Scripts.Runtime.Controllers.Combat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Controllers.Animation
{
    public class PlayerAnimationEventManager : AnimationEventManager
    {
       
        [Header("Combat Settigns")]
        [SerializeField] private AnimationClip _weaponDrawClip;
        [SerializeField] private float _weaponDrawTiming;
        [SerializeField] private AnimationClip _weaponHideClip;
        [SerializeField] private float _weaponHideTiming;
        [SerializeField] private AnimationClip _attackClip1;
        [SerializeField] private float _attackTiming_Clip1_BEGIN;
        [SerializeField] private float _attackTiming_Clip1_END;
        [SerializeField] private AnimationClip _attackClip2;
        [SerializeField] private float _attackTiming_Clip2_BEGIN;
        [SerializeField] private float _attackTiming_Clip2_END;
        [SerializeField] private AnimationClip _jumpAttackClip;
        [SerializeField] private float _attackTiming_jumpAttackClip_BEGIN;
        [SerializeField] private float _attackTiming_jumpAttackClip_END;
        [SerializeField] private Animator _animator;
        public override event Action OnWeaponDraw;
        public override event Action OnWeaponHide;
        public override event Action<AttackType> OnStartDealingDamage;
        public override event Action OnEndDealingDamage;
        public override event Action OnThrowWeapon;

        public Animator animator;

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
            weaponDrawEvent.intParameter = _animator.GetInstanceID();
            weaponDrawClip.AddEvent(weaponDrawEvent);

            var weaponHideClip = _animator.runtimeAnimatorController.animationClips.Where(c => c.name == _weaponHideClip.name).FirstOrDefault();
            AnimationEvent weaponHideEvent = new AnimationEvent();
            weaponHideEvent.time = _weaponHideTiming;
            weaponHideEvent.functionName = "WeaponHide";
            weaponHideEvent.intParameter = _animator.GetHashCode();
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


            var weaponDealingDamageJumpAttackClip1 = _animator.runtimeAnimatorController.animationClips.Where(c => c.name == _jumpAttackClip.name).FirstOrDefault();
            AnimationEvent weaponDealingDamageJumpClip1Begin = new AnimationEvent();
            weaponDealingDamageJumpClip1Begin.time = _attackTiming_jumpAttackClip_BEGIN;
            weaponDealingDamageJumpClip1Begin.functionName = "JumpAttackBegin";
            weaponDealingDamageJumpClip1Begin.intParameter = _animator.GetHashCode();
            weaponDealingDamageJumpAttackClip1.AddEvent(weaponDealingDamageJumpClip1Begin);


            //var weaponDealingDamageJumpAttackClip1 = _animator.runtimeAnimatorController.animationClips.Where(c => c.name == _jumpAttackClip.name).FirstOrDefault();
            AnimationEvent weaponDealingDamageJumpClip1END = new AnimationEvent();
            weaponDealingDamageJumpClip1END.time = _attackTiming_jumpAttackClip_END;
            weaponDealingDamageJumpClip1END.functionName = "JumpAttackEnd";
            weaponDealingDamageJumpClip1END.intParameter = _animator.GetHashCode();
            weaponDealingDamageJumpAttackClip1.AddEvent(weaponDealingDamageJumpClip1END);

        }
       

        private void WeaponDraw(int animatorId)
        {
            var time = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
            //var tttt = animator.GetCurrentAnimatorClipInfo(2)[0].clip.name;
            Debug.Log($"NORMILIZED TIME = {time}");
            Debug.Log($"DAMAGE");
            Debug.Log($"WeaponDraw = {this.gameObject}");
            if (_animator.GetHashCode() == animatorId)
                OnWeaponDraw?.Invoke();
        }
        private void WeaponHide(int animatorId)
        {
            Debug.Log("WeaponHide");
            if (_animator.GetHashCode() == animatorId)
                OnWeaponHide?.Invoke();
        }

        private void DealingDamageStart(int animatorId)
        {
            if (_animator.GetHashCode() == animatorId)
                OnStartDealingDamage?.Invoke(AttackType.STAND);
        }
        private void JumpAttackBegin(int animatorId)
        {
            if (_animator.GetHashCode() == animatorId)
                OnStartDealingDamage?.Invoke(AttackType.JUMP);
        }
        private void JumpAttackEnd(int animatorId)
        {
            if (_animator.GetHashCode() == animatorId)
                OnEndDealingDamage?.Invoke();
        }
        private void DealingDamageStart2(int animatorId)
        {
            if (_animator.GetHashCode() == animatorId)
                OnStartDealingDamage?.Invoke(AttackType.STAND);
        }
        private void DealingDamageEnd(int animatorId)
        {
            if(_animator.GetHashCode()==animatorId)
                OnEndDealingDamage?.Invoke();
        }
            
    }
}
        
         


        
            
            
            
