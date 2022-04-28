
using Assets.Scripts.Runtime.Views;
using UnityEngine;

namespace AIBehaviour
{
    public class CheckEnemyInRangeAttackRange:Node
    {
        private Transform _transform;
        private float _attackRange;
        float distance;
        private Animator _animator;
        private NpcView ownerView;
        public CheckEnemyInRangeAttackRange(Transform transform, float attackRange, Animator animator)
        {
            _attackRange = attackRange;
            this._transform = transform;
            _animator = animator;
            ownerView = transform.gameObject.GetComponent<NpcView>();
        }
        public override NodeState Evaluate()
        {

            var enemy = parent.GetData("target");
            //Debug.Log($"enemyenemyenemy{enemy}");
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
                //if (distance <= _attackRange * 2)
                //{
                //    _animator.SetBool("WeaponWithdraw", true);
                //    var currentAnimatorState = _animator.GetCurrentAnimatorStateInfo(0);
                //    if (_animator.GetCurrentAnimatorStateInfo(0).IsName("WithDrawSword"))
                //    {
                //        Debug.Log($"normalizedTime = {_animator.GetCurrentAnimatorStateInfo(0).normalizedTime}");
                //        if (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.5f)
                //        {
                //            SceneGameManagerView.Instance.GetAiController(_animator).GetWeapon();
                //        }
                //    }
                //    //return NodeState.SUCCESS;
                //}
                if (distance <= _attackRange)
                {
                  
                    return NodeState.SUCCESS;
                }
                return NodeState.FAILURE;
            }
        }

    }
}


