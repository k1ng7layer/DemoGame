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
    public class JumpingState : StateBase
    {
        private MovementModel _movementModel;
        private InputTypeBase _playerInput;
        private CombatManager _combatManager;
        private bool attack;
        private bool _canAttack;
        private Rigidbody rigidbody1;
        private bool _jumped;
        private bool _isGrounded;
        
        public JumpingState(MovementModel movementModel, InputTypeBase input, CombatManager combatManager, Rigidbody rigidbody)
        {
            _movementModel = movementModel;
            _playerInput = input;
            _combatManager = combatManager;
            rigidbody1 = rigidbody;
        }
            



        private void HandleOnAirState()
        {
            Debug.Log("CAN ATTACK");
            _canAttack = true;
        }
        public override void OnStateEnter()
        {


            // _playerInput.OnAttack += HandleAttack;
            // _movementModel.OnGroundAction += HandleOnAirState;
            _movementModel.OnGroundAction += HandleOnGround;
            _combatManager.OnAttack += HandleAttack;
              _movementModel.Jump(10f);
            _jumped = true;
        }

        private void HandleOnGround()
        {
            Debug.Log("ON GROUND");
        }
        public override void OnStateExit()
        {
            //_playerInput.OnAttack -= HandleAttack;
            _combatManager.OnAttack -= HandleAttack;
            _movementModel.OnGroundAction -= HandleOnGround;
            //_movementModel.OnGroundAction -= HandleOnAirState;
        }

        public override void OnStateFixedUpdate()
        {
            Debug.Log($"JUMP STATE ISGROUNDED ==== {_movementModel.IsGrounded}");
            //if (_movementModel.IsGrounded)
                _isGrounded = _movementModel.IsGrounded;
                //_stateMachine.ChangeState("Walk");
                //if (rigidbody1.velocity.y <= 0.5&& rigidbody1.velocity.y >= 0)
                //{
                //    _stateMachine.ChangeState("Walk");
                //}

        }

        public override void OnStateLateUpdate()
        {
            
        }

        public override void OnStateUpdate()
        {
           // Debug.Log($"_movementModel.Velocity ==== {rigidbody1.velocity}");

            if (attack)
            {
                attack = false;
                _stateMachine.ChangeState("AttackInJump");
            }

            if (_movementModel.IsGrounded)
            {
                _stateMachine.ChangeState("Walk");
            }

        }



        private void HandleAttack(int a)
        {

            
            Debug.Log($"ATTACK IN JUMP");
         
            attack = true;
        }
    }
}
          
