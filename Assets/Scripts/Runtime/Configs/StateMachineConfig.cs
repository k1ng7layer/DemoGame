using Assets.Scripts.Runtime.FSM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Configs
{
    [CreateAssetMenu(fileName ="new SM config", menuName = "Configs/StateMachineConfig")]
    public class StateMachineConfig:ScriptableObject, ISerializationCallbackReceiver
    {
        [SerializeField] private List<string> _stateIds = new List<string>();
        [SerializeField] private List<StateBase> _states = new List<StateBase>();
        public Dictionary<string, StateBase> StatesTable = new Dictionary<string, StateBase>();

        public void OnBeforeSerialize()
        {
            
        }

        public void OnAfterDeserialize()
        {
            
        }
    }
}
