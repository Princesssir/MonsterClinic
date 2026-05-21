using Godot;

public partial class Room : Node2D 
{
    [Export] public Sprite2D PatientDisplay;

    
    public override void _EnterTree()
    {
        
        VisibilityChanged += OnVisibilityChanged;
    }

    private void OnVisibilityChanged()
    {
        
        if (IsVisibleInTree())
        {
            if (global.Variables.AdmittedPatientTexture != null)
            {
                PatientDisplay.Texture = global.Variables.AdmittedPatientTexture;
                PatientDisplay.Show();
            }
            else
            {
                PatientDisplay.Hide();
            }
        }
    }
}