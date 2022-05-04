using Assets.Scripts.Runtime.Views;
using System.Collections;
using UnityEngine;

namespace AIBehaviour
{
    public class TakeDamageNode:Node
    {
        private bool _takingDamage;
        public TakeDamageNode(Transform owner, Animator animator)
        {
            
        }
        internal override void InitializeNode()
        {
            Handler.OnTakingDamage += HandleTakingDamage;
            base.InitializeNode();
        }

        public override NodeState Evaluate()
        {

            //Debug.Log($"TakingDamage = {_takingDamage}");
            if (_takingDamage)
                return NodeState.FAILURE;
                
                return NodeState.RUNNING;
        }
        private void HandleTakingDamage(bool value)
        {
            _takingDamage = value;
        }

        internal override void OnDestroy()
        {
            Handler.OnTakingDamage -= HandleTakingDamage;
        }

    }
}

       
        
            
            

          
           
           
  

        
