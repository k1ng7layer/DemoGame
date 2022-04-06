using Assets.Scripts.Runtime.Configs;
using Assets.Scripts.Runtime.Inventory;
using Assets.Scripts.Runtime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Controllers.PlayerControllers
{
    [CreateAssetMenu(fileName ="new player congif", menuName ="Configs/PlayerConfig")]
    public class MainPlayerControllerConfig : PlayerConfig
    {
        public override InputTypeBase BuildInputType()
        {
            return playerInputType;
        }

        public override MovementModel BuildMovementModel(Rigidbody rigidbody)
        {
            //Rigidbody _rb;
            //if(playerPrefab.TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
            //{
            //    _rb = rigidbody;
            //}
            //else
            //{
            //    _rb = playerPrefab.gameObject.AddComponent<Rigidbody>();
            //}
            return new RigidBodyMovementModel(rigidbody);
        }

        public override InventoryManager GetInventoryManager()
        {
            return new InventoryManager(playerInventoryData);
        }
    }
}
