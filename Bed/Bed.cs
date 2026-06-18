using Godot;
using System;


public partial class Bed : Node2D
{
    private RichTextLabel DaysCounter;
    private RichTextLabel MoneyEarned;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {


        Hide();



    }

    private void _on_visibility_changed()
    {
        SaveSystem.Save_Days();

        var DaysCounter = GetNode<RichTextLabel>("Day");
        DaysCounter.BbcodeEnabled = true;
        DaysCounter.Text = $"[b][font_size=130] {GlobalData.Player_Ingame_Days} days in containment [/font_size][/b]";

        var MoneyEarned = GetNode<RichTextLabel>("MoneyEarned");
        MoneyEarned.BbcodeEnabled = true;
        MoneyEarned.Text = "Today's earnings: " + GlobalData.DailyEarnings;

        var DaysCounters = GetNode<RichTextLabel>("TreatmentDays");
        DaysCounters.BbcodeEnabled = true;

        if (GlobalData.Countdown >= 3)
        {
            DaysCounters.Text = $"[b][font_size=110]{GlobalData.Countdown} days left without treatment[/font_size][/b]";
        }
        else if (GlobalData.Countdown >= 1 && GlobalData.Countdown < 3)
        {
            DaysCounters.Text = $"[b][font_size=110][shake rate=50][color=DEEP_PINK]{GlobalData.Countdown} days left without treatment [/color][/shake][/font_size][/b]";
        }
        else if (GlobalData.Countdown == 0)
        {
            DaysCounters.Text = $"[b][font_size=110][shake rate=200][wave rate=20][color=red]{GlobalData.Countdown} days left without treatment [/color][/wave][/shake][/font_size][/b]";
        }
        else
        {
            //Scene changed to the death Screen, The reasion can be also set in the Global autoload, so you can change the reasion for the death screen, depending on how the player died
            GlobalData.Reasion = "Your sickness killed you! Keep an eye on your treatment countdown";
            GetTree().ChangeSceneToFile("res://DeathScreen/death_screen.tscn");
        }

        if (GlobalData.MedicinePlayer >= 1)
        {
            GlobalData.Dialog_Dealer = true;
        }

    }

    
    


}
