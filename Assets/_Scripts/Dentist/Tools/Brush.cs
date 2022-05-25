namespace Game.Dentist.Tools
{
	public class Brush : DentistTool
	{
		public override void Activate()
		{
			Move(10);
			PlaySound("brush");
			SpawnParticles();
		}
	}
}
