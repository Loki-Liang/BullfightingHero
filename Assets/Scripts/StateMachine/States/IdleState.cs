using UnityEngine;

namespace StateMachine
{
    public class IdleState : IState
    {
        private FSM manager;

        private Parameter _parameter;

        private float timer;

        /// <summary>
        /// 构造函数获取Fsm
        /// </summary>
        /// <param name="manager"></param>
        public IdleState(FSM manager)
        {
            this.manager = manager;
            this._parameter = manager._Parameter;
        }

        public void OnEnter()
        {
            _parameter._Animator.Play("Idle");
        }

        public void OnUpdate()
        {
            timer += Time.deltaTime;
            if (timer >= _parameter.idleTime)
            {
                manager.TransitionState(StateType.Patrol);
            }
        }

        public void OnExit()
        {
            timer = 0;
        }
    }
}