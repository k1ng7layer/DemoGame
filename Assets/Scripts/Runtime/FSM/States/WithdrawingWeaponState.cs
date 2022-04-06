using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.FSM.States
{
    [CreateAssetMenu(fileName = "newState", menuName = "StateMachine/withDrawWeaponState")]
    public class WithdrawingWeaponState : State
    {
        public override void OnEnter(Animator animator, StateHandler stateHandler, AnimatorStateInfo stateInfo)
        {

        }

        public override void OnExit(Animator animator, StateHandler stateHandler, AnimatorStateInfo stateInfo)
        {

        }

        public override void OnUpdate(Animator animator, StateHandler stateHandler, AnimatorStateInfo stateInfo)
        {
            //if (stateHandler.GetPlayerController().playerInput.withdrawWeapon)
            //{
            //    animator.SetBool("WeaponWithdraw", true);
            //}
        }
    }
}
