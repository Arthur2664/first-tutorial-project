using Godot;

public partial class CameraController : Node3D
{
	[Export]
	private float moveSpeed = 5f;

	[Export]
	private CharacterBody3D targetCharacter;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.TopLevel = true;
	}

	public override void _PhysicsProcess(double delta)
	{
		this.Position = this.Position.Lerp(targetCharacter.Position, moveSpeed * (float)delta);
	}
}