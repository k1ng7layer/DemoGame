using Assets.Scripts.Runtime.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Runtime.Models
{ 
    class SingleNavMeshTargetChaseModel:TargetChaseModel
    {
        private NavMeshAgent _navMeshAgent;
        private Rigidbody _rigidbody;
        private Animator _animator;
        private bool _ready;
        private bool _enable;
        private Transform _target;
        public SingleNavMeshTargetChaseModel(NavMeshAgent navMeshAgent, Rigidbody rigidbody, Animator animator)
        {
            _navMeshAgent = navMeshAgent;
            _rigidbody = rigidbody;
            _animator = animator;
        }
        public override void ChaseTarget(Transform target, bool enable)
        {
            //_enable = enable;
            _target = target;
            RootController.Instance.RunCoroutine(MovingDelay(enable));
            //_enable = enable;
        }

        public override void UpdateModel()
        {
            if (_enable)
            {

                //if (_ready)
                //{
                _rigidbody.isKinematic = true;
                _navMeshAgent.enabled = true;
                _navMeshAgent.isStopped = false;
                _navMeshAgent.updatePosition = true;
                _navMeshAgent.updateRotation = true;
                _navMeshAgent.speed = 2.5f;

                _animator.SetBool("Attack2", false);
                _animator.SetBool("Attack1", false);

                _animator.SetFloat("Movement", _navMeshAgent.desiredVelocity.normalized.magnitude * 0.5f, 0.1f, Time.deltaTime);
                _navMeshAgent.SetDestination(_target.position);
                //}

            }
            else
            {
                Stopped();
            }
        }

        private IEnumerator MovingDelay(bool value)
        {
            yield return new WaitForSeconds(0.5f);
            _enable = value;
        }
        private void Stopped()
        {
            _rigidbody.isKinematic = false;
            _animator.SetFloat("Movement", 0f);
            _navMeshAgent.enabled = false;
            RootController.Instance.StopMyCoroutine(MovingDelay(false));
            _enable = false;

        }
    }
}
