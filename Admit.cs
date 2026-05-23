using Godot;
using System;

public partial class Admit : Button
{
    // called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Pressed += ButtonPressed;
    }

    private void ButtonPressed()
    {
        Text = "your patient awaits";
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
}