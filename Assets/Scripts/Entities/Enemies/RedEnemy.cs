using Game.Components;
using Game.Enemies.States;
using Game.Logic.StateMachine;
using Game.Managers;
using UnityEngine;
using Game.Utilities.Timers;
using Game.Entities.Components;
namespace Game.Entities.Enemies {

	public class RedEnemy : Enemy {
		#region SerializeFields
		
		[Header("Movement Settings")]
		[SerializeField] private float moveSpeed_ = 2.0f;
		[SerializeField] private float accelerationCoefficient_ = 2.0f;
		
		[Header("AttackSettings Settings")]
		[SerializeField] private float attackDelay_ = 2.0f;
		
		[Header("Projectiles")]
		[SerializeField]GameObject projectile_;
		#endregion
		#region Essential  and components
		private readonly StateMachine stateMachine_ = new();

		private VelocityComponent velocityComponent_;
		#endregion
		#region Timers
		private CountdownTimer attackTimer_;
		#endregion
		private void Awake() {
			SetUpStateMachine();
			velocityComponent_ = new VelocityComponent(moveSpeed_  ,accelerationCoefficient_);
			SetUpTimers();
		}
		
		private void Update(){
			stateMachine_.Update();
			attackTimer_.Tick(Time.deltaTime);
		}		
		private void FixedUpdate(){
			stateMachine_.FixedUpdate();
		}
		private void SetUpTimers(){
			attackTimer_ = new CountdownTimer(attackDelay_);
		}
		private void SetUpStateMachine() {
			var chasingState = new ChasingState(this);
			var attackState = new AttackState(this);
			At(chasingState, attackState, new FuncPredicate(() => attackTimer_.IsFinished));
			At(attackState, chasingState, new FuncPredicate(() => attackTimer_.IsRunning));
			stateMachine_.SetState(chasingState);
		}
		private void At(IState from, IState to, IPredicate condition) => stateMachine_.AddTransition(from, to, condition);
		private void Any(IState to, IPredicate condition) => stateMachine_.AddAnyTransition(to, condition);
		public void Chase(){
			Vector3 direction =  (GameManager.Instance.Player.transform.position  - transform.position).normalized;
			velocityComponent_.Move(direction , this.gameObject); 
		}
		public void Attack(){
			if (attackTimer_.IsRunning){
				return;
			}
			attackTimer_.Start();
			Instantiate(projectile_ , transform.position , Quaternion.identity);
			
		}
		
	}
}
