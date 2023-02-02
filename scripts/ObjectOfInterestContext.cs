using Godot;
public class ObjectOfInterestContext : Node2D
{
    [Signal]
    public delegate void CloseContext();

    public override void _Ready()
    {
        Hide();
    }
//-----------------------------------------------------------------------------
    public void OnCloseContextPressed()
    {
        Hide();
        EmitSignal("CloseContext");
    }
}