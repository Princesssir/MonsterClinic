using Godot;
using System;

public partial class Bed_Time : Label
{
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Hide();
    }

    //now also shows the earnings for the day
    private void _on_bed_pressed()
    {
        Show();
        Text = "Eepy time :) \n \n Today's earnings: " + GlobalData.DailyEarnings;
    }

    //adds the dat's earnings to your money, and resets daily earnings to 0
    private void _on_close_pressed()
    {
        GlobalData.Money += GlobalData.DailyEarnings;
        GlobalData.DailyEarnings = 0;
        Hide();
    }


    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
}
