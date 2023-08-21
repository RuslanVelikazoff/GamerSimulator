using UnityEngine;

namespace FSMScripts
{
    public class FsmStateRun : FsmStateMovement
    {


        public FsmStateRun(Fsm fsm, Rigidbody rigidbody, float speed) : base(fsm, rigidbody, speed) { }

        public override void Update()
        {
            //Debug.Log($"Run state [UPDATE] with speed: {Speed}");

            var inputDirection = ReadInput();

            if (inputDirection.sqrMagnitude == 0f)
            {
                Fsm.SetState<FsmStateIdle>();
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                Fsm.SetState<FsmStateWalk>();
            }

            Move(inputDirection);
        }
    }
}
