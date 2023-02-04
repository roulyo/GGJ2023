using Godot;

public class DropZone : Position2D
{
    [Export]
    public string DropZoneColor;
    public bool IsOccupied = false;
    public Bucket Bucket;

    public override void _Draw()
    {
        DrawCircle(Vector2.Zero, 50, Color.ColorN(DropZoneColor));
    }
//-----------------------------------------------------------------------------
    public void Select(Bucket selectedBucket)
    {
        Bucket = selectedBucket;
        Bucket.dropzone = this;
        IsOccupied = true;
        Modulate = Color.ColorN(DropZoneColor, 0.5f);
    }
//-----------------------------------------------------------------------------
    public void Deselect()
    {
        Bucket = null;
        IsOccupied = false;
        Modulate = Color.ColorN(DropZoneColor);
    }
}
