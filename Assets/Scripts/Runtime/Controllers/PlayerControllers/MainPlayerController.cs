using Assets.Scripts.Runtime.Configs;
using Assets.Scripts.Runtime.Controllers.Animation;
using Assets.Scripts.Runtime.Controllers.Combat;
using Assets.Scripts.Runtime.Controllers.Interactions;
using Assets.Scripts.Runtime.Extensions;
using Assets.Scripts.Runtime.FSM;
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
        private StateMachine _stateMachine;
        private PlayerConfig _config;
        private InteractionController _interactionController;
        public MainPlayerController(PlayerConfig playerConfig) : base(playerConfig)
        {
            _config = playerConfig;
            _input = playerConfig.BuildInputType();
            _playerView = playerConfig.SpawnedPlayerViewObject;
            _playerAnimator = _playerView.GetComponent<Animator>();
            _movementModel = playerConfig.BuildMovementModel(_playerView.GetComponent<Rigidbody>());
            _combatManager = new PlayerCombatManager(_playerAnimator, playerConfig, _inventoryManager);
            _inventoryManager = playerConfig.GetInventoryManager();
            _inventoryManager.AttachPlayerObject(_playerView.gameObject);
            _interactionController = playerConfig.GetInteractionController();
        }
           
          

        public override void InitializeController()
        {

            //_stateMachine.InitializeSateMachine("Walk");


            _playerView.CreateUI();
            _playerView.HpBar.SetMaxHealth(_config.InitialHp);
            _playerAnimationEventManager = _playerView.GetComponent<PlayerAnimationEventManager>();
           
            _playerAnimationManager = new PlayerAnimationManager(_playerAnimator, _playerAnimationEventManager);
            SetInventoryActions();
            SetMovementActions();
            SetCombatActions();


            var states = new Dictionary<string, StateBase>();
            var walkingState = new WalkingState(_movementModel, _input, _playerAnimator, _combatManager);
            var jumpingState = new JumpingState(_movementModel,_input,_combatManager, _playerView.transform.GetOrCreateComponent<Rigidbody>());
            var attackState = new AttackState(_input, _playerAnimator,_combatManager, _playerAnimationEventManager, _movementModel);
            var attackInJumpState = new AttackInJumpState(_movementModel,_combatManager,_playerAnimationEventManager,_playerAnimator);
            var jumpPreapreState = new JumpPrepareState(_movementModel, _combatManager, _playerAnimator);
            states.Add("Walk", walkingState);
            states.Add("Jump", jumpingState);
            states.Add("JumpPrepare", jumpPreapreState);
            states.Add("Attack", attackState);
            states.Add("AttackInJump", attackInJumpState);
            _stateMachine = new StateMachine(states);
            _stateMachine.ChangeState("Walk");
        }
        private void SetMovementActions()
        {
            _movementModel.SetAnimator(_playerAnimator);
        }
        
            
      
        private void SetInventoryActions()
        {
            _inventoryManager.InitializeController();
            _interactionController.InitializeController();
            _input.OnDrawWeapon += _inventoryManager.WeaponDrawRequest;
            _inventoryManager.OnWeaponDrawRequest += _playerAnimationManager.DrawOrHideWeapon;
            //Установка вызовов при срабатывании событий анимации
            _playerAnimationEventManager.OnWeaponDraw += _inventoryManager.DrawCurrentWeapon;
            _playerAnimationEventManager.OnWeaponHide += _inventoryManager.HideCurrentWeapon;
            _input.OnInventoryOpen += OpenInventory;
            _input.OnUseButtonPressed += _interactionController.UseItem;
        }
        private void SetCombatActions()
        {
           
            _inventoryManager.OnWeaponStateChanged += _combatManager.SetWeaponReady;
            _input.OnAttack += _combatManager.PerformAttackRequest;
            _inventoryManager.OnWeaponViewAssign += _combatManager.SetWeapon;
            _playerAnimationEventManager.OnStartDealingDamage += _combatManager.HandleAttackBegin;
            _playerAnimationEventManager.OnEndDealingDamage += _combatManager.HandleAttackEnd;
            _playerView.OnTakeDamage += _combatManager.HandleIncomeDamage;
            _playerView.OnHealthRestore += _combatManager.RestoreHealth;
            _combatManager.OnHealthChanged += _playerView.HpBar.SetHealth;
            _combatManager.OnDeath += _playerView.HandleDeath;
            _combatManager.OnDeath += SetPlayerDeath;
        }
       

        public override void OnDestroyController()
        {
         
           
            _input.OnDrawWeapon -= _inventoryManager.WeaponDrawRequest;
            _playerAnimationEventManager.OnWeaponDraw -= _inventoryManager.DrawCurrentWeapon;
            _playerAnimationEventManager.OnWeaponHide -= _inventoryManager.HideCurrentWeapon;
            _input.OnInventoryOpen -= OpenInventory;
            _input.OnDrawWeapon -= _inventoryManager.WeaponDrawRequest;
            _input.OnAttack -= _combatManager.PerformAttackRequest;
            //_combatManager.OnAttack -= _playerAnimationManager.EnableAttackAnimation;
            _inventoryManager.OnWeaponStateChanged -= _combatManager.SetWeaponReady;
            _inventoryManager.OnWeaponViewAssign -= _combatManager.SetWeapon;
            _playerAnimationEventManager.OnStartDealingDamage -= _combatManager.HandleAttackBegin;
            _playerAnimationEventManager.OnEndDealingDamage -= _combatManager.HandleAttackEnd;
            _playerView.OnTakeDamage -= _combatManager.HandleIncomeDamage;
            _combatManager.OnHealthChanged -= _playerView.HpBar.SetHealth;
            _combatManager.OnDeath -= SetPlayerDeath;
            _combatManager.OnDeath -= _playerView.HandleDeath;
            _playerView.OnHealthRestore -= _combatManager.RestoreHealth;
            _input.OnUseButtonPressed -= _interactionController.UseItem;

        }


        private void OpenInventory()
        {
            _inventoryManager.OpenInventory();
        }
    
        public override void OnUpdateController()
        {
            _input.OnUpdate();
            _stateMachine.UpdateStateMachine();
        }
        public override void OnFixedUpdateController()
        {
            if (Time.frameCount % 5 == 0)
            {
                _movementModel.GroundCheck();
            }
            //if(_movementModel.IsJumped)
                _movementModel.GroundCheck();
            //Debug.Log("AAAAAAAAAAAAAAAA");
            _stateMachine.FixedUpdateStateMachine();
        }
           
    }

}
         

          
         
            
           


          
            



        
