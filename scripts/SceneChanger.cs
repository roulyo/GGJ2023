using Godot;

public class SceneChanger : CanvasLayer
{
    public string scene;
    public void ChangeScene(string newScene, string animation)
    {
        scene = newScene;
        GetNode<AnimationPlayer>("Control/AnimationPlayer").Play(animation);
    }
//-----------------------------------------------------------------------------
    public void NewScene()
    {
        GetTree().ChangeScene(scene);
    }
}
