﻿using Assets.Scripts.Runtime.Controllers;
using Assets.Scripts.Runtime.Controllers.Combat;
using Assets.Scripts.Runtime.Views.UIViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Views
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Animator))]
    public class PlayerView:MonoBehaviour, IHittable
    {
        public event Action<List<DamageUnit>, bool> OnTakeDamage;
        public event Action<bool> TakeDamageAction;
        public HpBarView HpBar { get; private set; }

        [SerializeField] bool _isPlayer;
        public bool IsPlayer => _isPlayer;
        public bool IsDead { get; private set; }

        private void Start()
        {
            if (_isPlayer)
            {
               
                //var healthbar = UIController.PlayerIndicatorsCanvas.GetComponentInChildren<HpBarView>();
                //HpBar = healthbar;

               
            }
        }

        public void CreateUI()
        {
            var healthbar = UIController.PlayerIndicatorsCanvas.GetComponentInChildren<HpBarView>();
            HpBar = healthbar;
            HpBar.Initialize();
        }

        public void BeginTakeDamage(List<DamageUnit> damageUnits)
        {
            Debug.Log($"TAKING DAMAGE! {this}");
            OnTakeDamage?.Invoke(damageUnits, true);
            TakeDamageAction?.Invoke(true);
        }

        public void HandleDeath()
        {
            IsDead = true;
        }
   
        public void EndTakingDamage()
        {
            List<DamageUnit> damageUnits = default;
            OnTakeDamage?.Invoke(damageUnits, false);
        }
    }
}
       
      


