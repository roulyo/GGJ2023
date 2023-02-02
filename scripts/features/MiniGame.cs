using Godot;

public class MiniGame : ObjectOfInterestFeature
{
    public override void _Ready()
    {
        Hide();
        HideGame();
    }

    public void StartGame()
    {
        //Hide the HUD
        GetNode<Button>("MiniGameHUD/StartButton").Hide();
        GetNode<Button>("MiniGameHUD/CloseButton").Hide();

        //Show the "game"
        ShowGame();
        GetNode<Label>("MiniGameHUD/Message").Text = "Click to win!";
    }

    public void ShowGame()
    {
        GetNode<Button>("MiniGameHUD/WinButton").Show();
        GetNode<Button>("MiniGameHUD/LoseButton").Show();
    }

    public void HideGame()
    {
        GetNode<Button>("MiniGameHUD/WinButton").Hide();
        GetNode<Button>("MiniGameHUD/LoseButton").Hide();
    }

    public void OnStartButtonPressed()
    {
        StartGame();
    }

    public void OnCloseButtonPressed()
    {
        RequestClose();
    }

    public void OnWinButtonPressed()
    {
        GetNode<Label>("MiniGameHUD/Message").Text = "Your clue is 'I love you.'!";
        HideGame();
        GetNode<Button>("MiniGameHUD/CloseButton").Show();
    }

    public void OnLoseButtonPressed()
    {
        GetNode<Label>("MiniGameHUD/Message").Text = "Try again?";
        HideGame();

        GetNode<Button>("MiniGameHUD/StartButton").Show();
        GetNode<Button>("MiniGameHUD/CloseButton").Show();
    }
}
