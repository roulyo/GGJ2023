using Godot;
using System;

public class Main : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

//#pragma warning disable 649
    private CanvasItem[] _rooms = new CanvasItem[2];
    private int _currentRoomIndex = 0;
//#pragma warning restore 649

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _rooms[0] = GetNode<CanvasItem>("Room_Left");
        _rooms[1] = GetNode<CanvasItem>("Room_Right");

        _rooms[_currentRoomIndex].Visible = true;
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//
//  }

//-----------------------------------------------------------------------------
    private void GoToLeftRoom()
    {
        _rooms[_currentRoomIndex].Visible = false;
        _currentRoomIndex = nimod(--_currentRoomIndex, _rooms.Length);
        _rooms[_currentRoomIndex].Visible = true;
    }

//-----------------------------------------------------------------------------
    private void GoToRightRoom()
    {
        _rooms[_currentRoomIndex].Visible = false;
        _currentRoomIndex = nimod(++_currentRoomIndex, _rooms.Length);
        _rooms[_currentRoomIndex].Visible = true;
    }

//-----------------------------------------------------------------------------
    private void _on_GoToLeftButton_pressed()
    {
        GoToLeftRoom();
    }

//-----------------------------------------------------------------------------
    private void _on_GoToRightButton_pressed()
    {
        GoToRightRoom();
    }

//-----------------------------------------------------------------------------
    private int nimod(float a, float b)
    {
        return (int) (a - b * Math.Floor(a / b));
    }
}
