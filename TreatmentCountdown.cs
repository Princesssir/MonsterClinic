using Godot;
using System;

public partial class TreatmentCountdown : Label
{

    int Countdown = 4;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Hide();
    }

    private void _on_treatment_ds_pressed()
    {
        Show();
        if (Countdown > 1)
        {
            Text = String.Format("If you don't get treatment in {0} days, \n you'll be in real trouble", Countdown);
        } else if (Countdown == 1)
        {
            Text = "If you don't get treatment within the next day, \n you'll be in real trouble";
        } else
        {
            Text = "Time's up! If this wasn't a prototype, \n you'd already be gone...";
        }
    }

    private void _on_close_pressed()
    {
        Hide();
    }

    private void _on_time_passed()
    {
        if (Countdown > 0)
        {
            Countdown--;
        }
    }


    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
}
