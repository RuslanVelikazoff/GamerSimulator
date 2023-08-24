using UnityEngine;

namespace FSMScripts
{
    public class FsmStateTouchesFridge : FsmState
    {
        protected readonly UI.HomeUIManager UIManager;

        public FsmStateTouchesFridge(Fsm fsm, UI.HomeUIManager uiManager) : base(fsm)
        {
            UIManager = uiManager;
        }

        public override void Enter()
        {
            Debug.Log("State FridgeTouches [ENTER]");
            UIManager.TipPanel("Fridge", true);
        }

        public override void Exit()
        {
            Debug.Log("State FridgeTouches [EXIT]");
        }

        public override void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                UIManager.OpenFridgePanel();
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                Fsm.SetState<FsmStateIdle>();
                UIManager.TipPanel("Fridge", false);
            }
        }
    }
}
