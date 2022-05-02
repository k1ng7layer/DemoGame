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
        private Animator _animator;
        private bool attack;
        private bool _canAttack;
        private Rigidbody rigidbody1;
        private bool _jumped;

        public JumpPrepareState(MovementModel movementModel, CombatManager combatManager, Animator animator)
        {
            _movementModel = movementModel;
            _combatManager = combatManager;
            _animator = animator;
        }


        public override void OnStateEnter()
        {

            if (_movementModel.IsGrounded)
            {
                _movementModel.Jump(320f);
                _animator.SetBool("Jump", true);
            }
             
            _combatManager.OnAttack += HandleAttack;
        }

        public override void OnStateExit()
        {
            _combatManager.OnAttack -= HandleAttack;
        }

        public override void OnStateFixedUpdate()
        {
            Debug.Log($"_movementModel.IsGrounded ==== {_movementModel.IsGrounded}");
            //Debug.Log($"_movementModel.Velocity ==== {_movementModel}");
      
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
    }
}
