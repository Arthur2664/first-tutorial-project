using Godot;

public partial class CameraController : Node3D
{
	private float rotationX = 0f;
	private float rotationY = 0f;

	[Export]
	public float MoveSpeed = 5f;

	[Export]
	public CharacterBody3D TargetCharacter;

	[Export]
	public float LookAroundSpeed = 0.03f;

	public override void _Ready()
	{
		this.TopLevel = true;
	}

	public override void _PhysicsProcess(double delta)
	{
		this.Position = this.Position.Lerp(TargetCharacter.Position, MoveSpeed * (float)delta);
	}

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseMotion eventMouseMotion)
        {
            // modify accumulated mouse rotation
            this.rotationX += eventMouseMotion.Relative.X * this.LookAroundSpeed; 
            this.rotationY += eventMouseMotion.Relative.Y * this.LookAroundSpeed;

            // reset rotation
            this.Transform = ResetTrasform(this.Transform);
            this.TargetCharacter.Transform = ResetTrasform(this.TargetCharacter.Transform);

            this.RotateWithMouse(this);
			this.RotateWithMouse(this.TargetCharacter);
        }
    }

    private void RotateWithMouse(Node3D node) 
    {
        node.RotateObjectLocal(Vector3.Down, this.rotationX); // first rotate about Y
        node.RotateObjectLocal(Vector3.Left, this.rotationY); // then rotate about X
    }


    private Transform3D ResetTrasform(Transform3D transform)
    {
        transform.Basis = Basis.Identity;
        return transform;
    }

}