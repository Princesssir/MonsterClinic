using Godot;
using System;
using System.Xml.Linq;

public partial class ControlSettingsContainer : Control
{
    Boolean toggle_on = SettingsControls.FullscreenToggle_on;
    float music_volume = SettingsControls.Music_Volume;
    float sxf_volume = SettingsControls.SXF_Volume;
    float ambient_volume = SettingsControls.Ambient_Volume;
    public override void _Ready()
	{
        //load
        SaveSystem.LoadFile_Settings();

        var slider = GetNode<CheckButton>("TabContainer/Grafic/VBoxContainer3/WindowSize_Slider");
        if (SettingsControls.FullscreenToggle_on == true)
        {
            slider.ButtonPressed = true;
        }
        else
        {
            slider.ButtonPressed = false;

        }
       
    }

 


    private void _on_window_size_slider_toggled(Boolean toggle_on)
	{
		if (toggle_on == true)
		{
            DisplayServer.WindowSetMode(DisplayServer.WindowMode.Fullscreen);
            SettingsControls.FullscreenToggle_on = toggle_on;
        
        }
		else
		{
            DisplayServer.WindowSetMode(DisplayServer.WindowMode.Windowed);
            SettingsControls.FullscreenToggle_on = toggle_on;
            
        }
        
    }

  

    private void _on_music_slider_value_changed(float music_volume)
    {
        AudioServer.SetBusVolumeDb(AudioServer.GetBusIndex("Master"), music_volume);
        SettingsControls.Music_Volume = music_volume;
    }


    private void _on_sxf_slider_value_changed(float sxf_volume)
    {
        AudioServer.SetBusVolumeDb(AudioServer.GetBusIndex("SXF"), sxf_volume);
        SettingsControls.SXF_Volume = sxf_volume;
    }


    private void _on_ambient_slide_value_changed(float ambient_volume)
    {
        AudioServer.SetBusVolumeDb(AudioServer.GetBusIndex("Ambient"), ambient_volume);
        SettingsControls.Ambient_Volume = ambient_volume;
    }


}
