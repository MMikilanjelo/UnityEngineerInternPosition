namespace Game.Input {

	public abstract class InputDevice {
		public abstract bool IsInputActionJustPressed(InputAction action);
		public abstract bool IsInputActionPressed(InputAction inputAction);
		public abstract bool IsInputActionRealized(InputAction inputAction);

	}
	public enum InputAction {
		MOVE_FORWARD,
		MOVE_BACKWARD,
		MOVE_LEFT,
		MOVE_RIGHT,
	}
}