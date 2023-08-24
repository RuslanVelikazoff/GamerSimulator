using UnityEngine;

namespace FSMScripts
{
    public class FsmStateTouchesBed : FsmState
    {
        protected readonly UI.HomeUIManager UIManager;

        public FsmStateTouchesBed(Fsm fsm, UI.HomeUIManager uiManager) : base(fsm)
        {
            UIManager = uiManager;
        }

        public override void Enter()
        {
            Debug.Log("State BedTouches [ENTER]");
            UIManager.TipPanel("Bed", true);
        }

        public override void Exit()
        {
            Debug.Log("State BedTouches [EXIT]");
        }

        public override void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                UIManager.OpenBedPanel();
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Fsm.SetState<FsmStateIdle>();
                UIManager.TipPanel("Bed", false);
            }
        }
    }
}
