using Godot;
using System;
using System.Collections.Generic;

public partial class Hallway : Node2D
{
	Control HallwayControl;
	Control DoorControl;
    List<Button> Doors =  new List<Button>();
    Main MainNode;

    public override void _Ready()
    {
        MainNode = (Main)GetParent();
        //CloseFundsPopup.Pressed += () => CloseParent(CloseFundsPopup);
       // HallwayInitialize();
    }
    public void HallwayInitialize()
	{
        HallwayControl = GetNode<Control>("HallwayControl");
        DoorControl = HallwayControl.GetNode<Control>("DoorControl");

        //Doors
        int doorIndex = 0;
        foreach (Node child in DoorControl.GetChildren())
        {
            if (child.GetClass() == "Button")
            {
                Button childButton = child as Button;
                Doors.Add(childButton);
                Door doorButton = childButton as Door;
                doorButton.doorId = doorIndex;
                doorIndex++;
                childButton.Pressed += () => GoToRoom(doorButton.doorId);
            }
        }
    }

    private void GoToRoom(int index)
    {
        Hide();

        //var RoomScene = (Node2D)GetParent().GetNode("Room");
        //GD.Print($"Room count: {RoomList.Count}.");
        var RoomScene = MainNode.RoomList[index];
        RoomScene.Show();

        //push the scene we're entering to the previous scenes stack
        GlobalData.PreviousScenes.Push(RoomScene.GetPath());
    }
}
