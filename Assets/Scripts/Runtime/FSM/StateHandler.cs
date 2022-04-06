using Assets.Scripts.Runtime.Controllers;
using Assets.Scripts.Runtime.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.FSM
{
    public class StateHandler:StateMachineBehaviour
    {
        [SerializeField] private List<State> States = new List<State>();
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            foreach (var state in States)
            {
                state.OnEnter(animator, this, stateInfo);
            }
        }
        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            UpdateStates(animator, stateInfo, layerIndex);
        }
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            foreach (var state in States)
            {
                state.OnExit(animator, this, stateInfo);
            }
        }

        void UpdateStates(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            foreach (var state in States)
            {
                state.OnUpdate(animator, this, stateInfo);
            }
        }
        public PlayerController GetPlayerController()
        {
            return SceneGameManagerView.Instance.CurrentPlayer;
        }

        //public AiController GetAiController(Animator animator)
        //{
        //    return SceneGameManagerView.Instance.GetAiController(animator);
        //}

    }
}

