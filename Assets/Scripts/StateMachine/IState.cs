namespace StateMachine
{
    /// <summary>
    /// 状态接口
    /// </summary>
    public interface IState
    {
        void OnEnter();
        
        void OnUpdate();
        
        void OnExit();
    }
}