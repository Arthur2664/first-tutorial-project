using Godot;

public partial class Rotation : Node3D
{
	[Export]
	private float RotationSpeed = 5.0f;

	[Export]
	private Node3D TargetNode;

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		float degreeWithTime = (float)(this.RotationSpeed * delta);

		this.TargetNode.RotateY(degreeWithTime);
	}
}
