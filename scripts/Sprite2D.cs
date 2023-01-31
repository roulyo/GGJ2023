using Godot;

public class Sprite2D : Sprite
{
    [Export]
    public PackedScene MiniGame;
    
    private bool IsMiniGameOpen = false;

    public override void _Input(InputEvent inputEvent)
    {
        if(inputEvent is InputEventMouseButton) 
        {
            if(IsPixelOpaque(GetLocalMousePosition()))
            {
                GetTree().SetInputAsHandled();
                if(inputEvent.IsActionPressed("click") && !IsMiniGameOpen)
                {
                    Modulate = new Color(0, 0, 1);
                    IsMiniGameOpen = true;
                    AddChild(MiniGame.Instance());
                }
                else
                {
                    Modulate = new Color(1, 1, 1);
                }
            }
        }
    }

}
