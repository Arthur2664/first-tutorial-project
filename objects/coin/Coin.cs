using Godot;

public partial class Coin : Area3D
{
	private const float RotationSpeed = 5.0f;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		float degreeWithTime = (float)(RotationSpeed * delta);

		RotateY(degreeWithTime);
	}

#pragma warning disable IDE0060 // Remove unused parameter

    private void HandleBodyEntered(Node3D node3D) => QueueFree();
#pragma warning restore IDE0060 // Remove unused parameter

}
