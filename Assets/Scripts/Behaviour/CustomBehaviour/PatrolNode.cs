using Assets.Scripts.Runtime.Controllers;
using Assets.Scripts.Runtime.Models;
using Assets.Scripts.Runtime.Views;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace AIBehaviour
{
    public class PatrolNode:Node
    {
        private Transform[] _wayPoints;
        private NpcView _enemyView;
        private NavMeshAgent _meshAgent;
        private int _currentWayPointIndex = 0;
        private Animator _animator;
        private MovementModel _movementModel;
        private Rigidbody _rigidbody;
        private float _waitingTime = 3f;
        private float _waitiCounter;
        private bool _waiting = false;
        private bool _isWayPointSwitched;
        public PatrolNode(Transform owner, Transform[] waypoints, NavMeshAgent navMesh, Animator _animator, Rigidbody rigidbody)
        {
            _wayPoints = waypoints;
            _enemyView = owner.GetComponent<NpcView>();
            _meshAgent = navMesh;
            this._animator = _animator;
            _rigidbody = rigidbody;
            _movementModel = new RigidBodyMovementModel(_rigidbody);
            _movementModel.SetAnimator(_animator);
        }

        public override NodeState Evaluate()
        {
            Transform wayPoint = _wayPoints[_currentWayPointIndex];
            var distance = Vector3.Distance(_enemyView.transform.position, wayPoint.position);

            Debug.Log($"Distance = {distance}");
            if (distance > 1.8f&&!_waiting)
            {
                _rigidbody.isKinematic = true;
                _isWayPointSwitched = false;
                _meshAgent.enabled = true;
              
                _meshAgent.updatePosition = true;
                _meshAgent.updateRotation = true;
                _meshAgent.isStopped = false;
                _meshAgent.SetDestination(wayPoint.position);
                _animator.SetFloat("Movement", _meshAgent.desiredVelocity.normalized.magnitude * 0.5f);
            }
            else
            {
                Debug.Log($"222222222222222222222");
                _meshAgent.enabled = false;
                _rigidbody.isKinematic = false;
                _waiting = true;
                _meshAgent.updatePosition = false;
                _meshAgent.updateRotation = false;
                _rigidbody.isKinematic = false;

                if (!_isWayPointSwitched)
                {
                    if (_currentWayPointIndex == _wayPoints.Length - 1)
                    {
                        _currentWayPointIndex = 0;
                    }
                    else
                    {
                        _currentWayPointIndex++;
                    }
                    _isWayPointSwitched = true;
                }
                //_meshAgent.enabled = false;
               
              
                Transform nextWayPoint = _wayPoints[_currentWayPointIndex];
                //_meshAgent.SetDestination(nextWayPoint.position);
                Debug.Log($"waypoint index = {_currentWayPointIndex}, is waiting = {_waiting}");
                //_enemyView.transform.LookAt(nextWayPoint);
                RootController.Instance.RunCoroutine(WaitForRotation(nextWayPoint));
            }
            return NodeState.RUNNING;
            
        }


               
                

              
               

        public IEnumerator WaitForRotation(Transform wayPoint)
        {
            Vector3 targetRotation = wayPoint.transform.position - _enemyView.transform.position;
            Debug.Log($"waypoint rotation = {wayPoint.rotation}");
            Debug.Log($"waypoint position = {wayPoint.position}");
            _enemyView.transform.rotation = Quaternion.Slerp(_enemyView.transform.rotation, Quaternion.LookRotation(targetRotation), 3f * Time.deltaTime);
            yield return new WaitForSeconds(5f);
            _waiting = false;
        }

        
    }
}
