using Game.Entities.Enemies;
using UnityEngine;

namespace Game.Enemies.States {
	public class AttackState : EnemyBaseState {
		public AttackState(RedEnemy redEnemy) : base(redEnemy) { }
		public override void OnEnter() {
			redEnemy.Attack();
		}
		public override void Update() {
			redEnemy.Chase();
		}
	}
}

