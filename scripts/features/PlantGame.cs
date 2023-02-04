using Godot;

public class PlantGame : ObjectOfInterestFeature
{
    private Godot.Collections.Array buckets;
    private int numberOfCorrectPlacedBuckets = 0;
    public override void _Ready()
    {
        buckets = GetTree().GetNodesInGroup("bucket");

        GetNode<Label>("Control/Victory").Hide();

        GetNode<Label>("Control/Clue").Text = (GetParent() as ObjectOfInterestFeature).Clue;
        GetNode<Label>("Control/Clue").Hide();
        
        Hide();
    }

//-----------------------------------------------------------------------------
    public void IsGameWon()
    {
        numberOfCorrectPlacedBuckets++;
        if(buckets.Count == numberOfCorrectPlacedBuckets)
        {
            GetNode<Label>("Control/Victory").Show();
            GetNode<Label>("Control/Clue").Show();
            MiniGameWon((GetParent() as ObjectOfInterestFeature).Clue);
        }
    }

//-----------------------------------------------------------------------------
    public void OnCloseButtonPressed()
    {
        RequestClose();
    }
}
