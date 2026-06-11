using Godot;
using System;

public partial class PatientStats : Node
{
    public int heartRate;
    public int skinStatus;

    public string dialogue = "Hello I am a patient";

    public bool isAlive;
    // Called when the node enters the scene tree for the first time.
    public void PatientInitalize()
	{
        GD.Print("random patient info generated");
        isAlive = true;
        Random rnd = new Random();
        heartRate = rnd.Next(50, 151);  // creates a number between 1 and 12
        skinStatus = rnd.Next(1, 6);   // creates a number between 1 and 6
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
