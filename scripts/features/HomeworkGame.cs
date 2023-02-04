using Godot;
using System;

public class HomeworkGame : ObjectOfInterestFeature
{
    public override void _Ready()
    {
        GetNode<Label>("Control/Clue").Text = (GetParent() as ObjectOfInterestFeature).Clue;
        GetNode<Label>("Control/Clue").Hide();
        Hide();
    }

//-----------------------------------------------------------------------------
    public void OnLineEditTextEntered(String text)
    {
        if (text == "2")
        {
            GetNode<Label>("Control/Mark").Text = "A+";
            GetNode<Label>("Control/Mark").Show();
            GetNode<Label>("Control/Clue").Show();
            GetNode<LineEdit>("Control/LineEdit").Editable = false;
            MiniGameWon((GetParent() as ObjectOfInterestFeature).Clue);
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
