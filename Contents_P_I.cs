using Godot;
using System;
using System.Collections.Generic;

public partial class Contents_P_I : Node2D
{
    // Called when the node enters the scene tree for the first time.
    PatientStats PatientStats;
    [Export] SpeechManager SpeechManagerAccess;

    [Export] Button DialogueButton;
    [Export] Button ZoomButton;
    [Export] Button PulseButton;
    [Export] Button DiagnosisButton;
    [Export] Button InventoryButton;
    [Export] Button ShotgunButton;
    [Export] VBoxContainer InventoryContainer;
    [Export] Sprite2D DeceasedSprite1, DeceasedSprite2;

    //List<Func<bool>> GameFunctions = new List<Func<bool>>();
    public override void _Ready()
	{
        Hide();
        PatientStats = GetNode<PatientStats>("PatientStats");
        if (PatientStats == null)
        {
            GD.Print("Error patient stats not found!!");
        }
        PatientStats.PatientInitalize();
        DialogueButton.Pressed += ShowSpeechDialogue;
        ZoomButton.Pressed += ShowSpeechZoom;
        PulseButton.Pressed += ShowSpeechHeartrate;
        DiagnosisButton.Pressed += ShowSpeechDiagnosis;
        InventoryButton.Pressed += ToggleInventory;
        ShotgunButton.Pressed += KillPatient;
        DeceasedSprite1.Hide();
        DeceasedSprite2.Hide();
        ToggleInventory();
        
	}

    private void ShowSpeechDialogue()
    {
        SpeechManagerAccess.SpeechText(PatientStats.dialogue);
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
        
    private void _on_previous_s_pressed()
    {
        //when leaving the room, hide it, show the office, and pop the room off the previous scenes stack, to not interfere with the right click functionality
        Hide();
        var OfficeScene = (Node2D)GetParent().GetNode("Office");
        OfficeScene.Show();
        GlobalData.PreviousScenes.Pop();
    }
    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}
}
