using Godot;

public class ObjectOfInterest : Area2D
{
    [Signal]
    public delegate void ObjectPressed();
    [Signal]
    public delegate void ObjectReleased();

    private bool IsMiniGameOpen = false;

//-----------------------------------------------------------------------------
    public override void _Input(InputEvent inputEvent)
    {
        if(inputEvent is InputEventMouseButton)
        {
            var sprite = GetNode<Sprite>("Sprite");
            if(sprite.IsPixelOpaque(GetLocalMousePosition()) && !IsMiniGameOpen)
            {
                GetTree().SetInputAsHandled();
                if(inputEvent.IsActionPressed("click"))
                {
                    IsMiniGameOpen = true;
                    var miniGame = GetNode<Node2D>("MiniGame");
                    var miniGameSizeX = miniGame.GetNode<ColorRect>("ColorRect").RectSize.x;
                    var miniGameSizeY = miniGame.GetNode<ColorRect>("ColorRect").RectSize.y;
                    miniGame.GlobalPosition = new Vector2(GetViewportRect().Size.x/2-miniGameSizeX/2 , GetViewportRect().Size.y/2-miniGameSizeY/2);
                    miniGame.Show();
                }
            }
        }
    }
//-----------------------------------------------------------------------------
    public void CloseMiniGame()
    {
        //TODO: Be sure to reset the game or not if keeping clue
        IsMiniGameOpen = false;
        GetNode<Node2D>("MiniGame").Hide();
    }
//-----------------------------------------------------------------------------
    private void OnArea2DMouseEntered()
    {
        (GetNode<Sprite>("Sprite").Material as ShaderMaterial).SetShaderParam("width", 4.20);
    }
//-----------------------------------------------------------------------------
    private void OnArea2DMouseExited()
    {
        (GetNode<Sprite>("Sprite").Material as ShaderMaterial).SetShaderParam("width", 0.00);
    }

    //-----------------------------------------------------------------------------
    private void _on_ObjectOfInterest_input_event(Node viewport, InputEvent @evt, int shape_idx)
    {

        if (@evt is InputEventMouseButton evtBttn)
        {
            if (evtBttn.Pressed)
            {
                EmitSignal(nameof(ObjectPressed));
            }
            else
            {
                EmitSignal(nameof(ObjectReleased));
            }
        }
    }
}
