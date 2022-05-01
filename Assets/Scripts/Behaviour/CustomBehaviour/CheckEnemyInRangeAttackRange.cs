
using Assets.Scripts.Runtime.Views;
using UnityEngine;

namespace AIBehaviour
{
    public class CheckEnemyInRangeAttackRange:Node
    {
        private Transform _transform;
        private float _attackRange;
        private float distance;
        private Animator _animator;
        
        public CheckEnemyInRangeAttackRange(Transform transform, float attackRange, Animator animator)
        {
            _attackRange = attackRange;
            this._transform = transform;
            _animator = animator;
        }
          
        public override NodeState Evaluate()
        {

            var enemy = parent.GetData("target");
            
            if (enemy == null)
            {
                return NodeState.FAILURE;
            }
            else
            {
                if (enemy.Target != null)
                {
                    distance = Vector3.Distance(_transform.position, enemy.Target.position);
                }
           
                if (distance <= _attackRange)
                {
                    return NodeState.SUCCESS;
                }
                return NodeState.FAILURE;

            }
                  
        }

    }
}


