
namespace Game.Logic.StateMachine {
	public interface ITransition {
		IState To { get; }
		IPredicate Condition { get; }
	}

}

