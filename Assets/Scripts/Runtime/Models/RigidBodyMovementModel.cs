using Assets.Scripts.Runtime.Controllers;
using Assets.Scripts.Runtime.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Models
{
    public class RigidBodyMovementModel : MovementModel
    {

        private readonly Rigidbody _rb;
        const float LocomotionSmoothTime = .1f;
        float turnSmoothVelocity;
        public float turnSmoothTime = 0.1f;
        private bool _isGrounded;
        public override bool IsGrounded => _isGrounded;
   
        private Transform groundCheck;
        private LayerMask layerMask;
        private Vector3 _currentDirection;
        private bool _dash;
        private Collider _playerCollider;
        private bool _canJump = true;

        public override event Action OnGroundAction;

        //
        public RigidBodyMovementModel(Rigidbody rigidbody)
        {
            _rb = rigidbody;
            layerMask = LayerMask.GetMask("Ground");
            if (!_rb.gameObject.TryGetComponent<GroundCheckView>(out GroundCheckView checkView))
            {
                GameObject obj = new GameObject("groundCheck");
                var int1 = LayerMask.NameToLayer("GroundCheck");
                var int2 = LayerMask.GetMask("GroundCheck");
               
                obj.layer = LayerMask.NameToLayer("GroundCheck");
                Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("GroundCheck"));
                obj.transform.SetParent(_rb.gameObject.transform);
                _playerCollider = _rb.gameObject.GetComponent<Collider>();
                var pos = _playerCollider.bounds.center.y - _playerCollider.bounds.size.y / 2;
                obj.transform.position = new Vector3(obj.transform.position.x, pos, obj.transform.position.z);
                groundCheck = obj.transform;
            }

        }
        public override Vector3 Velocity { get; protected set; }

        //public override void Jump(float jumpforce)
        //{

        //    if (GroundCheck()&& _canJump)
        //    {
        //        if (_currentDirection.magnitude > 0.1f)
        //        {
        //            var force = new Vector3(0f, jumpforce, 0f) + _rb.transform.forward * jumpforce;
        //            _rb.AddForce(force);
        //            _canJump = false;
        //            _isGrounded = false;
        //            RootController.Instance.RunCoroutine(CheckCanJumpCoroutine());
        //            Debug.Log($"rb velocityw {_rb.velocity.magnitude}");
        //        }
        //        else
        //        {
        //            _rb.AddForce(new Vector3(0f, jumpforce, 0f));
        //            _isGrounded = false;
        //            _canJump = false;
        //            RootController.Instance.RunCoroutine(CheckCanJumpCoroutine());
        //        }
        //        IsJumped = true;

        //        _animator.SetBool("Jump", true);

        //    }
        //}

        //Метод для прыжка


        public override void Jump(float jumpforce)
        {

            if (IsGrounded && _canJump)
            {
                if (_currentDirection.magnitude > 0.1f)
                {
                    var force = new Vector3(0f, jumpforce, 0f) + _rb.transform.forward * jumpforce;
                    _rb.AddForce(force);
                    Velocity = _rb.velocity;
                    _canJump = false;
                    _isGrounded = false;
                    RootController.Instance.RunCoroutine(CheckCanJumpCoroutine());
                    Debug.Log($"rb velocityw {_rb.velocity.magnitude}");
                }
                else
                {
                    _rb.AddForce(new Vector3(0f, jumpforce, 0f));
                    Velocity = _rb.velocity;
                    _isGrounded = false;
                    _canJump = false;
                    RootController.Instance.RunCoroutine(CheckCanJumpCoroutine());
                }
                IsJumped = true;

                _animator.SetBool("Jump", true);

            }
        }

        private IEnumerator CheckCanJumpCoroutine()
        {
            yield return new WaitForSeconds(1.5f);
            _canJump = true;
        }

        public override void MovePlayer(float x, float z)
        {
            _animator.SetFloat("Movement", 0f, LocomotionSmoothTime, Time.fixedDeltaTime);
            var direction = new Vector3(x, 0f, z);
            _currentDirection = direction;
            if (direction.magnitude > 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(_rb.transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                _rb.transform.rotation = Quaternion.Euler(0f, angle, 0f);
                _currentDirection = moveDirection;
                _rb.MovePosition(_rb.transform.position + moveDirection * 3f * Time.fixedDeltaTime);
                Velocity = _rb.velocity;
                _animator.SetFloat("Movement", direction.normalized.magnitude, LocomotionSmoothTime, Time.fixedDeltaTime);
            }
          
        }







        //public override void MovePlayer(float x, float z, float speed)
        //{
        //    _animator.SetFloat("Movement", 0f, LocomotionSmoothTime, Time.fixedDeltaTime);
        //    var direction = new Vector3(x, 0f, z);
        //    if (direction.magnitude > 0.1f)
        //    {
        //        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        //        float angle = Mathf.SmoothDampAngle(_rb.transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        //        Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        //        _rb.transform.rotation = Quaternion.Euler(0f, angle, 0f);
        //        _rb.velocity = new Vector3(moveDirection.x * speed, _rb.velocity.y, moveDirection.z * speed);
        //        _animator.SetFloat("Movement", direction.normalized.magnitude, LocomotionSmoothTime, Time.fixedDeltaTime);
        //    }
        //    Velocity = _rb.velocity;
        //}
        public override void MovePlayer(float x, float z, float speed)
        {
            _animator.SetFloat("Movement", 0f, LocomotionSmoothTime, Time.fixedDeltaTime);
            var direction = new Vector3(x, 0f, z);
            _currentDirection = direction;
            if (direction.magnitude > 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(_rb.transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                _rb.transform.rotation = Quaternion.Euler(0f, angle, 0f);
                _currentDirection = moveDirection;
                _rb.MovePosition(_rb.transform.position + moveDirection * speed * Time.fixedDeltaTime);
                Velocity = _rb.velocity;
                _animator.SetFloat("Movement", direction.normalized.magnitude* speed, LocomotionSmoothTime, Time.fixedDeltaTime);
            }
            
        }

        public override bool GroundCheck()
        {
            
            if (Physics.CheckSphere(new Vector3(_rb.transform.position.x, _playerCollider.bounds.center.y-_playerCollider.bounds.size.y/2, _rb.transform.position.z), 0.01f, layerMask))
            {
                OnGroundAction?.Invoke();
                _isGrounded = true;
                IsJumped = false;
                Debug.Log($"_movementModel.IsGrounded =  {IsGrounded}");
              
                return true;
            }
            else
            {
               
                _isGrounded = false;
                OnGroundAction?.Invoke();
                Debug.Log($"_movementModel.IsGrounded =  {IsGrounded}");
                //_animator.SetBool("Jump", false);
                return false; 
            }

        }

        public override void Dash()
        {
            Debug.Log("Dash");
            //_animator.s
            // GameController.Instance.RunCoroutine(AnimationControlRoutine());
            _rb.AddForce(new Vector3(0f, 0f, 0f) + _rb.gameObject.transform.forward * 5f, ForceMode.Impulse);
        }

        public override void LookAtTarget(Transform target)
        {
            //_rb.gameObject.transform.LookAt(target,_rb.transform.up);
            var distance = target.position - _rb.transform.position;
            float targetAngle = Mathf.Atan2(distance.x, distance.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(_rb.transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            _rb.transform.rotation = Quaternion.Euler(0f, angle, 0f);

        }

        public override void MovePlayer(Vector3 direction, float speed)
        {

        }

        private IEnumerator AnimationControlRoutine()
        {
            _dash = true;
            RootController.Instance.RunCoroutine(StartAnimation());
            while (_dash)
            {
                _animator.SetFloat("Movement", 0.5f);
                yield return null;
            }
        }

        private IEnumerator StartAnimation()
        {
            yield return new WaitForSeconds(0.5f);
            _dash = false;
        }

        public override void DashToDirection(Vector3 direction, float force)
        {

        }
    }
}
