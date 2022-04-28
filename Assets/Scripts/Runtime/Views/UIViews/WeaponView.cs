﻿using Assets.Scripts.Runtime.Controllers.Combat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Views.UIViews
{
    public class WeaponView:MonoBehaviour
    {
        
        private LayerMask _hitLayer;
        [SerializeField] private List<IHittable> _hittedObjects;
        [SerializeField] private float _length;
        private List<DamageUnit> _damageUnits;
        
        private float _damage;
        private bool _dealingDamage;
        private void Start()
        {
            _hittedObjects = new List<IHittable>();
        }
        public void StartDealDamage(List<DamageUnit> damageUnits, AttackType attackType)
        {
            _damageUnits = damageUnits;
            _dealingDamage = true;
        }

        public void StartDealDamage(List<DamageUnit> damageUnits, AttackType attackType, LayerMask targetLayer)
        {
            _damageUnits = damageUnits;
            _dealingDamage = true;
            _hitLayer = targetLayer;
        }




        public void EndDealDamage()
        {
            foreach (var obj in _hittedObjects)
            {
                obj.EndTakingDamage();
            }
            _dealingDamage = false;
            _hittedObjects.Clear();
        }

        private void Update()
        {
            //Debug.Log($"position of weapon ={transform.position} ");
            Debug.DrawRay(transform.position, -transform.forward* _length, Color.yellow);
            Debug.Log($"AAAAAAAAAAAAA");
            if (_dealingDamage)
            {
                Debug.DrawRay(transform.position, -transform.forward * _length, Color.yellow);
                Debug.Log($"AAAAAAAAAAAAA");
                if (Physics.Raycast(transform.position, -transform.forward, out RaycastHit raycastHit, _length, _hitLayer))
                {
                    Debug.Log($"AAAAAAAAAAAAA ={raycastHit.transform.gameObject}");
                    if (raycastHit.transform.TryGetComponent<IHittable>(out IHittable target) && _hittedObjects.Contains(target) == false)
                    {
                        _hittedObjects.Add(target);
                        target.BeginTakeDamage(_damageUnits);
                        _dealingDamage = false;
                    }

                }
            }

        }

        private void FixedUpdate()
        {
        
        }


    }
}
