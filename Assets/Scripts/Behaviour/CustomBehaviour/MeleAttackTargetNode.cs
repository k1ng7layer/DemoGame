using Assets.Scripts.Runtime.Controllers;
using Assets.Scripts.Runtime.Views;
using System.Collections;
using UnityEngine;

namespace AIBehaviour
{
    public class MeleAttackTargetNode : Node
    {
        private Animator _animator;
        private Transform _nodeOwner;
        private PlayerView _target;
        private bool _takingDamage;
        private bool _canAttack = true;
        public MeleAttackTargetNode(Animator animator, Transform ownerTransform)
        {
            _animator = animator;
            _nodeOwner = ownerTransform;
            //
        }
        internal override void InitializeNode()
        {
            base.InitializeNode();
            Handler.OnTakingDamage += HandleDamage;
        }
        public override NodeState Evaluate()
        {
            var targetData = parent.GetData("target");
            if (_target == null)
            {
                if (targetData.Target.TryGetComponent<PlayerView>(out PlayerView target))
                {
                    _target = target;
                }
            }
            if (_target.IsDead)
            {
                
                _animator.SetBool("WeaponWithdraw", false);
                return NodeState.FAILURE;
            }
            //Debug.Log("ATTACKING TARGET");
            if (_takingDamage == false&& _canAttack)
            {
                _animator.SetTrigger("Attack");
                Handler.InvokeAttackAction();
            }
            else
            {
                _animator.ResetTrigger("Attack");
            }
            Vector3 lookPos = targetData.Target.position - _nodeOwner.position;
            //Vector3 trueLook = new Vector3(0f, lookPos.y, 0f);
            lookPos.y = 0;
            Quaternion lookRotation = Quaternion.LookRotation(lookPos);
            _nodeOwner.transform.rotation = Quaternion.Slerp(_nodeOwner.transform.rotation, lookRotation,Time.deltaTime*10f);
            //_nodeOwner.transform.LookAt(targetData.Target,Vector3.up);
            return NodeState.RUNNING;
        }

        private void HandleDamage(bool val)
        {
           
            _takingDamage = val;
            if (_takingDamage)
            {
                //Debug.Log($"ATAKING DAMAGE NODE = {val}");
                _canAttack = false;
                RootController.Instance.RunCoroutine(AttackDelay());
            }
            
            
        }

        private IEnumerator AttackDelay()
        {
            yield return new WaitForSeconds(3f);
            _canAttack = true;
        }
    }
}
            
               
        
        
        

            
            
           
           
          



