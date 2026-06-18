using Godot;
using System;
using System.Collections.Generic;

public partial class Hallway : Node2D
{
	Control HallwayControl;
	Control DoorControl;
    List<Button> Doors =  new List<Button>();

    public override void _Ready()
    {
		HallwayInitialize();
    }
    public void HallwayInitialize()
	{
        HallwayControl = GetNode<Control>("HallwayControl");
        DoorControl = HallwayControl.GetNode<Control>("DoorControl");

        //Doors

        foreach (Node child in DoorControl.GetChildren())
        {
            if (child.GetClass() == "Button")
            {
                Button childButton = child as Button;
                Doors.Add(childButton);
                childButton.Pressed += GoToRoom;
            }
        }
    }

    private void GoToRoom()
    {
        Hide();

        var RoomScene = (Node2D)GetParent().GetNode("Room");
        RoomScene.Show();

        //push the scene we're entering to the previous scenes stack
        GlobalData.PreviousScenes.Push(RoomScene.GetPath());
    }
}
