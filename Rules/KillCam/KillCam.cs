using System.Linq;
using FirstTutorialProject.Actors.PlayerCharacter;
using FirstTutorialProject.Camera;
using FirstTutorialProject.Common;
using Godot;

namespace FirstTutorialProject.Rules.KillCam;

public partial class KillCam : Node3D
{
    [Export]
    public PlayerCharacter TargetCharacter;
    
    private void HandleBodyEntered(Node3D node3D)
    {
        var targetCamera = this.TargetCharacter.GetChildren().OfType<CameraController>().FirstOrDefault();
        
        if (targetCamera is null) return;

        var rotateWithMouseNode = targetCamera.GetChildren().OfType<RotateWithMouse.RotateWithMouse>().FirstOrDefault();

        if (rotateWithMouseNode is not null)
        {
            targetCamera.RemoveChild(rotateWithMouseNode);
        }
        
        targetCamera.Transform = targetCamera.Transform.ResetToBasisIdentity();
        targetCamera.RotateObjectLocal(Vector3.Left, float.DegreesToRadians(62.0f));
    }
}