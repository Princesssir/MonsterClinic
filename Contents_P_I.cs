using Godot;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.JavaScript;

public partial class Contents_P_I : Node2D
{
    // Called when the node enters the scene tree for the first time.
    PatientStats PatientStats;
    [Export] SpeechManager SpeechManagerAccess;

    Button ReturnButton;
    Button DialogueButton;
    Button ZoomButton;
    Button PulseButton;
    Button RejectButton;
    Button InventoryButton;
    Button DiagnosisButton;
    Button ShotgunButton;
    VBoxContainer InventoryContainer;



    [Export] Sprite2D DeceasedSprite1, DeceasedSprite2;

    //List<Func<bool>> GameFunctions = new List<Func<bool>>();
    public override void _Ready()
	{
        Hide();
        GetAllButtons();
        PatientStats = GetNode<PatientStats>("PatientStats");
        if (PatientStats == null)
        {
            GD.Print("Error patient stats not found!!");
        }
        PatientStats.PatientInitalize();

        ReturnButton.Pressed += ReturnToOffice;
        DialogueButton.Pressed += ShowSpeechDialogue;
        ZoomButton.Pressed += ShowSpeechZoom;
        PulseButton.Pressed += ShowSpeechHeartrate;
        RejectButton.Pressed += ShowSpeechReject;
        InventoryButton.Pressed += ToggleInventory;
        DiagnosisButton.Pressed += ShowSpeechDiagnosis;
        ShotgunButton.Pressed += KillPatient;

        DeceasedSprite1.Hide();
        DeceasedSprite2.Hide();
        InventoryContainer.Hide();
    }

    private void GetAllButtons()
    {
        Control control = GetNode<Control>("ControlPatientInterface");
        ReturnButton = control.GetNode<Button>("Return");
        DialogueButton = control.GetNode<Button>("Dialogue");
        ZoomButton = control.GetNode<Button>("Zoom");
        PulseButton = control.GetNode<Button>("Pulse");
        RejectButton = control.GetNode<Button>("Reject");
        InventoryButton = control.GetNode<Button>("Inventory");

        InventoryContainer = control.GetNode<VBoxContainer>("InventoryContainer");
        DiagnosisButton = InventoryContainer.GetNode<Button>("Diagnosis");
        ShotgunButton = InventoryContainer.GetNode<Button>("Shotgun");
    }
    private void ShowSpeechDialogue()
    {
        SpeechManagerAccess.SpeechText(PatientStats.dialogue);
    }
    private void ShowSpeechReject()
    {
        SpeechManagerAccess.SpeechText("Patient has left");
    }

    private void ShowSpeechZoom()
    {
        SpeechManagerAccess.SpeechText("Skin status is: " + PatientStats.skinStatus);
    }

    private void ShowSpeechHeartrate()
    {
        SpeechManagerAccess.SpeechText("Heart rate is: " + PatientStats.heartRate);
    }

    private void ShowSpeechDiagnosis()
    {
        SpeechManagerAccess.SpeechText("soooo, you are telling me \n THAT is gonna help you diagnose me??");
    }

    private void ToggleInventory()
    {
        InventoryContainer.Visible = !InventoryContainer.Visible;
    }

    private void KillPatient()
    {
        DeceasedSprite1.Show();
        DeceasedSprite2.Show();
    }
    
    private void ReturnToOffice()
    {
        //when leaving the room, hide it, show the office, and pop the room off the previous scenes stack, to not interfere with the right click functionality
        Hide();
        var OfficeScene = (Node2D)GetParent().GetNode("Office");
        OfficeScene.Show();
        GlobalData.PreviousScenes.Pop();
    }
}
