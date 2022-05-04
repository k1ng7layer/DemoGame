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
    [CreateAssetMenu(fileName ="new State", menuName = "StateMachineStates/WalkingState")]
    public class WalkingState : StateBase
    {
        private MovementModel _movementModel;
        private InputTypeBase _playerInput;
        private Animator _playerAnimator;
        private CombatManager _combatManager;
        private float x;
        private float y;
        private float z;
        private Vector3 dir;
        public WalkingState(MovementModel movementModel, InputTypeBase playerInput, Animator playerAnimator, CombatManager combatManager)
        {
            _movementModel = movementModel;
            _playerInput = playerInput;
            _playerAnimator = playerAnimator;
            _combatManager = combatManager;
        }
        public override void OnStateEnter()
        {
            _combatManager.OnAttack += HandleAttack;
            //_playerInput.OnAttack += HandleAttack;
            _playerInput.OnMovement += GetDirection;
            _playerInput.OnJump += HandleJump;
        }

        
        public override void OnStateExit() 
        {
            _playerInput.OnMovement -= GetDirection;
            _playerInput.OnJump -= HandleJump;
            //_playerInput.OnAttack -= HandleAttack;
            _combatManager.OnAttack -= HandleAttack;
        }

        public override void OnStateFixedUpdate()
        {
            //Debug.Log($"_movementModel.IsGrounded ==== {_movementModel.IsGrounded}");

            //_playerAnimator.SetTrigger("Move");
            dir = new Vector3(x, y, z);
            MovePlayer(dir,4f);
            //Debug.Log($"dir magnitude = {dir.normalized.magnitude}");
            if (dir.normalized.magnitude > 0f)
                _playerAnimator.SetBool("Attack1", false);
        }


        public override void OnStateLateUpdate()
        {
            
        }
        private void HandleAttack(int a)
        {
            _stateMachine.ChangeState("Attack");
        }
        public override void OnStateUpdate()
        {
            //Debug.Log($"Combat manager can attack = {_combatManager._canAttack}");
            //Debug.Log($"WALK STATE");
        }
        private void GetDirection(Vector3 dir)
        {
            x = dir.x;
            y = dir.y;
            z = dir.z;
        }
        private void MovePlayer(Vector3 direction, float speed)
        {
            _movementModel.MovePlayer(direction.x, direction.z,speed);
        }
        private void HandleJump()
        {
            if(_movementModel.IsGrounded)
            _stateMachine.ChangeState("JumpPrepare");
        }
    }
}
