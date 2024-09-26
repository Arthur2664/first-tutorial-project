using Godot;

namespace FirstTutorialProject.Objects.KillZone;

public partial class KillZone : Node
{
    private void HandleBodyEntered(Node3D node3D)
    {
        this.GetTree().CallDeferred(SceneTree.MethodName.ChangeSceneToFile, "res://Levels/Level_1.tscn");
    }
}