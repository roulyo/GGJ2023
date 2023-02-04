using Godot;

public class Icon : Control
{
    [Signal]
    public delegate void DoubleClick(int index);

    public int Index;

//-----------------------------------------------------------------------------
    public override void _Input(InputEvent inputEvent)
    {
        if (inputEvent is InputEventMouseButton)
        {
            InputEventMouseButton mouseEvent = inputEvent as InputEventMouseButton;

            if (mouseEvent.IsPressed() && mouseEvent.Doubleclick)
            {
                Button folderIcon = GetNode<Button>("FolderIcon");
                Button icon = folderIcon.Visible ? folderIcon : GetNode<Button>("FileIcon");
                Rect2 rect = icon.GetGlobalRect();
                rect.Size *= icon.RectScale;

                if (rect.HasPoint(mouseEvent.GlobalPosition))
                {
                    EmitSignal(nameof(DoubleClick), Index);
                }
            }
        }
    }
}
