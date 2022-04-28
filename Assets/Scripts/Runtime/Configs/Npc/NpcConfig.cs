using AIBehaviour;
using Assets.Scripts.Runtime.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Configs
{
    [CreateAssetMenu(fileName ="New NPC Config", menuName = "Configs/NPC/NPC Config")]
    public class NpcConfig:ScriptableObject
    {
        [SerializeField] private WeaponDTO _weapon;
        [SerializeField] GameObject _hpBarViewPrefab;
        [SerializeField] Canvas _statusCanvasPrefab;
        [SerializeField] private float _maxHp;
        [SerializeField] BehaviourTreeConfig _behaviourTreeConfig;
        [SerializeField] private InventoryDTO _npcInventory;
        [SerializeField] LayerMask _targetLayers;
        public LayerMask TargetLayers => _targetLayers;
        public float MaxHp => _maxHp;
        public InventoryDTO NpcInventory => _npcInventory;
        public BehaviourTreeConfig BehaviourConfig => _behaviourTreeConfig;
        public GameObject HpBarViewPrefab => _hpBarViewPrefab;
        public Canvas StatusCanvasPrefab => _statusCanvasPrefab;
        public WeaponDTO Weapon => _weapon;
    }
}
        
        
