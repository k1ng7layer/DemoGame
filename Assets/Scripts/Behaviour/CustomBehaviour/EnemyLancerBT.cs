using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace AIBehaviour
{
    [CreateAssetMenu(fileName = "newBT", menuName = "EnemyAI/BehaviourTree/EnemyLancerBT")]
    public class EnemyLancerBT : BehaviourTreeConfig
    {
        private NavMeshAgent _navMeshAgent;
        private Animator _animator;
        private Rigidbody _rigidBody;
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
                _rigidBody = rigidBody;
            }
            else
            {
                _rigidBody = owner.gameObject.AddComponent<Rigidbody>();
            }


            ChaseTargetNode chaseTargetNode = new ChaseTargetNode(owner, _navMeshAgent, _animator, _rigidBody, 15f);
            LookingForTargetNode lookingForTarget = new LookingForTargetNode(_animator, owner.transform, 20f);
            CheckEnemyInRangeAttackRange checkRange = new CheckEnemyInRangeAttackRange(owner.transform, 15f, _animator);
            RangeAttackTargetNode attackTarget = new RangeAttackTargetNode(owner,_animator);
            TakeDamageNode takeDamageNode = new TakeDamageNode(owner, _animator);
            Sequence checkEnemyInAttack = new Sequence(new List<Node> { checkRange, takeDamageNode, attackTarget });
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