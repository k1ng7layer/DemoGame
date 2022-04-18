using Assets.Scripts.Runtime.Configs;
using Assets.Scripts.Runtime.Controllers.Animation;
using Assets.Scripts.Runtime.Controllers.Combat;
using Assets.Scripts.Runtime.GameActions;
using Assets.Scripts.Runtime.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UISystem.Common;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Runtime.Controllers
{
    public class MainPlayerController : PlayerController
    {
        private Animator _playerAnimator;
        private PlayerView _playerView;
        private GameObject _playerObject;
        private PlayerAnimationManager _playerAnimationManager;
        private PlayerAnimationEventManager _playerAnimationEventManager;
        private CombatManager _combatManager;
        public MainPlayerController(PlayerConfig playerConfig) : base(playerConfig)
        {
            _combatManager = new PlayerCombatManager();
            _input = playerConfig.BuildInputType();
            _playerView = playerConfig.SpawnedPlayerViewObject;
            _movementModel = playerConfig.BuildMovementModel(_playerView.GetComponent<Rigidbody>());
            _inventoryManager = playerConfig.GetInventoryManager();
            _inventoryManager.AttachPlayerObject(_playerView.gameObject);
        }
        public override void InitializeController()
        {
            _playerAnimationEventManager = _playerView.GetComponent<PlayerAnimationEventManager>();
            _playerAnimator = _playerView.GetComponent<Animator>();
            _playerAnimationManager = new PlayerAnimationManager(_playerAnimator, _playerAnimationEventManager);
            SetInventoryActions();
            SetMovementActions();
            SetCombatActions();
        }
        private void SetMovementActions()
        {
            _movementModel.SetAnimator(_playerAnimator);
            _input.OnMovement += MovePlayer;
            _input.OnJump += Jump;
        }
        private void SetInventoryActions()
        {
            _inventoryManager.InitializeController();
            _input.OnDrawWeapon += _inventoryManager.WeaponDrawRequest;
            _inventoryManager.OnWeaponDraw += _playerAnimationManager.DrawOrHideWeapon;
            //Установка вызовов при срабатывании событий анимации
            _playerAnimationEventManager.OnWeaponDraw += _inventoryManager.DrawCurrentWeapon;
            _playerAnimationEventManager.OnWeaponHide += _inventoryManager.HideCurrentWeapon;
            _input.OnInventoryOpen += OpenInventory;
        }
        private void SetCombatActions()
        {
            _input.OnAttack += _combatManager.TryToPerformAttack;
            _combatManager.OnAttack += _playerAnimationManager.EnableAttackAnimation;
        }
        public override void OnDestroyController()
        {
            _input.OnMovement -= MovePlayer;
            _input.OnJump -= Jump;
            _input.OnDrawWeapon -= _playerAnimationManager.DrawOrHideWeapon;
            _playerAnimationEventManager.OnWeaponDraw -= _inventoryManager.DrawCurrentWeapon;
            _playerAnimationEventManager.OnWeaponHide -= _inventoryManager.HideCurrentWeapon;
            _input.OnInventoryOpen -= OpenInventory;
            _input.OnDrawWeapon -= _inventoryManager.WeaponDrawRequest;
            _input.OnAttack -= _combatManager.TryToPerformAttack;
            _combatManager.OnAttack -= _playerAnimationManager.EnableAttackAnimation;
        }
        public override void MovePlayer(Vector3 direction)
        {
            _movementModel.MovePlayer(direction.x, direction.z);
        }
        private void OpenInventory()
        {
            _inventoryManager.OpenInventory();
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
         

          
         
            
           


          
            



        
