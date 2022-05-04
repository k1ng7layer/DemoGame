using Assets.Scripts.Runtime.Controllers.Animation;
using Assets.Scripts.Runtime.Controllers.Combat;
using Assets.Scripts.Runtime.Extensions;
using Assets.Scripts.Runtime.Inventory;
using Assets.Scripts.Runtime.Models;
using Assets.Scripts.Runtime.Views;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Runtime.Controllers.AIControllers
{
    public class NpcPresenter:IController
    {
        private NpcView _npcView;
        private AIBehaviour.Tree _behaviourTree;
        private AnimationEventManager _animationEventManager;
        private CombatManager _combatManager;
        public event Action<NpcPresenter> OnDeath;
        private TargetChaseModel _targetChaseModel;
        private Animator _animator;
        public event Action OnDeathNpc;
        private InventoryManagerBase _npcInventoryManager;
        public NpcPresenter(NpcView npcView)
        {
            _npcView = npcView;
            _behaviourTree = _npcView.Config.BehaviourConfig.CreateBehaviourTree(npcView.transform);
            _animator = _npcView.transform.GetOrCreateComponent<Animator>();
            _npcInventoryManager = new NpcInventoryManager(_npcView.Config.Weapon, _npcView.gameObject, _npcView.Config.NpcInventory);
            _combatManager = new NpcCombatManager(_animator, _npcView.Config,_npcInventoryManager,_npcView.transform);
          
        }
            
        private void SetNpcDeath()
        {
            OnDeath?.Invoke(this);
            RootController.Instance.RunCoroutine(PrepareToDie());
        }
            
        private IEnumerator PrepareToDie()
        {
            yield return new WaitForSeconds(5f);
            GameObject.Destroy(_npcView.gameObject);
        }
            
        public void InitializeController()
        {
            _npcView.CreateGraphics();
            var agent = _npcView.GetComponent<NavMeshAgent>();
            var _rb = _npcView.GetOrCreateComponent<Rigidbody>();
            var animator = _npcView.GetOrCreateComponent<Animator>();
            _npcInventoryManager.OnWeaponViewAssign += _combatManager.SetWeapon;
            _npcInventoryManager.InitializeController();
            _targetChaseModel = new NavMeshTargetChaseModel(agent, _rb, animator);
            _animationEventManager = _npcView.GetOrCreateComponent<AnimationEventManager>();
            _animationEventManager.OnStartDealingDamage += _combatManager.HandleAttackBegin;
            _animationEventManager.OnEndDealingDamage += _combatManager.HandleAttackEnd;
            _behaviourTree.Initialize();
            _behaviourTree.OnAttackTarget += _combatManager.PerformAttackRequest;
            _combatManager.OnTakingDamage += _behaviourTree.HandleTakingDamage;
            _behaviourTree.OnMovingToTarget += _targetChaseModel.ChaseTarget;
            _npcView.OnTakeDamage += _combatManager.HandleIncomeDamage;
            _behaviourTree.OnTargetLocked += _combatManager.SetTarget;
            _combatManager.OnHealthChanged += _npcView.HpBar.SetHealth;
            _combatManager.OnDeath += SetNpcDeath;
            _animationEventManager.OnWeaponDraw += _combatManager.DrawWeapon;
            _animationEventManager.OnWeaponHide += _npcInventoryManager.HideCurrentWeapon;
        }
        private void HandleDestroyPlayerAfterDeath()
        {
            GameObject.Destroy(_npcView.gameObject);
        }
        public void OnDestroyController()
        {
            _behaviourTree.OnAttackTarget -= _combatManager.PerformAttackRequest;
            _behaviourTree.OnMovingToTarget -= _targetChaseModel.ChaseTarget;
            _npcView.TakeDamageAction -= _behaviourTree.HandleTakingDamage;
            _npcView.OnTakeDamage -= _combatManager.HandleIncomeDamage;
            _combatManager.OnHealthChanged -= _npcView.HpBar.SetHealth;
            _behaviourTree.OnDestroy();
            _combatManager.OnDeath -= SetNpcDeath;
            _animationEventManager.OnWeaponDraw -= _npcInventoryManager.DrawCurrentWeapon;
            _animationEventManager.OnStartDealingDamage -= _combatManager.HandleAttackBegin;
            _animationEventManager.OnEndDealingDamage -= _combatManager.HandleAttackEnd;
            _animationEventManager.OnWeaponHide -= _npcInventoryManager.HideCurrentWeapon;
            _npcInventoryManager.OnWeaponViewAssign -= _combatManager.SetWeapon;
            _animationEventManager.OnWeaponDraw -= _combatManager.DrawWeapon;
            _behaviourTree.OnTargetLocked -= _combatManager.SetTarget;
        }
        public void OnUpdateController()
        {
            _behaviourTree.Update();
            _targetChaseModel.UpdateModel();
        }
        public void OnFixedUpdateController()
        {

        }
        public void OnDisableController()
        {
            
        }
        public void OnLateUpdateController()
        {
           
        }
    }
}
            
        
            
            
            
            
       

            
            


           


           
            


            



      
