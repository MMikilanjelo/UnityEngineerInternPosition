using UnityEngine;
using Game.Controllers;
namespace Game.Player.States {
	public class WalkingState : BaseState {
		public WalkingState(PlayerController playerController) : base(playerController) { }
		public override void Update() {
			playerController.HandleMovement();
		}
		public override void FixedUpdate() {
		}
	}
}