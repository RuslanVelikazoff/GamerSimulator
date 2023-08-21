using UnityEngine;

namespace FSMScripts
{
    public class FsmPlayer : MonoBehaviour
    {
        private Fsm _fsm;
        private new Rigidbody rigidbody;
        private PlayerStats playerStats;
        private UI.HomeUIManager UIManager;

        private float _walkSpeed = 10f;
        private float _runSpeed = 20f;

        public void Initialize()
        {
            _fsm = new Fsm();
            rigidbody = GetComponent<Rigidbody>();
            playerStats = FindObjectOfType<PlayerStats>();
            UIManager = FindObjectOfType<UI.HomeUIManager>();

            _fsm.AddState(new FsmStateIdle(_fsm));

            _fsm.AddState(new FsmStateEat(_fsm, playerStats));
            _fsm.AddState(new FsmStateSleep(_fsm, playerStats));

            _fsm.AddState(new FsmStateWalk(_fsm, rigidbody, _walkSpeed));
            _fsm.AddState(new FsmStateRun(_fsm, rigidbody, _runSpeed));

            _fsm.SetState<FsmStateIdle>();

            Debug.Log("Player initialized");
        }

        private void Update()
        {
            _fsm.Update();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.tag == "Fridge")
            {
                UIManager.OpenFridgePanel();
                _fsm.SetState<FsmStateEat>();
            }

            if (collision.transform.tag == "Bed")
            {
                UIManager.OpenBedPanel();
                _fsm.SetState<FsmStateSleep>();
            }
        }
    }
}
