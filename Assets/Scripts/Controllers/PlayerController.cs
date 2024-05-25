
using Game.Logic.StateMachine;
using Game.Player.States;
using Game.Input;
using Game.Components;
using Game.Entities.Components;
using Game.Managers;
using Game.Utilities.Timers;

using UnityEngine;
namespace Game.Controllers {
	public class PlayerController : MonoBehaviour {
		#region SerializeFields
		[Header("Movement Settings")]
		[SerializeField] private float moveSpeed_ = 10.0f;
		[SerializeField] private float accelerationCoefficient_ = 5.0f;

		[Header("Health Settings")]
		[SerializeField] private float maxHealth_ = 10.0f;
		[Header("Attack")]
		[SerializeField] private float attackDelay_ = 0.2f;
		#endregion

		#region Essential  and components
		private InputReader inputReader_;
		private readonly StateMachine stateMachine_ = new StateMachine();
		private VelocityComponent velocityComponent_;
		private HealthComponent healthComponent_;
		#endregion
		#region Timers
		private CountdownTimer attackTimer_;
		#endregion
		private void Awake() {
			SetUpStateMachine();
			healthComponent_ = GetComponent<HealthComponent>();
			velocityComponent_ = new VelocityComponent(moveSpeed_, accelerationCoefficient_);
			inputReader_ = new InputReader();
			SetUpTimers();
		}
		private void SetUpTimers() {
			attackTimer_ = new CountdownTimer(attackDelay_);
		}

		private void SetUpStateMachine() {
			var idleState = new IdleState(this);
			var walkingState = new WalkingState(this);
			var attackState = new AttackState(this);
			At(idleState, walkingState, new FuncPredicate(() => inputReader_.IsAnyMovementActionJustPressed()));
			At(walkingState, idleState, new FuncPredicate(() => inputReader_.AreAllMovementActionsReleased()));
			At(attackState, walkingState, new FuncPredicate(() => attackTimer_.IsRunning));

			Any(attackState, new FuncPredicate(() => attackTimer_.IsFinished &&
				InputManager.Instance.IsInputActionJustPressed(InputAction.KILL_ENEMY)));

			stateMachine_.SetState(idleState);
		}

		private void At(IState from, IState to, IPredicate condition) => stateMachine_.AddTransition(from, to, condition);
		private void Any(IState to, IPredicate condition) => stateMachine_.AddAnyTransition(to, condition);

		public void HandleMovement() {
			Vector3 movementDirection = inputReader_.GetMovementDirection();
			velocityComponent_.Move(movementDirection, this.gameObject);
		}
		public void Attack() {
			if (attackTimer_.IsRunning) {
				return;
			}
			attackTimer_.Start();

			Collider[] colliders = Physics.OverlapSphere(transform.position, 30f, LayerMask.GetMask("Enemy"));

			if (colliders.Length == 0) {
				Debug.Log("No enemies found.");
				return;
			}
			Transform playerTransform = transform;
			GameObject nearestEnemy = null;
			float nearestDistance = Mathf.Infinity;
			for (int i = 0; i < colliders.Length; i++) {
				float distance = Vector3.Distance(playerTransform.position, colliders[i].transform.position);
				if (distance < nearestDistance) {
					nearestDistance = distance;
					nearestEnemy = colliders[i].gameObject;
				}
			}
			if (nearestEnemy != null) {
				Destroy(nearestEnemy);
				Debug.Log("Destroyed nearest enemy.");
			}
			else {
				Debug.Log("No enemies found.");
			}
		}
		private void Update() {
			stateMachine_.Update();
			attackTimer_.Tick(Time.deltaTime);
		}

		private void FixedUpdate() {
			stateMachine_.FixedUpdate();
		}
	}
}
