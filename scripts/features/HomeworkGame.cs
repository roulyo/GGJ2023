using Godot;
using System;

public class HomeworkGame : ObjectOfInterestFeature
{
    public override void _Ready()
    {
        Hide();
    }

//-----------------------------------------------------------------------------
    public void OnLineEditTextEntered(String text)
    {
        if (text == "2")
        {
            GetNode<Label>("Control/Mark").Text = "A+";
            GetNode<Label>("Control/Mark").Show();
            GetNode<LineEdit>("Control/LineEdit").Editable = false;
        }
        else
        {
            GetNode<Label>("Control/Mark").Text = "F";
            GetNode<Label>("Control/Mark").Show();
        }
    }

//-----------------------------------------------------------------------------
    public void OnCloseButtonPressed()
    {
        RequestClose();
    }
}
