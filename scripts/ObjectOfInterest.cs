using Godot;

public class ObjectOfInterest : Area2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//
//  }

//-----------------------------------------------------------------------------
    private void _on_Area2D_mouse_entered()
    {
        CanvasItemMaterial material = (CanvasItemMaterial)GetNode<Sprite>("Sprite").Material;
        material.BlendMode = (Godot.CanvasItemMaterial.BlendModeEnum) 1;
    }

//-----------------------------------------------------------------------------
    private void _on_Area2D_mouse_exited()
    {
        CanvasItemMaterial material = (CanvasItemMaterial)GetNode<Sprite>("Sprite").Material;
        material.BlendMode = (Godot.CanvasItemMaterial.BlendModeEnum) 0; //BlendMode.BLEND_MODE_ADD;
    }
}
