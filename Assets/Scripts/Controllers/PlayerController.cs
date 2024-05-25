using UnityEngine;
using Game.Logic.StateMachine;
using Game.Managers;
using Game.Player.States;
using Game.Input;
using Game.Components;
namespace Game.Controllers {
	public class PlayerController : MonoBehaviour {
		[Header("Movement Settings")]
		[SerializeField] private float moveSpeed_ = 10f;
		[SerializeField] private float accelerationCoefficient_ = 5f;

		#region Essential  and components
		private InputReader inputReader_;
		private StateMachine stateMachine_;
		private VelocityComponent velocityComponent_;
		#endregion
		private void Awake() {
			SetUpStateMachine();
			velocityComponent_ = new VelocityComponent(moveSpeed_, accelerationCoefficient_);
			inputReader_ = new InputReader();
		}

		private void SetUpStateMachine() {
			stateMachine_ = new StateMachine();
			var idleState = new IdleState(this);
			var walkingState = new WalkingState(this);

			At(idleState, walkingState, new FuncPredicate(() => inputReader_.IsAnyMovementActionJustPressed()));
			At(walkingState, idleState, new FuncPredicate(() => inputReader_.AreAllMovementActionsReleased()));

			stateMachine_.SetState(idleState);
		}

		private void At(IState from, IState to, IPredicate condition) => stateMachine_.AddTransition(from, to, condition);
		private void Any(IState to, IPredicate condition) => stateMachine_.AddAnyTransition(to, condition);

		public void HandleMovement() {
			Vector3 movementDirection = inputReader_.GetMovementDirection();
			velocityComponent_.Move(movementDirection, gameObject);
		}
		private void Update() {
			stateMachine_.Update();
		}

		private void FixedUpdate() {
			stateMachine_.FixedUpdate();
		}
	}
}
