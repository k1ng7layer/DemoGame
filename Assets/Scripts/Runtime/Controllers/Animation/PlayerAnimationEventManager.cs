using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Controllers.Animation
{
    public class PlayerAnimationEventManager:AnimationEventManager
    {
       
        [Header("Combat Settigns")]
        [SerializeField] private AnimationClip _weaponDrawClip;
        [SerializeField] private float _weaponDrawTiming;
        [SerializeField] private AnimationClip _weaponHideClip;
        [SerializeField] private float _weaponHideTiming;
        public override event Action OnWeaponDraw;
        public override event Action OnWeaponHide;
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
            weaponDrawClip.AddEvent(weaponDrawEvent);

            var weaponHideClip = _animator.runtimeAnimatorController.animationClips.Where(c => c.name == _weaponHideClip.name).FirstOrDefault();
            AnimationEvent weaponHideEvent = new AnimationEvent();
            weaponHideEvent.time = _weaponHideTiming;
            weaponHideEvent.functionName = "WeaponHide";
            weaponHideClip.AddEvent(weaponHideEvent);
        }
       

        private void WeaponDraw()
        {
            Debug.Log("WeaponDraw");
            OnWeaponDraw?.Invoke();
        }
        private void WeaponHide()
        {
            Debug.Log("WeaponHide");
            OnWeaponHide?.Invoke();
        }


    }
}
            
