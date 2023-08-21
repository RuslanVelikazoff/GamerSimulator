using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSMScripts
{
    public class FsmStateSleep : FsmState
    {
        protected readonly PlayerStats playerStats;

        public FsmStateSleep(Fsm fsm, PlayerStats stats) : base(fsm)
        {
            playerStats = stats;
        }

        public override void Enter()
        {
            Debug.Log("Sleep state [ENTER]");
        }

        public override void Exit()
        {
            Debug.Log("Sleep state [EXIT]");
        }

        public override void Update()
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                Fsm.SetState<FsmStateIdle>();
            }
        }
    }
}
