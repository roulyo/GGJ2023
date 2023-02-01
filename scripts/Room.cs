using Godot;
using System;

public class Room : Node2D
{
    [Signal]
    public delegate void MiniGameStarted();
    [Signal]
    public delegate void MiniGameEnded();

//-------------------------------------------------------------------------
    private void OnOOIObjectPressed()
    {
        (GetNode<Sprite>("BGSprite").Material as ShaderMaterial).SetShaderParam("strength", 4);
        EmitSignal(nameof(MiniGameStarted));
    }

//-------------------------------------------------------------------------
    private void OnOOIObjectReleased()
    {
        (GetNode<Sprite>("BGSprite").Material as ShaderMaterial).SetShaderParam("strength", 0);
        EmitSignal(nameof(MiniGameEnded));
    }
}
