using Godot;
using System;

public partial class PauseMenu : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//hide the scene itself on startup
		Hide();
        var settings = (HBoxContainer)GetNode("Player_Interactables_Menu").GetNode("Settings_Box");
		//furthermore, hide the settings section
		settings.Hide();
	}

	public override void _UnhandledInput(InputEvent @event)
	{
		//grabbing the reference to the vbox containing the 3 main menu buttons
        var menu = (VBoxContainer)GetNode("Player_Interactables_Menu").GetNode("Menu_Box");
		//grabbing the reference to the hbox containing the specific settings
        var settings = (HBoxContainer)GetNode("Player_Interactables_Menu").GetNode("Settings_Box");
		//whole process for using the esc key for input
		if (@event is InputEventKey eventKey)
		{
			//if a key is pressed and that key is esc
			if (eventKey.Pressed && eventKey.Keycode == Key.Escape)
			{
				//if the settings are visible, "exits" them and goes back to the main section of the pause menu
				if (settings.Visible == true)
				{
					settings.Hide();
					menu.Show();
				}
				//else, exits the pause menu
				else
				{
					Visible = !Visible;
				}
			}
		}
	}

	//when resume pressed, hide the pause menu
	private void _on_resume_pressed()
	{
		Hide();
	}

	//when settings pressed, hide the main section of the pause menu, and show the settings
	private void _on_settings_pressed()
	{
        var menu = (VBoxContainer)GetNode("Player_Interactables_Menu").GetNode("Menu_Box");
        var settings = (HBoxContainer)GetNode("Player_Interactables_Menu").GetNode("Settings_Box");
		menu.Hide();
		settings.Show();
    }

	//when exit pressed, quit the game
	private void _on_exit_pressed()
	{
		GetTree().Quit();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
