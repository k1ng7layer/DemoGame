using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.FSM
{
    public class StateMachine
    {
        private StateBase _currentState;
        private Dictionary<string, StateBase> _statesTable;
        public StateMachine(Dictionary<string, StateBase> statesTable)
        {
            _statesTable = statesTable;
            foreach (var state in _statesTable.Values)
            {
                state.AttachStateMachine(this);
            }
        }
        public void InitializeSateMachine(string stateName)
        {
            if (_statesTable.TryGetValue(stateName, out StateBase state))
            {
                
                _currentState = state;
               
            }
        }
        public void ChangeState(string name)
        {
            if(_statesTable.TryGetValue(name,out StateBase state))
            {
                if(_currentState!=null)
                 _currentState.OnStateExit();

                _currentState = state;
                _currentState.OnStateEnter();
            }
            else
            {
                Debug.LogError($"There is no registered state named = {name}");
            }
        }
        public void UpdateStateMachine()
        {
            if(_currentState!=null)
                _currentState.OnStateUpdate();

            //Debug.Log($"Current State = {_currentState}");
        }
        public void FixedUpdateStateMachine()
        {
            if(_currentState!=null)
                _currentState.OnStateFixedUpdate();
        }
    }
}
        
           
     
          
