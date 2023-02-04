using Godot;

public class ObjectOfInterestFeature : Node2D
{
#pragma warning disable 649
    [Export]
    public PackedScene Feature;
#pragma warning restore 649

    [Export]
    public string Clue;

    [Signal]
    public delegate void UpdateCluesRequest(string clue);

    [Signal]
    public delegate void CloseFeatureRequest();

    private ObjectOfInterestFeature _feature = null;

    public override void _Ready()
    {
        SetAsToplevel(true);
        _feature = (ObjectOfInterestFeature) Feature.Instance();
        AddChild(_feature);
    }

    public void OpenFeature()
    {
        _feature.Show();
    }

    public void CloseFeature()
    {
        _feature.Hide();
    }

    public Vector2 GetSize()
    {
        return _feature.GetNode<ColorRect>("ColorRect").RectSize;
    }

    protected void RequestClose()
    {
        (GetParent() as ObjectOfInterestFeature).EmitSignal(nameof(CloseFeatureRequest));
    }

    protected void MiniGameWon(string clue)
    {
        (GetParent() as ObjectOfInterestFeature).EmitSignal(nameof(UpdateCluesRequest), clue);
    }
}
