using Godot;

namespace FirstTutorialProject.Objects.Watermelon;

public partial class Watermelon : Area3D
{
#pragma warning disable IDE0060 // Remove unused parameter

    private void HandleBodyEntered(Node3D node3D) => base.QueueFree();
#pragma warning restore IDE0060 // Remove unused parameter

}