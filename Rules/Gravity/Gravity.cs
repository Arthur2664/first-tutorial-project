using Godot;

namespace FirstTutorialProject.Rules.Gravity;

public partial class Gravity : Node3D
{
	[Export]
	private CharacterBody3D characterBody;

	public override void _PhysicsProcess(double delta)
	{
		// Add the gravity.
		if (!this.characterBody.IsOnFloor())
		{
			this.characterBody.Velocity += this.characterBody.GetGravity() * (float)delta;
		}
	}
}