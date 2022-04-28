
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;

namespace AIBehaviour
{
    [CreateAssetMenu(fileName = "newBT", menuName = "EnemyAI/BehaviourTree/EnemyGuardPatrolBT")]
    public class EnemyPatrolingGuardBT : BehaviourTreeConfig
    {
        private NavMeshAgent _navMeshAgent;
        private Animator _animator;
        private Transform[] _wayPoints;
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
            _wayPoints = owner.GetComponent<PatrolProfile>().WayPoints;
          

            
            ChaseTargetNode chaseTargetNode = new ChaseTargetNode(owner, _navMeshAgent, _animator,_rigidBody);
            LookingForTargetNode lookingForTarget = new LookingForTargetNode(_animator,owner.transform, 20f);
            CheckEnemyInMeleAttackRange checkRange = new CheckEnemyInMeleAttackRange(owner.transform, 1.6f, _animator);
            MeleAttackTargetNode attackTarget = new MeleAttackTargetNode(_animator, owner);
            TakeDamageNode takeDamageNode = new TakeDamageNode(owner, _animator);
            PatrolNode patrolNode = new PatrolNode(owner, _wayPoints, _navMeshAgent,_animator, _rigidBody);
            Sequence parolSequence = new Sequence(new List<Node> {  patrolNode });
            parolSequence.name = "patrol";
            Sequence checkEnemyInAttack = new Sequence(new List<Node> { checkRange, takeDamageNode, attackTarget });
            checkEnemyInAttack.name = "checkEnemyInAttack";
            Sequence chaseEnemy = new Sequence(new List<Node> { lookingForTarget, chaseTargetNode});
            chaseEnemy.name = "chaseEnemy";
            FallingCheckNode fallingCheckNode = new FallingCheckNode(_rigidBody,_animator);
           

            Selector mainSelector = new Selector(new List<Node> 
            {

                checkEnemyInAttack,
                chaseEnemy,
                parolSequence,


            });
             
            Selector root = new Selector(new List<Node>
            {
                new Sequence(new List<Node>
                {
                    fallingCheckNode,
                    mainSelector

                }),
            });

            //Selector root = new Selector(new List<Node>
            //{
                
            //    checkEnemyInAttack,
            //    chaseEnemy,
            //    parolSequence,
            //});
            return root;
        }
               
    }
}




