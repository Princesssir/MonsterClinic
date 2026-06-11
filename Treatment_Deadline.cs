using Godot;
using System;

public partial class Treatment_Deadline : Button
{
    Button Deadline;
	Button Close;
	Label DeadlineLabel;
    //Button cureButton = GetNode<Button>("Cure");
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
        Deadline = (Button)this;
        DeadlineLabel = GetNode<Label>("DeadlineLabel");
        Close = DeadlineLabel.GetNode<Button>("Close");
        HideDeadline();
        Deadline.Pressed += ShowDeadline;
        Close.Pressed += HideDeadline;
    }
    
    private void ShowDeadline()
    {
        DeadlineLabel.Show();
        if (GlobalData.Countdown > 1)
        {
            DeadlineLabel.Text = String.Format("If you don't get treatment in {0} days, \n you'll be in real trouble", GlobalData.Countdown);
        }
        else if (GlobalData.Countdown == 1)
        {
            DeadlineLabel.Text = "If you don't get treatment within the next day, \n you'll be in real trouble";
        }
        else
        {
            DeadlineLabel.Text = "Time's up! If this wasn't a prototype, \n you'd already be gone...";
        }
    }

    private void HideDeadline()
	{
		DeadlineLabel.Hide();
    }
}
