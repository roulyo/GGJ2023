using Godot;
using System;

public class Room : Node2D
{
    [Signal]
    public delegate void MiniGameStarted();
    [Signal]
    public delegate void MiniGameEnded();

    public bool IsSwitching = false;

//-------------------------------------------------------------------------
    public void OnOOIObjectBusy()
    {
        (GetNode<Sprite>("BGSprite").Material as ShaderMaterial).SetShaderParam("strength", 4);
        EmitSignal(nameof(MiniGameStarted));
    }

//-------------------------------------------------------------------------
    public void OnOOIObjectAvailable()
    {
        (GetNode<Sprite>("BGSprite").Material as ShaderMaterial).SetShaderParam("strength", 0);
        EmitSignal(nameof(MiniGameEnded));
    }
}
