using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
namespace Game.Input {
	public class KeyboardDevice : InputDevice {
		private Dictionary<InputAction, Key> mappings_ = new Dictionary<InputAction, Key>(){
			{ InputAction.MOVE_FORWARD, Key.W },
			{ InputAction.MOVE_BACKWARD, Key.S },
			{ InputAction.MOVE_LEFT, Key.A },
			{ InputAction.MOVE_RIGHT, Key.D },
		};

		public override bool IsInputActionJustPressed(InputAction action) {
			if (mappings_.ContainsKey(action)) {
				Key keyCode = mappings_[action];
				return Keyboard.current[keyCode].wasPressedThisFrame;
			}
			return false;
		}

		public override bool IsInputActionPressed(InputAction inputAction) {
			if (mappings_.ContainsKey(inputAction)) {
				Key keyCode = mappings_[inputAction];
				return Keyboard.current[keyCode].isPressed;
			}
			return false;
		}

		public override bool IsInputActionRealized(InputAction inputAction) {
			if (mappings_.ContainsKey(inputAction)) {
				Key keyCode = mappings_[inputAction];
				return Keyboard.current[keyCode].wasReleasedThisFrame;

			}
			return false;
		}
	}
}