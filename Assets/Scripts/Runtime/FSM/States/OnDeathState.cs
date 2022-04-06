using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.FSM.States
{
    [CreateAssetMenu(fileName = "newState", menuName = "StateMachine/OnDeathState")]
    public class OnDeathState : State
    {
        public override void OnEnter(Animator animator, StateHandler stateHandler, AnimatorStateInfo stateInfo)
        {

            ////var transform = stateHandler.GetAiController(animator).ControllerView.gameObject.transform;
            //Debug.Log($"rotation = {transform.rotation}");
            //var roatation = new Vector3(0f, transform.rotation.eulerAngles.y, 0f);
            //transform.rotation = Quaternion.Euler(roatation);
            //Debug.Log($"rotation = {transform.rotation}");
        }

        public override void OnExit(Animator animator, StateHandler stateHandler, AnimatorStateInfo stateInfo)
        {

        }

        public override void OnUpdate(Animator animator, StateHandler stateHandler, AnimatorStateInfo stateInfo)
        {

        }
    }
}