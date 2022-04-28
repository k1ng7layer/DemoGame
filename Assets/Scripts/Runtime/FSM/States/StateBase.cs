using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Runtime.FSM
{
    
    public abstract class StateBase
    {
        protected StateMachine _stateMachine;
        public abstract void OnStateEnter();
        public abstract void OnStateUpdate();
        public abstract void OnStateFixedUpdate();
        public abstract void OnStateExit();
        public abstract void OnStateLateUpdate();
        internal void AttachStateMachine(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
    }
}

