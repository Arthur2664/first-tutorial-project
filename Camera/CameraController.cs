using Godot;

namespace FirstTutorialProject.Camera;

public partial class CameraController : Node3D
{
	[Export]
	public float MoveSpeed = 5f;

	[Export]
	public CharacterBody3D TargetCharacter;

	public override void _Ready()
	{
		this.TopLevel = true;
	}

	public override void _PhysicsProcess(double delta)
	{
		this.Position = this.Position.Lerp(this.TargetCharacter.Position, this.MoveSpeed * (float)delta);
	}
}