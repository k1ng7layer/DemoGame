using Assets.Scripts.Runtime.Views;
using UnityEngine;

namespace AIBehaviour
{
    public class RangeAttackTargetNode:Node
    {
        private Transform _transform;
        private float _attackRange;
        float distance;
        private Animator _animator;
        private NpcView ownerView;
        private bool _equiped;
        private bool _throwed;
       
        public RangeAttackTargetNode(Transform transform, Animator animator)
        {
         
            this._transform = transform;
            _animator = animator;
            ownerView = transform.gameObject.GetComponent<NpcView>();
        }
        public override NodeState Evaluate()
        {
            var target = parent.GetData("target");
            _animator.SetBool("Attack1", true);
            //var currentAnimatorState = _animator.GetCurrentAnimatorStateInfo(0);
            //if (_animator.GetCurrentAnimatorStateInfo(0).IsName("ThrowObject"))
            //{
            //    Debug.Log($"normalizedTime = {_animator.GetCurrentAnimatorStateInfo(0).normalizedTime}");
            //    if (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.299999f)
            //    {


            //        if (!_equiped)
            //        {
            //            _equiped = true;
            //            _weaponView = CreateWeaponInstance();
            //            _weaponView.transform.SetParent(null);
            //            ItemView.Destroy(_weaponView.gameObject, 5f);
            //            Debug.Log("spear created");
            //        }
            //        //Debug.Log($"range attack = {_weaponView.transform.localRotation.eulerAngles}");
            //    }
                       

                       




            //    Debug.Log($"normalizedTime = {_animator.GetCurrentAnimatorStateInfo(0).normalizedTime}");
            //    if (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.4f)
            //    {


            //        if (_equiped&& !_throwed)
            //        {

            //            ThrowWeapon(_weaponView, target.Target);
            //            _equiped = false;
            //            _throwed = true;
            //        }


            //        //Debug.Log($"range attack = {_weaponView.transform.localRotation.eulerAngles}");
            //    }
            //    if (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
            //    {


            //        _throwed = false;
            //        //_equiped = false


            //        //Debug.Log($"range attack = {_weaponView.transform.localRotation.eulerAngles}");
            //    }
            //}



              

                //var currentDistance = _weaponView.transform.position - ownerView.transform.position;
               











            
            _transform.LookAt(target.Target);
            return NodeState.RUNNING;
        }





       



    }
}
