using Godot;
using System;

public class ObjectOfInterest : Area2D
{
    [Signal]
    public delegate void ObjectPressed();
    [Signal]
    public delegate void ObjectReleased();

//-----------------------------------------------------------------------------
    private void _on_Area2D_mouse_entered()
    {
        (GetNode<Sprite>("Sprite").Material as ShaderMaterial).SetShaderParam("width", 4.20);
    }

//-----------------------------------------------------------------------------
    private void _on_Area2D_mouse_exited()
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
