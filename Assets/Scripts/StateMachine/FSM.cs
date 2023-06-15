using System;
using System.Collections.Generic;
using UnityEngine;


namespace StateMachine
{
    /// <summary>
    /// 状态枚举
    /// </summary>
    public enum StateType
    {
        Idle,
        Patrol,
        Chase,
        React,
        Attack
    }

    /// <summary>
    /// 状态机类
    /// </summary>
    public class FSM : MonoBehaviour
    {
        public Parameter _Parameter = new Parameter();

        private IState _currentState;

        private Dictionary<StateType, IState> _states = new Dictionary<StateType, IState>();


        private void Start()
        {
            _states.Add(StateType.Idle, new IdleState(this));
            _states.Add(StateType.Chase, new ChaseState(this));
            _states.Add(StateType.Patrol, new PatrolState(this));
            _states.Add(StateType.React, new ReactState(this));
            _states.Add(StateType.Attack, new AttackState(this));
            //设置初始状态
            TransitionState(StateType.Idle);
            _Parameter._Animator = GetComponent<Animator>();
        }

        private void Update()
        {
            _currentState.OnUpdate();
        }

        /// <summary>
        /// AI朝向
        /// </summary>
        /// <param name="target"></param>
        public void FlipTo(Transform target)
        {
            if (target != null)
            {
                if (transform.position.x > target.position.x)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                else if (transform.position.x < target.position.x)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
            }
        }

        /// <summary>
        /// 转换状态
        /// </summary>
        /// <param name="type"></param>
        public void TransitionState(StateType type)
        {
            if (_currentState != null)
            {
                _currentState.OnExit();
                _currentState = _states[type];
                _currentState.OnEnter();
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _Parameter.target = other.transform;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            WheelJoint2D.Destroy(this);
        }
    }
}