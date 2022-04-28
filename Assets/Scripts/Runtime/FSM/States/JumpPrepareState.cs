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
    public class JumpPrepareState : StateBase

    {
        private MovementModel _movementModel;
        private InputTypeBase _playerInput;
        private CombatManager _combatManager;
        private bool attack;
        private bool _canAttack;
        private Rigidbody rigidbody1;
        private bool _jumped;

        public JumpPrepareState(MovementModel movementModel, CombatManager combatManager)
        {
            _movementModel = movementModel;
            _combatManager = combatManager;
        }


        public override void OnStateEnter()
        {

            
            _movementModel.Jump(320f);
            _combatManager.OnAttack += HandleAttack;
        }

        public override void OnStateExit()
        {
            _combatManager.OnAttack -= HandleAttack;
        }

        public override void OnStateFixedUpdate()
        {
            Debug.Log($"_movementModel.IsGrounded ==== {_movementModel.IsGrounded}");
            Debug.Log($"_movementModel.Velocity ==== {_movementModel}");
            if (attack)
            {
                attack = false;
                _stateMachine.ChangeState("AttackInJump");
            }
            if (!_movementModel.IsGrounded)
                _stateMachine.ChangeState("Jump");

            if (_movementModel.IsGrounded)
            {
                _stateMachine.ChangeState("Walk");
            }
        }

        public override void OnStateLateUpdate()
        {
            
        }
        private void HandleAttack(int a)
        {


            Debug.Log($"ATTACK IN JUMP");

            attack = true;
        }

        public override void OnStateUpdate()
        {
            
        }
    }
}
