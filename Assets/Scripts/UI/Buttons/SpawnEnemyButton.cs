using UnityEngine;
using Game.Utilities.EventChannels;
using UnityEngine.UI;
namespace Game.UI {
	public class SpawnEnemyButton : MonoBehaviour {
		[SerializeField] public EventChannel spawnEnemyEventChannel;
		private Button button_;
		private void Awake(){
			button_ = GetComponent<Button>();
			button_.onClick.AddListener(OnSpawnEnemyButtonClick);
		}
		private void OnSpawnEnemyButtonClick(){
			spawnEnemyEventChannel.Invoke(new Empty{});
		}

	}
}

