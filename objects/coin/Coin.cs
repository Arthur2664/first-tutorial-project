using Godot;

namespace FirstTutorialProject.Objects.Coin;

public partial class Coin : Area3D
{
#pragma warning disable IDE0060 // Remove unused parameter

    private void HandleBodyEntered(Node3D node3D) => base.QueueFree();
#pragma warning restore IDE0060 // Remove unused parameter

}