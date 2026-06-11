using Godot;
using System;

public partial class Mirror_Close_Up : Label
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//Hide();
	}

	private void _on_mirror_pressed()
	{
		//Show();
	}

    private void _on_close_pressed()
    {
       // Hide();
    }


    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}
}
