using Godot;
using System;

public partial class Contents_P_I : Node2D
{
    
    [Export] public Sprite2D PatientSprite;
    [Export] public Label NameLabel;
    [Export] public Label AgeLabel;
    private PatientStats _currentPatient;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        //Hide(); not
        GenerateNewPatient();
    }
   public void _on_reject_pressed()
    {
        GenerateNewPatient();
    }

    private void GenerateNewPatient()
    {
        _currentPatient = new PatientStats();
        
        // Update labels
        NameLabel.Text = $"Patient: {_currentPatient.PatientID}";
        AgeLabel.Text = $"Age: {_currentPatient.Age}";
        
        // Update the tint
        if (PatientSprite != null)
        {
            PatientSprite.Modulate = _currentPatient.Tint;
        }
    }

    private void _on_previous_s_pressed()
{
Hide();
var OfficeScene = (Node2D)GetParent().GetNode("Office");
OfficeScene.Show();
}
// Called every frame. 'delta' is the elapsed time since the previous frame.
public override void _Process(double delta) {
    }
} 
