using Godot;

public class ObjectOfInterest : Area2D
{
    [Signal]
    public delegate void ObjectBusy();
    [Signal]
    public delegate void ObjectAvailable();

    [Export]
    public bool IsMiniGame;

    [Export]
    public string ObjectOfInterestContext;

    private bool IsMiniGameOpen = false;

//-----------------------------------------------------------------------------
    public override void _Input(InputEvent inputEvent)
    {
        if (   !(GetParent() as CanvasItem).Visible
            || (GetParent() as Room).IsSwitching)
            return;

        if(inputEvent is InputEventMouseButton)
        {
            var sprite = GetNode<Sprite>("Sprite");
            if(sprite.IsPixelOpaque(sprite.ToLocal(GetGlobalMousePosition())) && !IsMiniGameOpen)
            {
                GetTree().SetInputAsHandled();
                if(inputEvent.IsActionPressed("click"))
                {
                    IsMiniGameOpen = true;
                    var miniGame = GetNode<MiniGame>("MiniGame");
                    var miniGameSizeX = miniGame.GetNode<ColorRect>("ColorRect").RectSize.x;
                    var miniGameSizeY = miniGame.GetNode<ColorRect>("ColorRect").RectSize.y;
                    miniGame.GlobalPosition = new Vector2(GetViewportRect().Size.x/2-miniGameSizeX/2 , GetViewportRect().Size.y/2-miniGameSizeY/2);
                    miniGame.OpenGameCanvas();

                        EmitSignal(nameof(ObjectBusy));
                    }
                    else if(!IsMiniGame)
                    {
                        var textWindow = GetNode<Node2D>("ObjectOfInterestContext");
                        var textWindowX = textWindow.GetNode<ColorRect>("ColorRect").RectSize.x;
                        var textWindowY = textWindow.GetNode<ColorRect>("ColorRect").RectSize.y;
                        textWindow.GlobalPosition = new Vector2(GetViewportRect().Size.x/2-textWindowX/2 , GetViewportRect().Size.y/2-textWindowY/2);
                        textWindow.Show();

                        EmitSignal(nameof(ObjectBusy));
                    }

                }
            }
        }
        else if(inputEvent is InputEventMouseMotion)
        {
            var sprite = GetNode<Sprite>("Sprite");
            if(sprite.IsPixelOpaque(sprite.ToLocal(GetGlobalMousePosition())))
            {
                (GetNode<Sprite>("Sprite").Material as ShaderMaterial).SetShaderParam("width", 4.20);
            }
            else
            {
                (GetNode<Sprite>("Sprite").Material as ShaderMaterial).SetShaderParam("width", 0.00);
            }
        }
    }
//-----------------------------------------------------------------------------
    public void CloseMiniGame()
    {
        //TODO: Be sure to reset the game or not if keeping clue
        IsMiniGameOpen = false;
        GetNode<MiniGame>("MiniGame").CloseGameCanvas();

        EmitSignal(nameof(ObjectAvailable));
    }
//-----------------------------------------------------------------------------
    public void CloseContextDialogue()
    {
        GetNode<Node2D>("ObjectOfInterestContext").Hide();

        EmitSignal(nameof(ObjectAvailable));
    }
}
