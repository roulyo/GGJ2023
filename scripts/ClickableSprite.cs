using Godot;

public class ClickableSprite : Sprite
{
    public override void _Input(InputEvent inputEvent)
    {
        if(inputEvent is InputEventMouseButton) 
        {
            if(IsPixelOpaque(GetLocalMousePosition()))
            {
                GetTree().SetInputAsHandled();
                if(inputEvent.IsActionPressed("click"))
                {
                    Modulate = new Color(0, 0, 1);
                }
                else
                {
                    Modulate = new Color(1, 1, 1);
                }
            }
        }
    }

}
