using Godot;

public class ObjectOfInterest : Node2D
{
    [Signal]
    public delegate void ObjectBusy();
    [Signal]
    public delegate void ObjectAvailable();

    private static bool IsFeatureOpen = false;


//-----------------------------------------------------------------------------
    public override void _Ready()
    {
        var sprite = GetNode<Sprite>("Sprite");
        sprite.Material = (ShaderMaterial) sprite.Material.Duplicate();

        var feature = GetNode<ObjectOfInterestFeature>("Feature");
        feature.Connect(nameof(ObjectOfInterestFeature.CloseFeatureRequest), this, nameof(CloseFeature));

        Connect(nameof(ObjectBusy), GetParent(), nameof(Room.OnOOIObjectBusy));
        Connect(nameof(ObjectAvailable), GetParent(), nameof(Room.OnOOIObjectAvailable));
    }

//-----------------------------------------------------------------------------
    public override void _Input(InputEvent inputEvent)
    {
        if (   !(GetParent() as CanvasItem).Visible
            || (GetParent() as Room).IsSwitching
            || IsFeatureOpen)
            return;

        if(inputEvent is InputEventMouseButton)
        {
            var sprite = GetNode<Sprite>("Sprite");
            if(sprite.IsPixelOpaque(sprite.ToLocal(GetGlobalMousePosition())))
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
                (sprite.Material as ShaderMaterial).SetShaderParam("width", 4.20);
            }
            else
            {
                (sprite.Material as ShaderMaterial).SetShaderParam("width", 0.00);
            }
        }
    }

//-----------------------------------------------------------------------------
    public void CloseFeature()
    {
        //TODO: Be sure to reset the game or not if keeping clue
        IsFeatureOpen = false;
        GetNode<ObjectOfInterestFeature>("Feature").CloseFeature();
        (GetNode<Sprite>("Sprite").Material as ShaderMaterial).SetShaderParam("width", 0.00);
        EmitSignal(nameof(ObjectAvailable));
    }
}
