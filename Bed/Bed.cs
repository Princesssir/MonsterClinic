using Godot;
using System;
using global;

public partial class Bed : Node2D
{
    private RichTextLabel DaysCounter;
    private Timer sceneTimer;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        // getting the information for the days from the DayManager
        var day_M = GetNode<DayManager>("/root/DayManager");
        day_M.Player_Ingame_Days++;

        //setting the RichTextLabel up, heigth the font size 130 and big, therefore BbcodeEnabled needs to be true
        DaysCounter = GetNode<RichTextLabel>("Day");
        DaysCounter.BbcodeEnabled = true;
        DaysCounter.Text = $"[b][font_size=130] {day_M.Player_Ingame_Days} days in containment [/font_size][/b]";

        // Timer from the scene
        var sceneTimer = GetNode<Timer>("ChangeToOffice_Timer");

        // connect the signals
        sceneTimer.Timeout += OnSceneTimerTimeout;

        // timer is getting set to 3 seconds and starts
        sceneTimer.Start(3.0);


        // the treatment countdown gets his information from the Global autoload. It is different than from the Daymanager, because Global has the namespace global which is gets set in the upper code (almost the first thing) and then you can call the class Variable and the integer
        Variables.Treatment_Countdown--;

        // setting the RichTextLabel up, to customize it like up there before BbcodeEnabled needs to be true. The frontSize is 110, the text is big.
        DaysCounter = GetNode<RichTextLabel>("TreatmentDays");
        DaysCounter.BbcodeEnabled = true;

        // here is the Text chaning a little bit, with the color (pink and red) and "Animation". the Text will shake and be a little wavy. The treatment Countdown decides which text will be showned to the player
        if (Variables.Treatment_Countdown >= 3)
        {
            DaysCounter.Text = $"[b][font_size=110]{Variables.Treatment_Countdown} days left without treatment[/font_size][/b]";
        }
        else if (Variables.Treatment_Countdown >= 1 && Variables.Treatment_Countdown < 3)
        {
            DaysCounter.Text = $"[b][font_size=110][shake rate=50][color=DEEP_PINK]{Variables.Treatment_Countdown} days left without treatment [/color][/shake][/font_size][/b]";
        }
        else if (Variables.Treatment_Countdown == 0)
        {
            DaysCounter.Text = $"[b][font_size=110][shake rate=200][wave rate=20][color=red]{Variables.Treatment_Countdown} days left without treatment [/color][/wave][/shake][/font_size][/b]";
        }
        else
        {
            //i did comment it out, because i need to do the malady cathalog, but the deathscreen should be later be connected and direct the player to the mainscreen
            // GetTree().ChangeSceneToFile(res://Death_screens/death_screen.tscn);
        }





    }

    private void OnSceneTimerTimeout()
    {
        // switching scenes
        GetTree().ChangeSceneToFile("res://Office.tscn");
    }


    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
}
