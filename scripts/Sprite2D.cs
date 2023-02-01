using Godot;

public class Sprite2D : Sprite
{    
    private bool IsMiniGameOpen = false;

    public override void _Input(InputEvent inputEvent)
    {
        if(inputEvent is InputEventMouseButton) 
        {
            if(IsPixelOpaque(GetLocalMousePosition()) && !IsMiniGameOpen)
            {
                GetTree().SetInputAsHandled();
                if(inputEvent.IsActionPressed("click"))
                {
                    IsMiniGameOpen = true;
                    GetNode<Node2D>("MiniGame").Show();
                }
            }
        }
    }

    public void CloseMiniGame()
    {
        //TODO: Be sure to reset the game or not if keeping clue
        IsMiniGameOpen = false;
        GetNode<Node2D>("MiniGame").Hide();
    }

}
