using Godot;
using System;
using System.Threading.Tasks;

public partial class Contents_O : Node2D
{
    [Export] public FadeAnimation F;
    private Timer sceneTimer;
    [Export] PackedScene dealer_selftreatment_dialog = ResourceLoader.Load<PackedScene>("res://dialog.tscn");
    [Export] PackedScene Transition = ResourceLoader.Load<PackedScene>("res://fade_animation.tscn");
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{

    }

    private void _on_computer_a_pressed()
	{

		Hide();
		var ComputerScene = (Node2D)GetParent().GetNode("Computer");
		ComputerScene.Show();
        //push the scene we're entering to the previous scenes stack
        GlobalData.PreviousScenes.Push(ComputerScene.GetPath());
	}
    private void _on_patient_i_a_pressed()
    {

        Hide();
        var PatientScene = (Node2D)GetParent().GetNode("Patient_Interface");
        PatientScene.Show();
        //push the scene we're entering to the previous scenes stack
        GlobalData.PreviousScenes.Push(PatientScene.GetPath());
    }

	private void _on_elevator_pressed()
	{
		Hide();
        var RoomScene = (Node2D)GetParent().GetNode("Room");
        RoomScene.Show();
        //push the scene we're entering to the previous scenes stack
        GlobalData.PreviousScenes.Push(RoomScene.GetPath());
    }
    private void _on_bed_pressed()
    {
        GlobalData.ControlSpawnFading = 1;
        Hide();
        // F.Fades();
        var day_M = GetNode<DayManager>("/root/DayManager");
        day_M.Player_Ingame_Days++;
        DoctorInventory.Money += GlobalData.DailyEarnings;
        GlobalData.Countdown--;
        var BedScene = (Node2D)GetParent().GetNode("Bed");
        BedScene.Show();
        GlobalData.Fading = false;
        
        //push the scene we're entering to the previous scenes stack
        GlobalData.PreviousScenes.Push(BedScene.GetPath());

        // Timer from the scene


        //F.Fades();
        
        var sceneTimer = GetNode<Timer>("ChangeToBed_Timer");
        sceneTimer.OneShot = true;

        // connect the signals
        
        sceneTimer.Timeout += OnSceneTimerTimeout;

       
        //FadeAnimation g = GetNode<FadeAnimation>("FadeAnimation.cs");
        //g.Fades();
        // timer is getting set to 3 seconds and starts
        sceneTimer.Start(3.0);
        
        GlobalData.Medicincavailability--;
    }
    
    private void OnSceneTimerTimeout()
    {
        // instantiate the scene FadeAnimation
        var s = Transition.Instantiate<FadeAnimation>();

        // Daily earnings gets reseted
        GlobalData.DailyEarnings = 0;

        // get node bed scene
        var BedScene = (Node2D)GetParent().GetNode("Bed");

        // Condition Changes
        GlobalData.Fading = true;

        // condition for the Controled Spawn
        if(GlobalData.ControlSpawnFading == 2)
        {
            // add the scene FadeAnimation and call the Methode Fades
            AddChild(s);
            s.Fades();
            
        }

        // switches scene
        BedScene.Hide();
        Show();
        //push the scene we're entering to the previous scenes stack
        GlobalData.PreviousScenes.Pop();
 
    }
    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
        // Dialog Dealer checks if the dialog should spawn again and the dealer control is so that the code isnt spammened in the process
        if (GlobalData.Dialog_Dealer == true && GlobalData.Dialog_Dealer_Control == true)
        {
            // Gridcontainer gets shown, the dialog gets instanciated and added as a child to the GridContainer
            var GridContainer = GetNode<GridContainer>("Spawn_DialogControl");
            // GridContainer shows, so the player cant interact with the other objects behind it
            GridContainer.Show();
            // Dialog gets instantiated and added so it spawns in the GridContainer
            var selftreatmentDialog = dealer_selftreatment_dialog.Instantiate<Dialog>();
            GridContainer.AddChild(selftreatmentDialog);
            // Dealer Control checks if the dialog should spawn again
            GlobalData.Dialog_Dealer_Control = false;
            // The medicine need to decrease for the player
            GlobalData.MedicinePlayer--;
        }

        if (GlobalData.Dialog_Dealer == false)
        {
            // The GridContainer needs to be hidden again, so the player can interact with the objects behind it
            var GridContainer = GetNode<GridContainer>("Spawn_DialogControl");
            GridContainer.Hide();
        }



    }

    }
