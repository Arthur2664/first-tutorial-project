using Godot;

public partial class CameraController : Node3D
{
	[Export]
    private float MoveSpeed = 5f;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
		this.TopLevel = true;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var playerCharacter = GetParent() as CharacterBody3D;
		this.Position = this.Position.Lerp(playerCharacter.Position, MoveSpeed * (float)delta);
	}
}
