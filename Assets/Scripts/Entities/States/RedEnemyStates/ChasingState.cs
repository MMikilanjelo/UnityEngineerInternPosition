using Game.Entities.Enemies;
using UnityEngine;

namespace Game.Enemies.States {
	public class ChasingState : EnemyBaseState {
		public ChasingState(RedEnemy redEnemy) : base(redEnemy) { }
		public override void Update() {
			redEnemy.Chase();
		}
	}
}

