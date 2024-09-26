using Godot;

namespace FirstTutorialProject.Rules.RotateWithMouse;

public partial class RotateWithMouse : Node3D
{
	private float rotationX;
	private float rotationY;

	[Export]
	public float LookAroundSpeed = 0.03f;

	[Export]
	public Node3D TargetCharacter;

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseMotion eventMouseMotion)
		{
			// modify accumulated mouse rotation
			this.rotationX += eventMouseMotion.Relative.X * this.LookAroundSpeed;
			this.rotationY += eventMouseMotion.Relative.Y * this.LookAroundSpeed;

			this.TargetCharacter.Transform = ResetTransform(this.TargetCharacter.Transform);

			this.RotateNode(this.TargetCharacter);
		}
	}

	private void RotateNode(Node3D node)
	{
		node.RotateObjectLocal(Vector3.Down, this.rotationX); // first rotate about Y
		node.RotateObjectLocal(Vector3.Left, this.rotationY); // then rotate about X
	}


	private static Transform3D ResetTransform(Transform3D transform)
	{
		transform.Basis = Basis.Identity;
		return transform;
	}

}