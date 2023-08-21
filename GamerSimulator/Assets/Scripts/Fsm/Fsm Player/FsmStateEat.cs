using UnityEngine;

namespace FSMScripts
{
    public class FsmStateEat : FsmState
    {
        protected readonly PlayerStats playerStats;

        public FsmStateEat(Fsm fsm, PlayerStats stats) : base(fsm)
        {
            playerStats = stats;
        }

        public override void Enter()
        {
            Debug.Log("Eat state [ENTER]");
        }

        public override void Exit()
        {
            Debug.Log("Eat state [EXIT]");
        }

        public override void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Fsm.SetState<FsmStateIdle>();
            }
        }
    }
}
