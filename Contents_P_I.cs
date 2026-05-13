using Godot;
using System;

public partial class Contents_P_I : Node
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}
    private void _on_previous_s_pressed()
    {
        GetTree().ChangeSceneToFile("res://Office.tscn");
    }
    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}
}
