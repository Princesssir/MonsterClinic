using Godot;
using System;

public partial class RoomStructureRenderer
{

    private int x = 0;
    public void GenerateRooms(GridContainer container, int amount)
	{
        GD.Print("GenerateMapButtons");
        
        for (int i = 0; i < amount; i++)
        {
            Button newButton = new Button();
            newButton.Modulate = new Color(1, 0, 0, 1);
            newButton.CustomMinimumSize = new Vector2(150, 150);
            //newButton.SizeFlagsHorizontal = Control.SizeFlags.ExpandFill;
            //newButton.SizeFlagsVertical = Control.SizeFlags.ExpandFill;
            newButton.Text = $"Room {Upgrades.roomCount}";
            //newButton.Position = new Vector2(x + 200, 800);
            //control.AddChild(newButton);
            container.AddChild(newButton);
        }
    }

    public void GenerateRoom(GridContainer container)
    {
        Button newButton = new Button();
        newButton.Modulate = new Color(1, 0, 0, 1);
        newButton.CustomMinimumSize = new Vector2(150, 150);
        newButton.Text = $"Room {Upgrades.roomCount}";
        container.AddChild(newButton);
    }
}
