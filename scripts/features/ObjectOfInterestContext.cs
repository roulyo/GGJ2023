public class ObjectOfInterestContext : ObjectOfInterestFeature
{
    public override void _Ready()
    {
        Hide();
    }

//-----------------------------------------------------------------------------
    public void OnCloseContextPressed()
    {
        RequestClose();
    }
}