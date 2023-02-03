using Godot;
using System;

public class PlantGame : ObjectOfInterestFeature
{
    public override void _Ready()
    {
        Hide();
    }

//-----------------------------------------------------------------------------
    public void OnCloseButtonPressed()
    {
        RequestClose();
    }
}
