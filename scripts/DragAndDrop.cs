using Godot;
using System;

public class DragAndDrop : Node2D
{
    private bool selected = false;
    private DropZone dropzone;
    private Godot.Collections.Array dropzones;

    public override void _Ready()
    {
        dropzones = GetTree().GetNodesInGroup("dropzone");
        GD.Print(dropzone);
    }

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
            GlobalPosition = GlobalPosition.LinearInterpolate(GetGlobalMousePosition(), 25 * delta);
        }
        else if(dropzone != null && dropzone.GlobalPosition != Vector2.Zero)
        {
            GlobalPosition = GlobalPosition.LinearInterpolate(dropzone.GlobalPosition, 10 * delta);

        }
    }
//-----------------------------------------------------------------------------
    public override void _Input(InputEvent inputEvent)
    {

        if(inputEvent.IsActionReleased("click"))
        {
            selected = false;
            float shortestDistance = 75;
            foreach (DropZone zone in dropzones)
            {
                float distance = GlobalPosition.DistanceTo(zone.GlobalPosition);
                if (distance < shortestDistance && !zone.IsOccupied)
                {
                    if(dropzone != null && dropzone.GlobalPosition != zone.GlobalPosition)
                    {
                        dropzone.Deselect();
                    }
                    zone.Select();
                    dropzone = zone;
                    shortestDistance = distance;
                }

            }
        }

    }
}
