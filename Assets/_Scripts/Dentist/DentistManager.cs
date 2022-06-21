using Game.Dentist.Damage;
using Game.Dentist.Tools;
using Game.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game.Dentist
{
	public class DentistManager : MonoBehaviour
	{
		public Action OnProgressGetted;

		[SerializeField] private Slider sliderProgress;
		[SerializeField] private Image preview;
		[SerializeField] private TeethDamagesContainer teethDamagesContainer;
		[Header("Tools part 1")]
		[SerializeField] private Tweezers tweezers;
		[SerializeField] private Brush brush;
		[SerializeField] private Drill drill;

		[Zenject.Inject] private FinishPanelController finishPanelController;

		private List<DentistTool> dentistToolsToMission;
		private DenstistMission currentMission;

		public TeethDamagesContainer TeethDamagesContainer => teethDamagesContainer;

		private void Start()
		{
			dentistToolsToMission = new List<DentistTool>() { tweezers, brush, drill };

			SetupNewMission();
			OnProgressGetted += CheckProgress;
		}

		private void OnDestroy()
		{
			OnProgressGetted -= CheckProgress;
		}

		public void SetupNewMission()
		{
			var dentistTool = dentistToolsToMission.First();

			currentMission = new DenstistMission(dentistTool);
			preview.sprite = dentistToolsToMission[0].Sprite;
		}

		private void LoadNewMission()
		{
			if(dentistToolsToMission.Count == 1)
			{
				finishPanelController.Open();
				return;
			}

			dentistToolsToMission.RemoveAt(0);
			sliderProgress.value = 0;
			SetupNewMission();
		}

		private void CheckProgress()
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
