using Godot;
using System;


public partial class Bed : Node2D
{
    private RichTextLabel DaysCounter;
    private RichTextLabel MoneyEarned;
 
    [Export] PackedScene Transition = ResourceLoader.Load<PackedScene>("res://fade_animation.tscn");
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        

        Hide();
        // getting the information for the days from the DayManager
        var day_M = GetNode<DayManager>("/root/DayManager");
        //day_M.Player_Ingame_Days++;

        //setting the RichTextLabel up, heigth the font size 130 and big, therefore BbcodeEnabled needs to be true
        var DaysCounter = GetNode<RichTextLabel>("Day");
        DaysCounter.BbcodeEnabled = true;
        DaysCounter.Text = $"[b][font_size=130] {day_M.Player_Ingame_Days} days in containment [/font_size][/b]";

        var MoneyEarned = GetNode<RichTextLabel>("MoneyEarned");
        MoneyEarned.BbcodeEnabled = true;
        MoneyEarned.Text = "Today's earnings: " + GlobalData.DailyEarnings;
        DoctorInventory.Money += GlobalData.DailyEarnings;
        GlobalData.DailyEarnings = 0;

    }

    private void _on_visibility_changed()
    {
        // i use a int, some how it worked better than a boolean
        if (GlobalData.ControlSpawnFading == 1)
        {
            
            // get the GridContainer, so the text dont get covered from the FadeAnimation. FadeAnimation gets added to the GridContainer
            var spawn = GetNode<GridContainer>("Spawn");
            var fading = Transition.Instantiate<FadeAnimation>();
            spawn.AddChild(fading);

            // calls the Methode Fades from the FadeAnimation
            fading.Fades();

            // Conditon Changes
            GlobalData.Fading = true;
            // Control for the spawn FadeAnimation
            GlobalData.ControlSpawnFading = 2;
        }
       


        var day_M = GetNode<DayManager>("/root/DayManager");

        var DaysCounter = GetNode<RichTextLabel>("Day");
        DaysCounter.BbcodeEnabled = true;
        DaysCounter.Text = $"[b][font_size=130] {day_M.Player_Ingame_Days} days in containment [/font_size][/b]";

        var MoneyEarned = GetNode<RichTextLabel>("MoneyEarned");
        MoneyEarned.BbcodeEnabled = true;
        MoneyEarned.Text = "Today's earnings: " + GlobalData.DailyEarnings;

        var DaysCounters = GetNode<RichTextLabel>("TreatmentDays");
        DaysCounters.BbcodeEnabled = true;
        // FadeAnimation en = GetNode<FadeAnimation>("res://FadeAnimation.cs");

        GlobalData.Fading = false;

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
        else if(GlobalData.MedicinePlayer == 0 && GlobalData.Countdown == 0)
        {
            //Scene changed to the death Screen, The reasion can be also set in the Global autoload, so you can change the reasion for the death screen, depending on how the player died
            GlobalData.Reasion = "Your sickness killed you! Keep an eye on your treatment countdown";
            GetTree().ChangeSceneToFile("res://DeathScreen/death_screen.tscn");
        }

        if (GlobalData.MedicinePlayer >= 1)
        {
            GlobalData.Dialog_Dealer = true;
            GlobalData.MedicinePlayer--;
        }

    }}

    



