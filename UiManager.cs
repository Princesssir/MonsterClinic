using Godot;
using System;

public partial class UiManager : Node
{
	[Export] Button DeadlineButton;
    [Export] Label myLabel;

    public override void _Ready()
    {
        DeadlineButton.Pressed += ZazaBinx;
       // myLabel.Show();
    }

    private void ZazaBinx()
    {
        GD.Print("zaza binx");
    }
}
