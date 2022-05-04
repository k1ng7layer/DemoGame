using Assets.Scripts.Runtime.Controllers;
using Assets.Scripts.Runtime.Controllers.Interactions;
using Assets.Scripts.Runtime.Inventory;
using Assets.Scripts.Runtime.Models;
using Assets.Scripts.Runtime.Views;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Scripts.Runtime.Configs
{
    public abstract class PlayerConfig : ScriptableObject
    {
        [Header("Player Prefab Parameters")]
        [SerializeField] protected PlayerView playerPrefab;
        [field: SerializeField] protected GameObject defaultWeaponParentObject => playerPrefab.gameObject.GetComponentInChildren<DefaultWeaponParent>().gameObject;
        [field: SerializeField] protected GameObject armedWeaponParentObject => playerPrefab.gameObject.GetComponentInChildren<ArmedWeaponParent>().gameObject;

        [Header("Player Input Parameters")]
        [SerializeField] protected InputTypeBase playerInputType;

        [Header("Player Inventory Parameters")]
        [SerializeField] protected InventoryDTO playerInventoryData;

        [Header("Player Initial Stats")]
        [SerializeField] private float _initialHP;

        [Header("Combat presets")]
        [SerializeField] private LayerMask _targetLayer;
        public LayerMask TargetLayers => _targetLayer;
        public float InitialHp => _initialHP;
        public PlayerView SpawnedPlayerViewObject { get; private set; }
        
        public PlayerView PlayerViewPrefab => playerPrefab;
        public PlayerView SpawnPlayerViewObject()
        {
            SpawnedPlayerViewObject = Instantiate<PlayerView>(playerPrefab);
            return SpawnedPlayerViewObject;
        }
        public abstract MovementModel BuildMovementModel(Rigidbody rigidbody);
        public abstract InputTypeBase BuildInputType();
        public abstract InventoryManagerBase GetInventoryManager();
        public abstract InteractionController GetInteractionController();
        
    }
}

        


