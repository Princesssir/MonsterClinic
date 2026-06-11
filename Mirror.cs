using Godot;
using System;

public partial class Mirror : Button
{
    Button MirrorButton;
    Button Close;
    Label MirrorLabel;
    //Button cureButton = GetNode<Button>("Cure");
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        MirrorButton = (Button)this;
        MirrorLabel = GetNode<Label>("MirrorLabel");
        Close = MirrorLabel.GetNode<Button>("Close");
        HideMirrorCloseUp();
        MirrorButton.Pressed += ShowMirrorCloseUp;
        Close.Pressed += HideMirrorCloseUp;

        //Pressed += ButtonPressed;
    }
    
    private void ShowMirrorCloseUp()
    {
        MirrorLabel.Show();
    }

    private void HideMirrorCloseUp()
    {
        MirrorLabel.Hide();
    }
    private void ButtonPressed()
    {
    }
}
