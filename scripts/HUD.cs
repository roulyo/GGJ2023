using Godot;

public class HUD : CanvasLayer
{
    public override void _Ready()
    {
        //Hide the clues
        GetNode<Button>("Control/CluesButton").Hide();
    }

    public void StartGame()
    {
        //Show the clues
        GetNode<Button>("Control/CluesButton").Show();

        //Hide the title
        GetNode<Label>("Control/TitleLabel").Hide();

        //Hide the start button
        GetNode<Button>("Control/StartButton").Hide();

        //Hide the baclground/colorRect
        GetNode<ColorRect>("Control/Background").Hide();
    }

    public void OnStartButtonPressed()
    {
        StartGame();
    }
}
