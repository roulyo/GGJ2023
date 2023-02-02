using Godot;
using System;

public class HomeworkGame : ObjectOfInterestFeature
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Hide();
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//
//  }

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
        GD.Print("close");
        RequestClose();
    }
}
