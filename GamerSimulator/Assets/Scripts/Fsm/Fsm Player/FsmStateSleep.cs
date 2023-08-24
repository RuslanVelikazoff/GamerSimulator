using UnityEngine;

namespace FSMScripts
{
    public class FsmStateSleep : FsmState
    {
        protected readonly UI.PlayerUI playerUI;
        protected readonly PlayerStats playerStats;

        public FsmStateSleep(Fsm fsm, PlayerStats stats, UI.PlayerUI UIPlayer) : base(fsm)
        {
            playerStats = stats;
            playerUI = UIPlayer;
        }

        public override void Enter()
        {
            Debug.Log("Sleep state [ENTER]");
            Sleep();
        }

        public override void Exit()
        {
            Debug.Log("Sleep state [EXIT]");
        }

        private void Sleep()
        {
            playerStats.Cheerfulness += 1;
            playerUI.SetStatsInUI();
            Fsm.SetState<FsmStateIdle>();
        }
    }
}
