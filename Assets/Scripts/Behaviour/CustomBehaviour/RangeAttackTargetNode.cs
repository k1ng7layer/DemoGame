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
            Vector3 lookPos = target.Target.position - _transform.position;
            //Vector3 trueLook = new Vector3(0f, lookPos.y, 0f);
            lookPos.y = 0;
            Quaternion lookRotation = Quaternion.LookRotation(lookPos);
            _transform.transform.rotation = Quaternion.Slerp(_transform.rotation, lookRotation, Time.deltaTime * 10f);
            //_transform.LookAt(target.Target);
            return NodeState.RUNNING;
        }

    }
}
          
         




       



