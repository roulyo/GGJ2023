using Godot;
using System;

public class Main : Node2D
{
    private const float MOVE_SPEED_PPS = 1024.0f;

    enum Direction : int
    {
        Left = -1,
        Right = 1
    }

    private Vector2     _screenSize;

    private Node2D[]    _rooms = new Node2D[2];
    private int         _currentRoomIndex = 0;

    private bool        _switching = false;
    private int         _moveDirection = 0;

//-----------------------------------------------------------------------------
    public override void _Ready()
    {
        _screenSize = GetViewportRect().Size;

        _rooms[0] = GetNode<Node2D>("Room_Left");
        _rooms[1] = GetNode<Node2D>("Room_Right");

        _rooms[_currentRoomIndex].Visible = true;
    }

//-----------------------------------------------------------------------------
    public override void _Process(float delta)
    {
        if (_switching)
        {
            UpdateRoomSwitch(delta);
        }
    }

//-----------------------------------------------------------------------------
    private void GoToRoom(Direction direction)
    {
        _switching = true;
        _moveDirection = (int)direction;
        _currentRoomIndex = nimod(_currentRoomIndex + (int)direction, _rooms.Length);
        _rooms[_currentRoomIndex].Visible = true;
        _rooms[_currentRoomIndex].Position = new Vector2(
            x: _screenSize.x * _moveDirection,
            y: 0
        );

        SetMoveButtonEnabled(false);
    }

//-----------------------------------------------------------------------------
    private void UpdateRoomSwitch(float delta)
    {
        int oldRoomIndex = nimod(_currentRoomIndex - _moveDirection, _rooms.Length);
        float xTranslation = MOVE_SPEED_PPS * delta * -_moveDirection;
        bool switchCompleted = false;

        _rooms[oldRoomIndex].MoveLocalX(xTranslation);
        _rooms[_currentRoomIndex].MoveLocalX(xTranslation);

        if (   (_moveDirection > 0 && _rooms[_currentRoomIndex].Position.x < 0)
            || (_moveDirection < 0 && _rooms[_currentRoomIndex].Position.x > 0))
        {
            _rooms[_currentRoomIndex].Position = new Vector2(
                x: 0,
                y: 0
            );
            switchCompleted = true;
        }

        if (switchCompleted)
        {
            _rooms[oldRoomIndex].Visible = false;
            _moveDirection = 0;
            _switching = false;

            SetMoveButtonEnabled(true);
        }
    }

//-----------------------------------------------------------------------------
    private void SetMoveButtonEnabled(bool enabled)
    {
        GetNode<Button>("Control/GoToLeftButton").Disabled = !enabled;
        GetNode<Button>("Control/GoToRightButton").Disabled = !enabled;
    }

//-----------------------------------------------------------------------------
    private void _on_GoToLeftButton_pressed()
    {
        GoToRoom(Direction.Left);
    }

//-----------------------------------------------------------------------------
    private void _on_GoToRightButton_pressed()
    {
        GoToRoom(Direction.Right);
    }

//-----------------------------------------------------------------------------
    private int nimod(float a, float b)
    {
        return (int) (a - b * Math.Floor(a / b));
    }
}
