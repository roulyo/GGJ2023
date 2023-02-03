using Godot;
using System;

public class DragAndDrop : Node2D
{
    private bool selected = false;

    public void OnArea2DInputEvent(Node viewport, InputEvent inputEvent, int shape)
    {
        if(inputEvent.IsActionPressed("click"))
        {
           selected = true;
        }
    }

//-----------------------------------------------------------------------------
    public override void _PhysicsProcess(float delta)
    {
        if(selected)
        {
            GlobalPosition = GlobalPosition.LinearInterpolate(GetGlobalMousePosition(), 15 * delta);
        }
    }

//-----------------------------------------------------------------------------
    public override void _Input(InputEvent inputEvent)
    {

        if(inputEvent.IsActionReleased("click"))
        {
            selected = false;
        }

    }
}
