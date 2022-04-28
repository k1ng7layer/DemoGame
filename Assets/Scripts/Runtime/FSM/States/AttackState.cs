using Assets.Scripts.Runtime.Controllers.Animation;
using Assets.Scripts.Runtime.Controllers.Combat;
using Assets.Scripts.Runtime.Models;
using Assets.Scripts.Runtime.Views.UIViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.FSM
{
    public class AttackState : StateBase
    {
        private float x;
        private float y;
        private float z;
        private Vector3 dir;
        private InputTypeBase _playerInput;
        private Animator _playerAnimator;
        private WeaponView _currentWeapon;
        private CombatManager _combatManager;
        private PlayerAnimationEventManager _layerAnimationEventManager;
        private MovementModel _movementModel;
        public AttackState(InputTypeBase playerInput, Animator playerAnimator, CombatManager combatManager, PlayerAnimationEventManager playerAnimationEvent, MovementModel movement)
        {
            _playerAnimator = playerAnimator;
            _combatManager = combatManager;
            _layerAnimationEventManager = playerAnimationEvent;
            _movementModel = movement;
            _playerInput = playerInput;
        }

        public override void OnStateEnter()
        {
            //_combatManager.OnAttack += HandleAttack;
            _layerAnimationEventManager.OnEndDealingDamage += HandleAttackEnd;
            _playerInput.OnMovement += GetDirection;
            _playerInput.OnJump += HandleJump;
            _playerAnimator.SetTrigger("Attack");
        }
        private void HandleJump()
        {
            _stateMachine.ChangeState("JumpPrepare");
        }

        private void HandleAttack(int a)
        {
            _playerAnimator.SetTrigger("Attack");
        }
        private void HandleAttackEnd()
        {
            Debug.Log("current attack state end");
            _stateMachine.ChangeState("Walk");
        }
        public override void OnStateExit()
        {
            _playerInput.OnJump -= HandleJump;
            _layerAnimationEventManager.OnEndDealingDamage -= HandleAttackEnd;
            _playerInput.OnMovement -= GetDirection;
            //_combatManager.OnAttack -= HandleAttack;
        }

        public override void OnStateFixedUpdate()
        {
            //_playerAnimator.SetTrigger("Move");
            dir = new Vector3(x, y, z);
            MovePlayer(dir, 4f);
            Debug.Log($"dir magnitude = {dir.normalized.magnitude}");
            if (dir.normalized.magnitude > 0f)
                _playerAnimator.SetBool("Attack1", false);
        }

        public override void OnStateLateUpdate()
        {
            
        }

        public override void OnStateUpdate()
        {
            
        }

        private void GetDirection(Vector3 dir)
        {
            x = dir.x;
            y = dir.y;
            z = dir.z;
        }

        private void MovePlayer(Vector3 direction, float speed)
        {
            _movementModel.MovePlayer(direction.x, direction.z, speed);
        }

    }
}
