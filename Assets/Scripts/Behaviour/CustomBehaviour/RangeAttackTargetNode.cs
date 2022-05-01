using Assets.Scripts.Runtime.Views;
using UnityEngine;

namespace AIBehaviour
{
    public class RangeAttackTargetNode:Node
    {
        private Transform _transform;
        private Animator _animator;

        public RangeAttackTargetNode(Transform transform, Animator animator)
        {
            this._transform = transform;
            _animator = animator;
          
        }
        public override NodeState Evaluate()
        {
            var target = parent.GetData("target");
            _animator.SetTrigger("Attack");
            Handler.InvokeTargetChasing(target.Target, false);
            _transform.LookAt(target.Target);
            return NodeState.RUNNING;
        }

    }
}
          
         




       



