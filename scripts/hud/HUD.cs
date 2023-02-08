using Godot;

public class HUD : CanvasLayer
{
    [Signal]
    public delegate void GoToLeft();
    [Signal]
    public delegate void GoToRight();
    [Signal]
    public delegate void BlurBackground();

    public override void _Ready()
    {
        PauseMode = Node.PauseModeEnum.Process;
        GetNode<Control>("Pause").Hide();
    }

//-----------------------------------------------------------------------------
    public override void _Input(InputEvent inputEvent)
    {
        //Pause the game
        if (inputEvent.IsActionPressed("pause"))
        {
            GetNode<Control>("Pause").Visible = !GetNode<Control>("Pause").Visible;
            GetTree().Paused = !GetTree().Paused;
            SetMoveButtonEnabled(GetNode<Button>("Control/GoToLeftButton").Disabled);
            EmitSignal(nameof(BlurBackground), GetTree().Paused);
        }
    }
//-----------------------------------------------------------------------------
    private void SetMoveButtonEnabled(bool enabled)
    {
        GetNode<Button>("Control/GoToLeftButton").Disabled = !enabled;
        GetNode<Button>("Control/GoToRightButton").Disabled = !enabled;
    }

//-----------------------------------------------------------------------------
    public void OnGoToLeftButtonPressed()
    {
        EmitSignal(nameof(GoToLeft));
    }

//-----------------------------------------------------------------------------
    public void OnGoToRightButtonPressed()
    {
        EmitSignal(nameof(GoToRight));
    }
//-----------------------------------------------------------------------------
    private void OnMiniGameStarted()
    {
        SetMoveButtonEnabled(false);
    }

//-----------------------------------------------------------------------------
    private void OnMiniGameEnded()
    {
        SetMoveButtonEnabled(true);
    }
//-----------------------------------------------------------------------------
    private void OnMiniGameWon(string clue)
    {
        GetNode<Label>("Control/PopupPanel/Clues").Text += clue;
        GetNode<Label>("Control/PopupPanel/Clues").Text += "\n";
    }
//-----------------------------------------------------------------------------
    public void OnUnpauseButtonPressed()
    {
        GetNode<Control>("Pause").Hide();
        GetTree().Paused = false;
        SetMoveButtonEnabled(true);
        EmitSignal(nameof(BlurBackground), false);
    }
//-----------------------------------------------------------------------------
    public void OnStartScreenButtonPressed()
    {
        GetTree().Paused = false;
        GetNode<SceneChanger>("/root/SceneChanger").ChangeScene("res://scenes/StartScene.tscn", "fade");
    }
//-----------------------------------------------------------------------------
    public void OnQuitGameButtonPressed()
    {
        GetTree().Quit();
    }
}
