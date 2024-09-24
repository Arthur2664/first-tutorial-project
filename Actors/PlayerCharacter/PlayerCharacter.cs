using Godot;

public partial class PlayerCharacter : CharacterBody3D
{
	private Transform3D xForm;

	[Export]
	public float Speed = 5.0f;

	[Export]
	public float JumpVelocity = 4.5f;

	public override void _PhysicsProcess(double delta)
	{
		Vector3 velocity = Velocity;

		// Handle Jump.
		if(IsOnFloor())
		{
			this.AlignWithFloor(this.GetNode<RayCast3D>("FloorAlignRay").GetCollisionNormal());
			this.Transform = this.Transform.InterpolateWith(this.xForm, 0.3f);
		}
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		{
			velocity.Y = this.JumpVelocity;
		}
		else
		{
			this.AlignWithFloor(Vector3.Up);
			this.Transform = this.Transform.InterpolateWith(this.xForm, 0.3f);
		}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 inputDir = Input.GetVector("MoveLeft","MoveRight", "MoveForward", "MoveBackward");
		Vector3 direction = (Transform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();
		
		if (direction != Vector3.Zero)
		{
			velocity.X = direction.X * this.Speed;
			velocity.Z = direction.Z * this.Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, this.Speed);
			velocity.Z = Mathf.MoveToward(Velocity.Z, 0, this.Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}

	private void AlignWithFloor(Vector3 collisionNormal)
	{
		this.xForm = this.Transform;
		this.xForm.Basis.Y = collisionNormal;
		this.xForm.Basis.X = -this.xForm.Basis.Z.Cross(collisionNormal);
		this.xForm.Basis = this.xForm.Basis.Orthonormalized();
	}
}
