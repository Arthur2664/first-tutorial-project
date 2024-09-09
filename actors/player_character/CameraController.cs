using Godot;

namespace FirstTutorialProject.actors.player_character;

public partial class CameraController : Node3D
{
	[Export]
	private float moveSpeed = 5f;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.TopLevel = true;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (GetParent() is CharacterBody3D playerCharacter)
			this.Position = this.Position.Lerp(playerCharacter.Position, moveSpeed * (float)delta);
	}
}