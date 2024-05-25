using Game.Utilities.Singletons;
using Game.Input;

namespace Game.Managers{
	
	public class InputManager : Singleton<InputManager>{
		private InputDevice inputDevice_;

		protected override void Awake() {
			inputDevice_ = new KeyboardDevice();
		}
		public bool IsInputActionJustPressed(InputAction inputAction) {
			return inputDevice_.IsInputActionJustPressed(inputAction);
		}
		public bool IsInputActionPressed(InputAction inputAction) {
			return inputDevice_.IsInputActionPressed(inputAction);
		}
		public bool IsInputActionRealized(InputAction inputAction) {
			return inputDevice_.IsInputActionRealized(inputAction);
		}
	}

}