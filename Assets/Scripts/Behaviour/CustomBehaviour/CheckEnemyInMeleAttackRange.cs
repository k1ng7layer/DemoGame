using Assets.Scripts.Runtime.Views;

using UnityEngine;

namespace AIBehaviour
{
    public class CheckEnemyInMeleAttackRange : Node
    {
        private Transform _transform;
        private float _attackRange;
        private float _distance;
        private Animator _animator;
        private PlayerView _target;

        public CheckEnemyInMeleAttackRange(Transform transform, float attackRange,Animator animator )
        {
            _attackRange = attackRange;
            _transform = transform;
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
                if (_target == null)
                {
                    if (enemy.Target.TryGetComponent<PlayerView>(out PlayerView target))
                    {
                        _target = target;
                    }
                }
                if (enemy.Target != null)
                {
                    _distance = Vector3.Distance(_transform.position, enemy.Target.position);
                }
                if (_distance <= _attackRange*2)
                {
                    Handler.HandleWithdrawWeapon();
                    _animator.SetBool("WeaponWithdraw", true);
                    Debug.Log("GGGGGGGGGGGGGG");
                    if (_target.IsDead)
                    {
                        return NodeState.SUCCESS;
                    }
                    //var currentAnimatorState = _animator.GetCurrentAnimatorStateInfo(0);
                    //if (_animator.GetCurrentAnimatorStateInfo(0).IsName("WithDrawSword"))
                    //{
                    //    Debug.Log($"normalizedTime = {_animator.GetCurrentAnimatorStateInfo(0).normalizedTime}");
                    //    if (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.5f)
                    //    {
                    //        //SceneGameManagerView.Instance.GetAiController(_animator).DrawActiveWeapon();
                    //    }
                    //}
                    //return NodeState.SUCCESS;
                }
                if (_distance <= _attackRange)
                {
                    return NodeState.SUCCESS;
                }
                return NodeState.FAILURE;
            }
        }

    }
}
                
               
                
                   
                

             
                    
                   

               
                
                
            
