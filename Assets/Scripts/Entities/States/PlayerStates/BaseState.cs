using Game.Logic.StateMachine;
using Game.Controllers;
namespace Game.Player.States {
	public abstract class BaseState : IState {

		protected readonly PlayerController playerController;

		protected BaseState(PlayerController playerController) {
			this.playerController = playerController;
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