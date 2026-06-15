using Godot;
using System;

public partial class Reject : Button
{
    public override void _Ready()
    {
        // Connect the signal to your local method
        Pressed += ButtonPressed;
    }

    private void ButtonPressed()
    {
        
        var manager = GetParent() as Contents_P_I;

         //check if it exists to avoid crashes
        if (manager != null)
        {
        
            manager._on_reject_pressed();
        }
        else
        {
            GD.Print("Error: Could not find Contents_P_I!");
        }
    }
}