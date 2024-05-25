using Game.Logic.StateMachine;
using Game.Entities.Enemies;
namespace Game.Enemies.States {
	public abstract class EnemyBaseState : IState {

		protected readonly RedEnemy redEnemy;

		protected EnemyBaseState(RedEnemy redEnemy) {
			this.redEnemy = redEnemy;
		}
		public virtual void FixedUpdate() {
			//noop
		}

		public virtual void OnEnter() {
			//noop
		}

		public virtual void OnExit() {
			//noop
		}

		public virtual void Update() {
			//noop
		}
	}
}