using Godot;

public class ObjectOfInterest : Node2D
{
    [Signal]
    public delegate void ObjectBusy();
    [Signal]
    public delegate void ObjectAvailable();

    private bool IsFeatureOpen = false;

//-----------------------------------------------------------------------------
    public override void _Input(InputEvent inputEvent)
    {
        if (   !(GetParent() as CanvasItem).Visible
            || (GetParent() as Room).IsSwitching)
            return;

        if(inputEvent is InputEventMouseButton)
        {
            var sprite = GetNode<Sprite>("Sprite");
            if(sprite.IsPixelOpaque(sprite.ToLocal(GetGlobalMousePosition())) && !IsFeatureOpen)
            {
                GetTree().SetInputAsHandled();
                if(inputEvent.IsActionPressed("click"))
                {
                    IsFeatureOpen = true;

                    var feature = GetNode<ObjectOfInterestFeature>("Feature");
                    var featureSizeX = feature.GetSize().x;
                    var featureSizeY = feature.GetSize().y;
                    feature.GlobalPosition = new Vector2(GetViewportRect().Size.x/2-featureSizeX/2 , GetViewportRect().Size.y/2-featureSizeY/2);
                    feature.OpenFeature();

                    EmitSignal(nameof(ObjectBusy));
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
    public void CloseFeature()
    {
        //TODO: Be sure to reset the game or not if keeping clue
        IsFeatureOpen = false;
        GetNode<ObjectOfInterestFeature>("Feature").CloseFeature();

        EmitSignal(nameof(ObjectAvailable));
    }
}
