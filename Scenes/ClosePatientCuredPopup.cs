using Godot;
using System;

public partial class ClosePatientCuredPopup : Button
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Pressed += ButtonPressed;
	}

	//closing the popup removes the patient from the room, and resets the current patient malady data to the defaults
	private void ButtonPressed()
	{
		var patient = GetParent().GetParent().GetParent().GetNode<Node2D>("Patient_Display");
		var patientInfo = GetParent().GetParent().GetParent().GetNode<CanvasItem>("Patient_Info");

		patient.Hide();
		patientInfo.Hide();

		GlobalData.CurrentPatientMalady = "none";
		GlobalData.CurrentPatientSeverity = 0;
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
