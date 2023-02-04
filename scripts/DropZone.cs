using Godot;
using System;

public class DropZone : Position2D
{
    [Export]
    public string DropZoneColor;
    public bool IsOccupied = false;
    public DragAndDrop Bucket;

    public override void _Draw()
    {
        DrawCircle(Vector2.Zero, 75, Color.ColorN(DropZoneColor));
    }
//-----------------------------------------------------------------------------
    public void Select(DragAndDrop selectedBucket)
    {
        Bucket = selectedBucket;
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
