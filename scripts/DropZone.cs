using Godot;
using System;

public class DropZone : Position2D
{
    [Export]
    public string DropZoneColor;
    public bool IsOccupied = false;

    public override void _Draw()
    {
        DrawCircle(Vector2.Zero, 75, Color.ColorN(DropZoneColor));
    }
//-----------------------------------------------------------------------------
    public void Select()
    {
        // foreach (DropZone child in GetTree().GetNodesInGroup("dropzone"))
        // {
        //     if(!child.IsOccupied)
        //     {
        //         child.Deselect();
        //     }
        // }
        IsOccupied = true;
        Modulate = Color.ColorN(DropZoneColor, 0.5f);
    }
//-----------------------------------------------------------------------------
    public void Deselect()
    {
        IsOccupied = false;
        Modulate = Color.ColorN(DropZoneColor);
    }
}
