using Godot;

public class ObjectOfInterest : Area2D
{
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
        CanvasItemMaterial material = (CanvasItemMaterial)GetNode<Sprite>("Sprite").Material;
        material.BlendMode = (Godot.CanvasItemMaterial.BlendModeEnum) 1;
    }
//-----------------------------------------------------------------------------
    private void OnArea2DMouseExited()
    {
        CanvasItemMaterial material = (CanvasItemMaterial)GetNode<Sprite>("Sprite").Material;
        material.BlendMode = (Godot.CanvasItemMaterial.BlendModeEnum) 0; //BlendMode.BLEND_MODE_ADD;
    }
}
