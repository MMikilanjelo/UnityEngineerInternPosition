using System;
namespace Game.Logic.StateMachine {
	public class FuncPredicate : IPredicate {
		readonly Func<bool> func_;

		public FuncPredicate(Func<bool> func_) {
			this.func_ = func_;
		}

		public bool Evaluate() => func_.Invoke();
	}
}

