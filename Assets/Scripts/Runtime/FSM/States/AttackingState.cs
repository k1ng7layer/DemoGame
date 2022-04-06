using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.FSM.States
{
    [CreateAssetMenu(fileName = "newState", menuName = "StateMachine/AttackState")]
    public class AttackingState : State
    {
        public override void OnEnter(Animator animator, StateHandler stateHandler, AnimatorStateInfo stateInfo)
        {
            //stateHandler.GetPlayerController().TryToDash();
            //stateHandler.GetPlayerController().View.CurrentWeapon.inAction = false;
        }

        public override void OnExit(Animator animator, StateHandler stateHandler, AnimatorStateInfo stateInfo)
        {
            //stateHandler.GetPlayerController().View.IsAttacking = false;
            Debug.Log("ending of attack");
        }

        public override void OnUpdate(Animator animator, StateHandler stateHandler, AnimatorStateInfo stateInfo)
        {
            animator.SetBool("Attack1", false);
            animator.SetBool("Attack2", false);

        }
    }
}