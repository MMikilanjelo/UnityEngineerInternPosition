namespace Game.Logic.StateMachine {
	public interface IState {
		void OnEnter();
		void OnExit();
		void FixedUpdate();
		void Update();
	}
}