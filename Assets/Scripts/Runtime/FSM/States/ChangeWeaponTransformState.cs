using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.FSM.States
{
    [CreateAssetMenu(fileName = "newState", menuName = "StateMachine/ChangeWeaponTransformState")]
    public class ChangeWeaponTransformState : State
    {
        public override void OnEnter(Animator animator, StateHandler stateHandler, AnimatorStateInfo stateInfo)
        {

        }

        public override void OnExit(Animator animator, StateHandler stateHandler, AnimatorStateInfo stateInfo)
        {

        }

        public override void OnUpdate(Animator animator, StateHandler stateHandler, AnimatorStateInfo stateInfo)
        {
            if (stateInfo.normalizedTime >= _timing)
            {
                Debug.Log("DrawActiveWeapon");
                //stateHandler.GetPlayerController().inventoryManager.DrawActiveWeapon();
            }
        }
    }
}
