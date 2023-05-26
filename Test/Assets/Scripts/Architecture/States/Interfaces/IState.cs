namespace Assets.Scripts.Architecture
{
    public interface IState : IExitableState
    {
        void Enter();
    }
}