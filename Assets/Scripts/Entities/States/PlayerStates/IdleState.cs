using UnityEngine;
using Game.Controllers;
namespace Game.Player.States {
	public class IdleState : BaseState {
		public IdleState(PlayerController playerController) : base(playerController) { }

		public override void OnEnter() {
			// We can play a Animation here or do some stuff like play music and so on o leave it empty for now ...
		}
	}
}