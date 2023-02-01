using Godot;

public class IntroductionCutScene : Label
{
    public override void _Ready()
    {
        GetNode<Tween>("Tween").InterpolateProperty(this, "percent_visible", 0.0, 1.0, 15, Tween.TransitionType.Linear, Tween.EaseType.InOut);
        GetNode<Tween>("Tween").Start();
    }
//-----------------------------------------------------------------------------
    public void OnTweenTweenAllCompleted()
    {
        GetNode<AudioStreamPlayer>("TypingAudio").Stop();
        GetNode<SceneChanger>("/root/SceneChanger").ChangeScene("res://scenes/Main.tscn", "fade");
    }

}
