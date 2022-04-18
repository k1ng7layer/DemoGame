using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Controllers.Animation
{
    public class PlayerAnimationManager : AnimationManager
    {
        private List<Action> _callbacks;
        public PlayerAnimationManager(Animator animator, PlayerAnimationEventManager eventManager) : base(animator)
        {
            _callbacks = new List<Action>();
        }
        public void DrawOrHideWeapon()
        {
            if (_animator.GetBool("WeaponWithdraw") == false)
                    _animator.SetBool("WeaponWithdraw", true);
            else _animator.SetBool("WeaponWithdraw", false);
        }
        public void EnableAttackAnimation(int index)
        {
            _animator.SetTrigger("Attack");
        }
        
    }
}
      
        





