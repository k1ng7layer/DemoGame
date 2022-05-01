using Assets.Scripts.Runtime.Configs;
using Assets.Scripts.Runtime.Configs.Inventory;
using Assets.Scripts.Runtime.Controllers;
using Assets.Scripts.Runtime.Controllers.Combat;
using Assets.Scripts.Runtime.Inventory;
using Assets.Scripts.Runtime.Views.UIViews;
using Assets.Scripts.Runtime.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Models.Combat
{
    public class RangedCombatModel : CombatModel
    {
        private InventoryManagerBase _inventoryManager;
        private Transform _itemViewOnPlayersBack;
        private Transform _defaultWeaponParent;
        private Transform _armedWeaponParent;
        private Transform _currentHandledWeaponInstance;
        public RangedCombatModel(InventoryManagerBase inventoryManager, Transform playerTransform, WeaponCombatModel weaponCombatModel, LayerMask targetLayer):base(weaponCombatModel, targetLayer)
        {
            _inventoryManager = inventoryManager;
            _defaultWeaponParent = playerTransform.GetComponentInChildren<DefaultWeaponParent>().transform;
            _armedWeaponParent = playerTransform.GetComponentInChildren<ArmedWeaponParent>().transform;
            _itemViewOnPlayersBack = weaponCombatModel.WeaponGameObject.transform;


        }

        public void InitialWeaponAttach(Transform transform)
        {
            _itemViewOnPlayersBack = transform;
        }
        public override void DrawWeapon()
        {
            if (_currentHandledWeaponInstance == null)
            {
                var data = WeaponPositionsHandler.GetWeaponData(CharacterType.NORMAL_HUMAN, WeaponType.SPEAR);
                var weaponView = _itemViewOnPlayersBack.GetComponent<WeaponView>();
                var weapon = GameObjectFactory.InstantiateObject<WeaponView>(weaponView, _armedWeaponParent);
                _currentHandledWeaponInstance = weapon.transform;
                var rb = _currentHandledWeaponInstance.GetOrCreateComponent<Rigidbody>();
                rb.isKinematic = false;
                rb.useGravity = false;
                //_currentHandledWeaponInstance.GetComponent<Rigidbody>().isKinematic = false;
                _currentHandledWeaponInstance.transform.localPosition = data.ArmedPosition;
                _currentHandledWeaponInstance.transform.localRotation = Quaternion.Euler(data.ArmedRotation);
                _currentHandledWeaponInstance.transform.localScale = data.ArmedScale;
            }
        }

        public override void HideWeapon()
        {
            
        }

        public override void OnInterruptAttack()
        {
            
        }

        public override void PerformAttack(Transform target)
        {
            if (target != null)
            {
                if (_currentHandledWeaponInstance == null)
                {
                    DrawWeapon();
                }
                ThrowWeapon(_currentHandledWeaponInstance, target);
            }
        }
        private void ThrowWeapon(Transform itemView, Transform target)
        {

            itemView.transform.SetParent(null);
            //itemView.inAction = true;
            var targetDirection = target.position + new Vector3(0f, 1f, 0f) - itemView.transform.position;
            itemView.transform.up = targetDirection;
            itemView.GetComponent<Rigidbody>().AddForce(itemView.transform.up * 10f, ForceMode.Impulse);
            GameObject.Destroy(itemView.gameObject, 3f);
            _currentHandledWeaponInstance = null;
        }

      

        public override void PerformAttack(AttackType attackType)
        {
            
        }

        public override void PerformAttack(AttackType attackType, Transform target)
        {
            if (target != null)
            {
                if (_currentHandledWeaponInstance == null)
                {
                    DrawWeapon();
                }
                ThrowWeapon(_currentHandledWeaponInstance, target);
            }
        }
    }
}
