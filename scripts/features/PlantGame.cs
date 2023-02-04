using Godot;
using System;

public class PlantGame : ObjectOfInterestFeature
{
    private Godot.Collections.Array buckets;
    private int numberOfCorrectPlacedBuckets = 0;
    public override void _Ready()
    {
        buckets = GetTree().GetNodesInGroup("bucket");
        GetNode<Label>("Control/Victory").Hide();
        Hide();
    }

//-----------------------------------------------------------------------------
    public void IsGameWon()
    {
        numberOfCorrectPlacedBuckets++;
        if(buckets.Count == numberOfCorrectPlacedBuckets)
        {
            GetNode<Label>("Control/Victory").Show();
        }

    }

//-----------------------------------------------------------------------------
    public void OnCloseButtonPressed()
    {
        RequestClose();
    }
}
