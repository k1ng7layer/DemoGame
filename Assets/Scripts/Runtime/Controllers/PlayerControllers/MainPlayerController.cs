using Assets.Scripts.Runtime.Configs;
using Assets.Scripts.Runtime.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Controllers
{
    public class MainPlayerController : PlayerController
    {
        private Animator _playerAnimator;
        private PlayerView _playerView;
        public MainPlayerController(PlayerConfig playerConfig) : base(playerConfig)
        {
            _input = playerConfig.BuildInputType();
            _playerView = playerConfig.SpawnedPlayerViewObject;
            _movementModel = playerConfig.BuildMovementModel(_playerView.GetComponent<Rigidbody>());
            _inventoryManager = playerConfig.GetInventoryManager();
        }

        public override void InitializeController()
        {
            _playerAnimator = _playerView.GetComponent<Animator>();
            _movementModel.SetAnimator(_playerAnimator);
            _input.OnMovement += MovePlayer;
            _input.OnJump += Jump;
            //_inventoryManager.RemoveItem(0);
        }
        public override void OnDestroyController()
        {
            _input.OnMovement -= MovePlayer;
            _input.OnJump -= Jump;
        }
        public override void MovePlayer(Vector3 direction)
        {
            _movementModel.MovePlayer(direction.x, direction.z);
        }
        private void Jump()
        {
            _movementModel.Jump();
        }
        public override void OnUpdateController()
        {
            _input.OnUpdate();
        }
        public override void OnFixedUpdateController()
        {
            if (Time.frameCount % 5 == 0)
            {
                _movementModel.GroundCheck();
            }
        }
           
    }

}
