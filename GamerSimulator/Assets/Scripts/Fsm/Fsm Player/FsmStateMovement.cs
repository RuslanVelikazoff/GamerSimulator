using UnityEngine;

namespace FSMScripts
{
    public class FsmStateMovement : FsmState
    {
        protected readonly Rigidbody Rigidbody;
        protected readonly float Speed;

        public FsmStateMovement(Fsm fsm, Rigidbody rigidbody, float speed) : base(fsm)
        {
            Rigidbody = rigidbody;
            Speed = speed;
        }

        public override void Enter()
        {
            Debug.Log($"Movement ({this.GetType().Name}) state [ENTER]");
        }

        public override void Exit()
        {
            Debug.Log($"Movement ({this.GetType().Name}) state [EXIT]");
        }

        public override void Update()
        {
            //Debug.Log($"Movement ({this.GetType().Name}) state [Update] with speed: {Speed}");

            var inputDirection = ReadInput();

            if (inputDirection.sqrMagnitude == 0f)
            {
                Fsm.SetState<FsmStateIdle>();
            }

            Move(inputDirection);
        }

        protected Vector3 ReadInput()
        {
            var inputHorizontal = Input.GetAxis("Horizontal");
            var inputVertical = Input.GetAxis("Vertical");
            var inputDirection = new Vector3(inputHorizontal, 0, inputVertical);

            return inputDirection;
        }

        protected virtual void Move(Vector3 inputDirection)
        {
            Rigidbody.MovePosition(Rigidbody.position + inputDirection * Speed * Time.deltaTime);
        }
    }
}
