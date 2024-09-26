using Godot;

namespace FirstTutorialProject.Common;

public static class TransformExtensions
{
    public static Transform3D ResetToBasisIdentity(this Transform3D transform)
    {
        transform.Basis = Basis.Identity;
        return transform;
    }
}