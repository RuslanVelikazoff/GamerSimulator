using System;
using System.Collections.Generic;

namespace FSMScripts
{
    public class Fsm
    {
        private FsmState StateCurrent { get; set; } //Если менять на public, то set сделать private

        private Dictionary<Type, FsmState> _states = new Dictionary<Type, FsmState>();

        public void AddState(FsmState state)
        {
            _states.Add(state.GetType(), state);
        }

        public void SetState<T>() where T : FsmState
        {
            var type = typeof(T);

            if (StateCurrent != null && StateCurrent.GetType() == type) //Проверяем текущее состояние
            {
                return;
            }

            if (_states.TryGetValue(type, out var newState))
            {
                StateCurrent?.Exit();

                StateCurrent = newState;

                StateCurrent.Enter();
            }
        }

        public void Update()
        {
            StateCurrent?.Update();
        }
    }
}
