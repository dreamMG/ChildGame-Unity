using UnityEngine.SceneManagement;

namespace Game.Scenes
{
	public enum SceneName
	{
		Intro,
		MiniGames,
		Dentist
	}

	public class ScenesManager
	{
		public static void LoadScene(SceneName sceneName)
		{
			SceneManager.LoadSceneAsync((int)sceneName, LoadSceneMode.Single);
		}
	}
}
