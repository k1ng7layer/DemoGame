using Assets.Scripts.Runtime.Controllers;
using Assets.Scripts.Runtime.Views;
using System.Collections;
using UnityEngine;

namespace AIBehaviour
{
    public class LookingForTargetNode:Node
    {
        private Transform _transform;
        private float _checkRadius;
        private LayerMask _layer;
        private Transform _target;
        private bool _checkIsRunnig = false;

        private Animator _animator;
        public LookingForTargetNode(Animator animator,Transform transform, float checkRadius)
        {
            _animator = animator;
            _transform = transform;
            _layer = LayerMask.GetMask("Player");
            _checkRadius = checkRadius;
            
        }

        public override NodeState Evaluate()
        {
         

         
            
        
            var trget = parent.parent.GetData("target");
         
            if (_target == null)
            {
                RootController.Instance.RunCoroutine(CheckForTargetCoroutine());
                
                return NodeState.FAILURE;
            }
            else
            {
                
                RootController.Instance.StopMyCoroutine(CheckForTargetCoroutine());
                _checkIsRunnig = false;
                parent.parent.ClearData("target");
                parent.parent.SetData("target", new NodeData(_target));
                Handler.InvokeTargetLock(_target);
                
                return NodeState.SUCCESS;
            }
        }
        private IEnumerator CheckForTargetCoroutine()
        {
            yield return new WaitForSeconds(3f);
            _checkIsRunnig = true;
            CheckForTarget();
        }
        private void CheckForTarget()
        {
            if (Time.frameCount % 30 == 0)
            {
                var targets = Physics.OverlapSphere(_transform.position, _checkRadius, _layer);
                if (targets != null)
                {
                    foreach (var target in targets)
                    {
                        //Debug.Log("GGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGG");
                        if (target.gameObject.TryGetComponent<PlayerView>(out PlayerView view))
                        {
                            if (view.IsPlayer)
                            {
                                _target = view.transform;
                                break;
                            }
                        }
                    }
                }
            }
           
        }
               
            


                     
                        
    }
                
                
                


            
}
