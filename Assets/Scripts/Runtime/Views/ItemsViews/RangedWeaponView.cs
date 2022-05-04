using Assets.Scripts.Runtime.Controllers.Combat;
using Assets.Scripts.Runtime.Views.UIViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Views.ItemsViews
{
    public class RangedWeaponView : WeaponView
    {
        [SerializeField] private ParticleSystem _particleSystem;
        private List<DamageUnit> _damageUnits = new List<DamageUnit>();
        public void SetDamagePoints(List<DamageUnit> damageUnits)
        {
            _damageUnits = damageUnits;
        }
        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent<PlayerView>(out PlayerView player))
            {
                if (player.CompareTag("Player"))
                {
                    //Debug.Log("RANGED DAMAGE");
                    player.BeginTakeDamage(_damageUnits);
                    Destroy(this.gameObject);
                }
                
            }
        }

        public void Setup()
        {
            _particleSystem.Play();
        }
    }
}
