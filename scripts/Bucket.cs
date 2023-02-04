using Godot;

public class Bucket : Sprite
{
    [Signal]
    public delegate void CorrectSpot();

    [Export]
    public string BucketColor;
    private bool selected = false;
    public bool canBeSelected = true;
    public DropZone dropzone;
    private Godot.Collections.Array dropzones;
    private Vector2 StartPosition;

    public override void _Ready()
    {
        dropzones = GetTree().GetNodesInGroup("dropzone");
        StartPosition = GlobalPosition;
        Modulate = Color.ColorN(BucketColor);
    }

    public void OnArea2DInputEvent(Node viewport, InputEvent inputEvent, int shape)
    {
        if(inputEvent.IsActionPressed("click") && canBeSelected)
        {
           selected = true;
        }
    }
//-----------------------------------------------------------------------------
    public override void _PhysicsProcess(float delta)
    {
        //If moving and selected follow the mouse
        if(selected)
        {
            GlobalPosition = GlobalPosition.LinearInterpolate(GetGlobalMousePosition(), 25 * delta);
        }
        //Otherwise put back in the previous dropzone
        else if(dropzone != null && dropzone.GlobalPosition != Vector2.Zero)
        {
            GlobalPosition = GlobalPosition.LinearInterpolate(dropzone.GlobalPosition, 10 * delta);

        }
        //Or back to the intial position
        else if(dropzone == null)
        {
            GlobalPosition = GlobalPosition.LinearInterpolate(StartPosition, 10 * delta);
        }
    }
//-----------------------------------------------------------------------------
    public override void _Input(InputEvent inputEvent)
    {

        if(inputEvent.IsActionReleased("click"))
        {
            float shortestDistance = 50;
            foreach (DropZone zone in dropzones)
            {
                float distance = GlobalPosition.DistanceTo(zone.GlobalPosition);
                if (distance < shortestDistance && !zone.IsOccupied)
                {
                    if(dropzone != null && dropzone.GlobalPosition != zone.GlobalPosition)
                    {
                        dropzone.Deselect();
                    }
                    zone.Select(this);
                    shortestDistance = distance;

                    //Check if the bucket is at the correct spot
                    CheckIfCorrectLocation(this, zone.DropZoneColor);
                }
                else if (distance < shortestDistance && zone.IsOccupied && zone.Bucket.canBeSelected)
                {
                    if(selected)
                    {
                        //Swap old bucket to the old dropzone
                        if(dropzone != null)
                        {
                            dropzone.Select(zone.Bucket);                            
                            //Check if the swapped bucket is now at the correct spot
                            CheckIfCorrectLocation(zone.Bucket, dropzone.DropZoneColor);
                        }
                        //Or back to its original position
                        else 
                        {
                            zone.Bucket.dropzone = null;
                        }

                        //Move current bucket to the desire dropzone
                        zone.Select(this);
                        shortestDistance = distance;

                        //Check if the bucket is at the correct spot
                        CheckIfCorrectLocation(this, zone.DropZoneColor);
                    }
                }
            }
            selected = false;
        }

    }
//-----------------------------------------------------------------------------
    private void CheckIfCorrectLocation(Bucket bucket, string dropzoneColor)
    {
        if(bucket.BucketColor == dropzoneColor)
        {
            bucket.canBeSelected = false;
            EmitSignal(nameof(CorrectSpot));
        }
    }
}
