using Assets.Scripts.Runtime.Controllers.Animation;
using Assets.Scripts.Runtime.Controllers.Combat;
using Assets.Scripts.Runtime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.FSM
{
    public class AttackInJumpState : StateBase
    {
        private MovementModel _movement;
        private CombatManager _combatManager;
        private PlayerAnimationEventManager _playerAnimationEventManager;
        private Animator _animator;
        public AttackInJumpState(MovementModel movementModel, CombatManager combatManager, PlayerAnimationEventManager playerAnimationEvent, Animator animator)
        {
            _movement = movementModel;
            _combatManager = combatManager;
            _playerAnimationEventManager = playerAnimationEvent;
            _animator = animator;

        }
        public override void OnStateEnter()
        {
            _combatManager.OnAttack += HandleAttack;
            _playerAnimationEventManager.OnEndDealingDamage += HandleEndOfAttack;
            _animator.SetTrigger("JumpAttack");
            Debug.Log("ATTACK IN JUMP STATE");
        }
        private void HandleAttack(int a)
        {
            //_animator.SetTrigger("JumpAttack");
        }
        public override void OnStateExit()
        {
            _playerAnimationEventManager.OnEndDealingDamage -= HandleEndOfAttack;
            _combatManager.OnAttack -= HandleAttack;
        }

        public override void OnStateFixedUpdate()
        {
            
        }
        
        public override void OnStateLateUpdate()
        {
            
        }
        private void HandleEndOfAttack()
        {
            _stateMachine.ChangeState("Walk");
        }
        public override void OnStateUpdate()
        {
            //if (!_movement.IsGrounded)
            //    _stateMachine.ChangeState("Walk");
        }
    }
}
