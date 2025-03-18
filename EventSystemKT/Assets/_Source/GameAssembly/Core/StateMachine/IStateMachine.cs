using System;

namespace Core.StateMachine
{
    public interface IStateMachine
    {
        void RegisterState(AState state);
        void Switch(Type state);
    }
}