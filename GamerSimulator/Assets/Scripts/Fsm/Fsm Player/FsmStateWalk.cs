using UnityEngine;

namespace FSMScripts
{
    public class FsmStateWalk : FsmStateMovement
    {
        public FsmStateWalk(Fsm fsm, Rigidbody rigidbody, float speed) : base(fsm, rigidbody, speed) { }

        public override void Update()
        {
            //Debug.Log($"Walk state [UPDATE] with speed: {Speed}");

            var inputDirection = ReadInput();

            if (inputDirection.sqrMagnitude == 0f)
            {
                Fsm.SetState<FsmStateIdle>();
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Fsm.SetState<FsmStateRun>();
            }

            Move(inputDirection);
        }
    }
}
