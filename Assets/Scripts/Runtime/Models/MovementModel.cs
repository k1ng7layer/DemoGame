using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Models
{
    public abstract class MovementModel
    {
        public bool IsJumped;
        public abstract event Action OnGroundAction;
        protected Animator _animator;
        public abstract bool IsGrounded { get;}
        public abstract Vector3 Velocity { get; protected set; }
        public abstract void MovePlayer(Vector3 direction, float speed);
        public abstract void MovePlayer(float x, float y);
        public abstract void MovePlayer(float x, float y, float speed);
        public abstract void LookAtTarget(Transform target);
        public abstract void Jump(float force);
        public abstract bool GroundCheck();
        public abstract void Dash();
        public abstract void DashToDirection(Vector3 direction, float force);
        public bool IsFalling { get; protected set; }
        public void SetAnimator(Animator animator)
        {
            _animator = animator;
        }
    }
}
