using Godot;

public class StartScene : CanvasLayer
{
    public void OnStartButtonPressed()
    {
        GetNode<SceneChanger>("/root/SceneChanger").ChangeScene("res://scenes/IntroductionCutScene.tscn", "fade");
    }
}
