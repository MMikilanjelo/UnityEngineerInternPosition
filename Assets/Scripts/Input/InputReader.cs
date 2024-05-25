using Game.Managers;
using UnityEngine;

namespace Game.Input {
	public class InputReader {
		private InputManager inputManager_ => InputManager.Instance;

		public Vector3 GetMovementDirection() {
			Vector3 direction = Vector3.zero;

			if (inputManager_.IsInputActionPressed(InputAction.MOVE_FORWARD))
				direction += Vector3.forward;
			if (inputManager_.IsInputActionPressed(InputAction.MOVE_BACKWARD))
				direction -= Vector3.forward;
			if (inputManager_.IsInputActionPressed(InputAction.MOVE_LEFT))
				direction -= Vector3.right;
			if (inputManager_.IsInputActionPressed(InputAction.MOVE_RIGHT))
				direction += Vector3.right;

			if (direction.magnitude > 1f)
				direction.Normalize();

			return direction;
		}

		public bool IsAnyMovementActionJustPressed() {
			return inputManager_.IsInputActionJustPressed(InputAction.MOVE_FORWARD) ||
						 inputManager_.IsInputActionJustPressed(InputAction.MOVE_BACKWARD) ||
						 inputManager_.IsInputActionJustPressed(InputAction.MOVE_LEFT) ||
						 inputManager_.IsInputActionJustPressed(InputAction.MOVE_RIGHT);
		}

		public bool AreAllMovementActionsReleased() {
			return inputManager_.IsInputActionRealized(InputAction.MOVE_FORWARD) &&
						 inputManager_.IsInputActionRealized(InputAction.MOVE_BACKWARD) &&
						 inputManager_.IsInputActionRealized(InputAction.MOVE_LEFT) &&
						 inputManager_.IsInputActionRealized(InputAction.MOVE_RIGHT);
		}
	}
}
