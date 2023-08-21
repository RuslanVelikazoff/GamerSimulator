using UnityEngine;

namespace FSMScripts
{
    public class FsmPlayer : MonoBehaviour
    {
        private Fsm _fsm;
        private float _walkSpeed = 10f;
        private float _runSpeed = 20f;

        public void Initialize()
        {
            _fsm = new Fsm();

            _fsm.AddState(new FsmStateIdle(_fsm));
            _fsm.AddState(new FsmStateWalk(_fsm, GetComponent<Rigidbody>(), _walkSpeed));
            _fsm.AddState(new FsmStateRun(_fsm, GetComponent<Rigidbody>(), _runSpeed));

            _fsm.SetState<FsmStateIdle>();
        }

        private void Update()
        {
            _fsm.Update();
        }
    }
}
