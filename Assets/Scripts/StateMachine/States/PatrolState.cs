namespace StateMachine
{
    public class PatrolState : IState
    {
        private FSM manager;

        private Parameter _parameter;

        public PatrolState(FSM manager)
        {
            this.manager = manager;
            this._parameter = manager._Parameter;
        }

        public void OnEnter()
        {
            throw new System.NotImplementedException();
        }

        public void OnUpdate()
        {
            throw new System.NotImplementedException();
        }

        public void OnExit()
        {
            throw new System.NotImplementedException();
        }
    }
}