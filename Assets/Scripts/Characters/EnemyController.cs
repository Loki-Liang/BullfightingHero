using System;
using System.Collections;
using CharacterStats.MonoBehavior;
using StateMachine.FSMSystem;
using Tools;
using UnityEngine;
using UnityEngine.AI;

namespace Characters
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyController : Singleton<EnemyController>
    {
        public AttackInfo _AttackInfo;

        /// <summary>
        /// 状态机系统
        /// </summary>
        private FSMSystem _fsmSystem;

        public float sightRadius;

        private GameObject _attackTarget;

        private Animator _animator;

        private NavMeshAgent _navMeshAgent;


        protected override void Awake()
        {
            base.Awake();
            _animator = GetComponent<Animator>();
            _attackTarget = GameObject.FindGameObjectWithTag("Player");
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }


        private void OnEnable()
        {
            // InitFSMSystem();
        }

        private void Update()
        {
            _fsmSystem.Update(this.gameObject);
            Debug.Log("找到player了吗" + FoundPlayer().ToString());
            if (FoundPlayer())
            {
                StartCoroutine(MoveToAttackTarget());
            }

            
        }


        private void InitFSMSystem()
        {
            _fsmSystem = new FSMSystem();
            FSMState patrolState = new PatrolState(_fsmSystem);
            patrolState.AddTransition(
                StateMachine.FSMSystem.Transition.SeePlayer, CurrentState.Chase);

            FSMState chaseState = new ChaseState(_fsmSystem);
            chaseState.AddTransition(
                StateMachine.FSMSystem.Transition.LostPlayer, CurrentState.Patrol);

            _fsmSystem.AddState(patrolState);
            _fsmSystem.AddState(chaseState);
        }

        bool FoundPlayer()
        {
            var colliders = Physics.OverlapSphere(transform.position, sightRadius);
            foreach (var item in colliders)
            {
                if (_attackTarget.CompareTag("Player"))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 移动到攻击目标协程
        /// </summary>
        /// <returns></returns>
        IEnumerator MoveToAttackTarget()
        {

            
            
            while (Vector3.Distance(_attackTarget.transform.position, transform.position) > 1)
            {
                _navMeshAgent.destination = _attackTarget.transform.position;
                _animator.SetTrigger("Attack");
                yield return null;
            }

            _navMeshAgent.isStopped = true;

            if (_AttackInfo.LastAttackTime < 0)
            {
                _animator.SetTrigger("Attack");
                _AttackInfo.LastAttackTime = _AttackInfo.AttackTime;
            }

            yield break;
        }

        /// <summary>
        /// 获取到最近的玩家
        /// </summary>
        /// <returns></returns>
        public Transform OnGetPlayer()
        {
            float distance_min = 100; //最近玩家距离
            float distance = 0; //当前距离
            Transform targetTransform = null;

            var player = GameObject.FindGameObjectsWithTag("Player");
            for (int i = 0; i < player.Length; i++)
            {
                distance = Vector3.Distance(transform.position, player[i].transform.position);
                if (distance < distance_min)
                {
                    distance_min = distance;
                    targetTransform = player[i].transform;
                }
            }

            return targetTransform;
        }
    }
}