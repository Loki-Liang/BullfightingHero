using UnityEngine;

namespace StateMachine
{
    public class ChaseState : IState
    {
        private FSM manager;

        private Parameter _parameter;

        public ChaseState(FSM manager)
        {
            this.manager = manager;
            _parameter = manager._Parameter;
        }

        public void OnEnter()
        {
            _parameter._Animator.Play("Walk");
        }

        public void OnUpdate()
        {
            manager.FlipTo(_parameter.target);
            if (_parameter.target)
            {
                manager.transform.position = Vector2.MoveTowards(
                    manager.transform.position,
                    _parameter.target.position,
                    _parameter.chaseSpeed * Time.deltaTime);
            }

            if (_parameter.target == null ||
                manager.transform.position.x < _parameter.chasePoint[0].position.x ||
                manager.transform.position.x > _parameter.chasePoint[1].position.x)
            {
                manager.TransitionState(StateType.Idle);
            }
        }

        public void OnExit()
        {
            throw new System.NotImplementedException();
        }
    }
}