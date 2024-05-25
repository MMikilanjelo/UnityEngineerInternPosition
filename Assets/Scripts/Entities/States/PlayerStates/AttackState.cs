using Game.Controllers;
using UnityEngine;
namespace Game.Player.States {
	public class AttackState : BaseState {
		public AttackState(PlayerController playerController) : base(playerController) { }
		public override void OnEnter() {
			playerController.Attack();
		}
	}

}
