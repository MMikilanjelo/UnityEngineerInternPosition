using Game.Utilities.EventChannels;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Labels {
	public class PlayerHealthLabel : MonoBehaviour {
		private Text healthText_;
		private void Awake(){
			healthText_ = GetComponent<Text>();
		}
		public void UpdateHealthText(HealthUpdate healthUpdate){
			healthText_.text = healthUpdate.CurrentHealth.ToString();
		}
	}

}
