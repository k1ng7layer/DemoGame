
using Assets.Scripts.Runtime.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace AIBehaviour
{
    public class ChaseTargetNode:Node
    {
        private Transform _playerTransform;
        private NavMeshAgent _navMeshAgent;
        private Animator _animator;
        
        private Rigidbody _rb;
        private float _stopDistance;
        public ChaseTargetNode(Transform transform, NavMeshAgent navMeshAgent, Animator animator, Rigidbody rigidbody, float stopDistance = 1.9f)
        {
            _rb = rigidbody;
            _playerTransform = transform;
            _navMeshAgent = navMeshAgent;
            _animator = animator;
            _stopDistance = stopDistance;
        }


       
        public override NodeState Evaluate()
        {
            var target = parent.GetData("target");

            if (target != null)
            {
                var distance = Vector3.Distance(_playerTransform.position, target.Target.position);
                if (distance > _stopDistance)
                {
                    Handler.InvokeTargetChasing(target.Target, true);
                    return NodeState.RUNNING;
                }
                else
                {
                    Handler.InvokeTargetChasing(target.Target, false);
                    return NodeState.SUCCESS;
                }
            }
            else
            {
                return NodeState.RUNNING;
            }

        }
   
    }
                
}

               

                    
                    
