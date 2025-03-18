using System;
using System.Collections.Generic;
using Core.StateMachine;

namespace Menu
{
    public class UiStateMachine : IStateMachine
    {
        private readonly Dictionary<Type, AState> _states = new();
        private AState _currentAState;

        public void RegisterState(AState state) => _states.Add(state.GetType(), state);

        public void Switch(Type state)
        {
            if(!_states.ContainsKey(state))
                return;
            
            _currentAState?.Exit();
            _currentAState = _states[state];
            _currentAState?.Enter();
        }
    }
}