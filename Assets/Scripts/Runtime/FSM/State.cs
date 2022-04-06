using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.FSM
{
    public abstract class State : ScriptableObject
    {
        [SerializeField]
        protected float _timing;
        public abstract void OnEnter(Animator animator, StateHandler stateHandler, AnimatorStateInfo stateInfo);
        public abstract void OnUpdate(Animator animator, StateHandler stateHandler, AnimatorStateInfo stateInfo);
        public abstract void OnExit(Animator animator, StateHandler stateHandler, AnimatorStateInfo stateInfo);
    }
}
