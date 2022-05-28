namespace Game.Dentist
{
	public class Mission
	{
		protected float currentProgress;
		protected float necessaryProgress;

		public float CurrentProgress => currentProgress / necessaryProgress;
	}
}