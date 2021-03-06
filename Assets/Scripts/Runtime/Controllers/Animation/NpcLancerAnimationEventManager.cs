using Assets.Scripts.Runtime.Controllers.Combat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Controllers.Animation
{
    public class NpcLancerAnimationEventManager : AnimationEventManager
    {
        public override event Action OnWeaponDraw;
        public override event Action OnWeaponHide;
        public override event Action<AttackType> OnStartDealingDamage;
        public override event Action OnEndDealingDamage;
        public event Action OnWeaponSpawn;
        public override event Action OnThrowWeapon;
        [SerializeField] private AnimationClip _drawWeaponClip;
        [SerializeField] float _weaponSpawnTiming;
        [SerializeField] private AnimationClip _weaponThrowClip;
        [SerializeField] private float _weaponThrowTiming;
        [SerializeField] private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            var weaponDrawClip = _drawWeaponClip;
            AnimationEvent weaponDrawEvent = new AnimationEvent();
            weaponDrawEvent.time = _weaponSpawnTiming;
            weaponDrawEvent.functionName = "HandleSpawnWeapon";
            weaponDrawEvent.intParameter = _animator.GetInstanceID();
            weaponDrawClip.AddEvent(weaponDrawEvent);


            _animator = GetComponent<Animator>();
            var weaponThrow = _weaponThrowClip;
            AnimationEvent weaponThrowEvent = new AnimationEvent();
            weaponThrowEvent.time = _weaponThrowTiming;
            weaponThrowEvent.functionName = "HandleThrowWeapon";
            weaponThrowEvent.intParameter = _animator.GetInstanceID();
            weaponThrow.AddEvent(weaponThrowEvent);
        }

        private void HandleSpawnWeapon(int hashCode)
        {
            
            if (_animator.GetInstanceID() == hashCode)
            {
                //Debug.Log($"SPAWN WEAPON IN {_animator.GetInstanceID()} by {hashCode}");
                OnWeaponDraw?.Invoke();
            }
                   
        }

        private void HandleThrowWeapon(int hashCode)
        {
            if (_animator.GetInstanceID() == hashCode)
                OnStartDealingDamage?.Invoke(AttackType.STAND);
        }

    }
}
