using Godot;

public partial class CameraController : Node3D
{
	[Export]
	private float moveSpeed = 5f;

	[Export]
	private CharacterBody3D targetCharacter;

	public override void _Ready()
	{
		base.TopLevel = true;
	}

	public override void _PhysicsProcess(double delta)
	{
		base.Position = base.Position.Lerp(targetCharacter.Position, moveSpeed * (float)delta);
	}
}