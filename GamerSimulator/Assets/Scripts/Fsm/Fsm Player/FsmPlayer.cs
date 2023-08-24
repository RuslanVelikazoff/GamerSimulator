using UnityEngine;

namespace FSMScripts
{
    public class FsmPlayer : MonoBehaviour
    {
        public Fsm _fsm;
        private new Rigidbody rigidbody;
        private PlayerStats playerStats;
        private UI.HomeUIManager UIManager;
        private UI.PlayerUI playerUI;

        private float _walkSpeed = 10f;
        private float _runSpeed = 20f;

        public void Initialize()
        {
            _fsm = new Fsm();
            rigidbody = GetComponent<Rigidbody>();
            playerStats = FindObjectOfType<PlayerStats>();
            UIManager = FindObjectOfType<UI.HomeUIManager>();
            playerUI = FindAnyObjectByType<UI.PlayerUI>();

            _fsm.AddState(new FsmStateIdle(_fsm));

            _fsm.AddState(new FsmStateTouchesFridge(_fsm, UIManager));
            _fsm.AddState(new FsmStateTouchesBed(_fsm, UIManager));

            _fsm.AddState(new FsmStateEat(_fsm, playerStats));
            _fsm.AddState(new FsmStateSleep(_fsm, playerStats, playerUI));

            _fsm.AddState(new FsmStateWalk(_fsm, rigidbody, _walkSpeed));
            _fsm.AddState(new FsmStateRun(_fsm, rigidbody, _runSpeed));

            _fsm.SetState<FsmStateIdle>();

            Debug.Log("Player initialized");
        }

        private void Update()
        {
            _fsm.Update();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Fridge"))
            {
                _fsm.SetState<FsmStateTouchesFridge>();
            }

            if (other.gameObject.CompareTag("Bed"))
            {
                _fsm.SetState<FsmStateTouchesBed>();
            }
        }

    }
}
