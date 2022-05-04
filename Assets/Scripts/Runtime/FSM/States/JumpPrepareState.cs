using Assets.Scripts.Runtime.Controllers;
using Assets.Scripts.Runtime.Controllers.Combat;
using Assets.Scripts.Runtime.Models;
using System;
using System.Collections;
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
            _combatManager.OnAttack += HandleAttack;
            RootController.Instance.RunCoroutine(StuckAvoidRoutine());
            //if (_movementModel.IsGrounded)
            //{
            if (!_jumped)
            {
                _movementModel.Jump(260f);
                _jumped = true;
                Debug.Log($"FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF");
                _animator.SetTrigger("Jump");
            }
           
            //}
             
           
        }

        public override void OnStateExit()
        {
            _jumped = false;
            _combatManager.OnAttack -= HandleAttack;
            RootController.Instance.StopMyCoroutine(StuckAvoidRoutine());
        }

        public override void OnStateFixedUpdate()
        {
            Debug.Log($"_movementModel.IsGrounded ==== {_movementModel.IsGrounded}");
            //Debug.Log($"_movementModel.Velocity ==== {_movementModel}");
            Debug.Log($"UPDATE JUMPINGSTATE, velocity = {_movementModel.Velocity}");
            if (attack)
            {
                attack = false;
                _stateMachine.ChangeState("AttackInJump");
            }
            if (!_movementModel.IsGrounded)
                _stateMachine.ChangeState("Jump");

        }

        public override void OnStateLateUpdate()
        {
            
        }
        private IEnumerator StuckAvoidRoutine()
        {
            yield return new WaitForSeconds(1f);
            _stateMachine.ChangeState("Walk");
        }
        private void HandleAttack(int a)
        {


            Debug.Log($"ATTACK IN JUMP");

            attack = true;
        }

        public override void OnStateUpdate()
        {
       

            //if (_movementModel.IsGrounded)
            //{
            //    _stateMachine.ChangeState("Walk");
            //}
        }
    }
}
