using Assets.Scripts.Runtime.Controllers;
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
        [SerializeField] protected PlayerView playerPrefab;
        [SerializeField] protected InputTypeBase playerInputType;
        [SerializeField] protected InventoryDTO playerInventoryData;
        public PlayerView SpawnedPlayerViewObject { get; private set; }
        
        public PlayerView PlayerViewPrefab => playerPrefab;
        public PlayerView SpawnPlayerViewObject()
        {
            SpawnedPlayerViewObject = Instantiate<PlayerView>(playerPrefab);
            return SpawnedPlayerViewObject;
        }
        public abstract MovementModel BuildMovementModel(Rigidbody rigidbody);
        public abstract InputTypeBase BuildInputType();
        public abstract InventoryManager GetInventoryManager();
        //public InventoryDTO GetInventoryDTO()
        //{
        //    return playerInventoryData;
        //} 
    }
}

