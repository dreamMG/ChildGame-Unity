using Game.Dentist.Damage;
using Game.Dentist.Tools;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game.Dentist
{
	public class DentistManager : MonoBehaviour
	{
		[SerializeField] private Slider sliderProgress;
		[SerializeField] private Image preview;
		[SerializeField] private TeethDamagesContainer teethDamagesContainer;
		[Header("Tools part 1")]
		[SerializeField] private Tweezers tweezers;
		[SerializeField] private Brush brush;
		[SerializeField] private Drill drill;

		private List<DentistTool> dentistToolsToMission;
		private DenstistMission currentMission;

		private void Start()
		{
			dentistToolsToMission = new List<DentistTool>() { tweezers, brush, drill };

			SetupNewMission();
		}

		public void SetupNewMission()
		{
			currentMission = new DenstistMission(dentistToolsToMission[0], teethDamagesContainer);
			preview.sprite = dentistToolsToMission[0].Sprite;
		}

		private void LoadNewMission()
		{
			if(dentistToolsToMission.Count == 1)
			{
				SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
				return;
			}

			dentistToolsToMission.RemoveAt(0);
			sliderProgress.value = 0;
			SetupNewMission();
		}

		private void Update()
		{
			currentMission?.GetProgress();
			sliderProgress.value = currentMission.CurrentProgress;

			if (sliderProgress.value == 1)
			{
				LoadNewMission();
			}
		}
	}
}
