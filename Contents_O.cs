using Godot;
using System;

public partial class Contents_O : Node
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	private void _on_computer_a_pressed()
	{
		GetTree().ChangeSceneToFile("res://Computer.tscn");
	}
    private void _on_patient_i_a_pressed()
    {
        GetTree().ChangeSceneToFile("res://Patient_Interface.tscn");
    }
    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}
}
