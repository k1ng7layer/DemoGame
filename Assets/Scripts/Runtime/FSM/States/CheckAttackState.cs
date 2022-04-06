using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.FSM.States
{
    [CreateAssetMenu(fileName = "newState", menuName = "StateMachine/AttackCheckState")]
    public class CheckAttackState : State
    {
        private static System.Random random;
        public override void OnEnter(Animator animator, StateHandler stateHandler, AnimatorStateInfo stateInfo)
        {

        }

        public override void OnExit(Animator animator, StateHandler stateHandler, AnimatorStateInfo stateInfo)
        {

        }

        public override void OnUpdate(Animator animator, StateHandler stateHandler, AnimatorStateInfo stateInfo)
        {
            //random = new System.Random();
            //if (stateHandler.GetPlayerController().playerInput.attack == true)
            //{
            //    var rand = UnityEngine.Random.Range(0, 20);

            //    var result = rand % 2;
            //    var value = random.Next(1, 2);
            //    Debug.Log($"rand = {rand}, result = {result}");
            //    if (result == 0)
            //    {
            //        animator.SetBool("Attack1", true);
            //    }
            //    if (result == 1)
            //    {
            //        animator.SetBool("Attack2", true);
            //    }

            //}
        }
    }
}
