
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


        //public override NodeState Evaluate()
        //{

        //    var target = parent.GetData("target");

        //    if (target != null)
        //    {
        //        var distance = Vector3.Distance(_playerTransform.position, target.Target.position);


        //        if (distance >=_stopDistance)
        //        {
        //            _rb.isKinematic = true;
        //            _navMeshAgent.enabled = true;
        //            _navMeshAgent.isStopped = false;
        //            _navMeshAgent.updatePosition = true;
        //            _navMeshAgent.updateRotation = true;

        //            _animator.SetBool("Attack2", false);
        //            _animator.SetBool("Attack1", false);

        //            _animator.SetFloat("Movement", _navMeshAgent.desiredVelocity.normalized.magnitude * 0.5f);
        //            _navMeshAgent.SetDestination(target.Target.position);

        //            return NodeState.RUNNING;
        //        }
        //        else
        //        {
        //            _rb.isKinematic = false;
        //            _animator.SetFloat("Movement", 0f);
        //            _navMeshAgent.enabled = false;
        //            return NodeState.SUCCESS;
        //        }
        //    }
        //    else
        //    {
        //        return NodeState.RUNNING;
        //    }

        //}
        public override NodeState Evaluate()
        {

            var target = parent.GetData("target");

            if (target != null)
            {
                var distance = Vector3.Distance(_playerTransform.position, target.Target.position);
                Debug.Log($"dddddddddddddddddddddddddddddddd ={distance} ");

                if (distance >= _stopDistance)
                {
                    Handler.InvokeTargetChasing(target.Target, true);
                    Debug.Log("dddddddddddddddddddddddddddddddd");
                    return NodeState.RUNNING;
                }
                else
                {
                    Debug.Log("dddddddddddddddddddddddddddddddd");
                    Handler.InvokeTargetChasing(target.Target, false);
                    return NodeState.SUCCESS;
                }
            }
            else
            {
                return NodeState.RUNNING;
            }

        }
        //public override NodeState EvaluatePhysics()
        //{

        //}
    }
                
}
