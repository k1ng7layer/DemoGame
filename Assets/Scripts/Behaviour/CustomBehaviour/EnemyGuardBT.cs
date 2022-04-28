
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace AIBehaviour
{
    [CreateAssetMenu(fileName ="newBT", menuName ="EnemyAI/BehaviourTree/EnemyGuardBT")]
    public class EnemyGuardBT: BehaviourTreeConfig
    {
        private NavMeshAgent _navMeshAgent;
        private Animator _animator;
        private Rigidbody _rb;
        protected override Node SetupTree(Transform owner)
        {
        
            if (owner.TryGetComponent<NavMeshAgent>(out NavMeshAgent navMesh))
            {
                _navMeshAgent = navMesh;
            }
            else
            {
                _navMeshAgent = owner.gameObject.AddComponent<NavMeshAgent>();
            }
            if (owner.TryGetComponent<Animator>(out Animator animator))
            {
                _animator = animator;
            }
            else
            {
                _animator = owner.gameObject.AddComponent<Animator>();
            }
            if (owner.TryGetComponent<Rigidbody>(out Rigidbody rigidBody))
            {
                _rb = rigidBody;
            }
            else
            {
                _rb = owner.gameObject.AddComponent<Rigidbody>();
            }

            Debug.Log("34343434");
            ChaseTargetNode chaseTargetNode = new ChaseTargetNode(owner, _navMeshAgent, _animator,_rb);
            LookingForTargetNode lookingForTarget = new LookingForTargetNode(_animator,owner.transform, 20f);
            CheckEnemyInMeleAttackRange checkRange = new CheckEnemyInMeleAttackRange(owner.transform,1.6f,_animator);
            MeleAttackTargetNode attackTarget = new MeleAttackTargetNode(_animator,owner);
            TakeDamageNode takeDamageNode = new TakeDamageNode(owner, _animator);
            Sequence checkEnemyInAttack = new Sequence(new List<Node> {  checkRange, takeDamageNode,  attackTarget });
            Sequence chaseEnemy = new Sequence(new List<Node> { lookingForTarget, chaseTargetNode });
            Selector root = new Selector(new List<Node>
            {
                checkEnemyInAttack,
                chaseEnemy,
            });
            return root;
        }

    }
}
                

                
            
            

           



            
            


            
           


   
