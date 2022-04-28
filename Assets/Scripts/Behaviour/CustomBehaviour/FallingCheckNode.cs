using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AIBehaviour
{
    public class FallingCheckNode:Node
    {
        private Rigidbody _rigidbody;
        private Animator _animator;
        public FallingCheckNode(Rigidbody rigidbody, Animator animator)
        {
            _rigidbody = rigidbody;
            _animator = animator;
        }
        public override NodeState Evaluate()
        {
            if (_rigidbody.velocity.y <= -2f)
            {
                _animator.SetBool("Falllng", true);
                Quaternion targetRotation = Quaternion.Euler(-90f, _rigidbody.rotation.eulerAngles.y, _rigidbody.rotation.eulerAngles.z);

                //_rigidbody.rotation = Quaternion.Slerp(_rigidbody.rotation, targetRotation, 1);
                _rigidbody.rotation = Quaternion.Slerp(_rigidbody.rotation, targetRotation, 3f);

                return NodeState.FAILURE;
            }
            return NodeState.SUCCESS;
        }
               
           
    }
}
