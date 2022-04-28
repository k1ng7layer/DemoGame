using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Runtime.Models
{
    public class NavMeshTargetChaseModel : TargetChaseModel
    {
        private NavMeshAgent _navMeshAgent;
        private Rigidbody _rigidBody;
        private Vector3 _velocity = Vector3.zero;
        private Transform _target;
        private Animator _animator;
        private bool _enabled;
        public NavMeshTargetChaseModel(NavMeshAgent navMeshAgent, Rigidbody rigidbody, Animator animator)
        {
            _navMeshAgent = navMeshAgent;
            _rigidBody = rigidbody;
            _navMeshAgent.updatePosition = false;
            _animator = animator;
            _rigidBody.isKinematic = true;
            _navMeshAgent.speed = 2f;
        }
        public override void ChaseTarget(Transform target, bool enable)
        {
            _target = target;
            _enabled = enable;
            //_navMeshAgent.nextPosition = target.position;
            //_navMeshAgent.SetDestination(_target.transform.position);
            //var dir = _navMeshAgent.nextPosition = _rigidBody.transform.position;
            //_rigidBody.velocity = dir.normalized*10f;
            Debug.Log($"_rigidBody velocity = {_rigidBody.velocity}");
            Debug.Log($"Destination = {_navMeshAgent.destination}");
                 Debug.Log($"NavMesh Target =  = {_target.name}");
            //var move = Vector3.SmoothDamp(_rigidBody.transform.position, _navMeshAgent.nextPosition, ref _velocity, 10f);
            //_rigidBody.MovePosition(_rigidBody.transform.position + move);
          


        }

        public override void UpdateModel()
        {
            if (_enabled)
            {
                _rigidBody.isKinematic = true;
                _navMeshAgent.enabled = true;
                _navMeshAgent.isStopped = false;
                _navMeshAgent.updatePosition = true;
                _navMeshAgent.updateRotation = true;
                _navMeshAgent.speed = 2.5f;
                _navMeshAgent.SetDestination(_target.position);
                _animator.SetFloat("Movement", _navMeshAgent.velocity.normalized.magnitude * 0.5f, 0.1f, Time.fixedDeltaTime);
            }
            else
            {
                _enabled = false;
                _rigidBody.isKinematic = false;
                _animator.SetFloat("Movement", 0f);
                _navMeshAgent.enabled = false;
               
            }

        }
    }
}


               
               
