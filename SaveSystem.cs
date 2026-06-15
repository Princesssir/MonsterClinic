using Godot;
using Godot.Collections;
using System;
using System.Globalization;

public static class SaveSystem
{
    public static void SaveToFile_Settings()
    {
       
       Dictionary<string, string> Save_Settings = new Dictionary<string, string>();
       Save_Settings.Add("SXF", SettingsControls.SXF_Volume.ToString());
       Save_Settings.Add("Ambient", SettingsControls.Ambient_Volume.ToString());
       Save_Settings.Add("Music", SettingsControls.Music_Volume.ToString());
       Save_Settings.Add("Fullscreen", SettingsControls.FullscreenToggle_on.ToString());

        string saveJson = Json.Stringify(Save_Settings);
        GD.Print("Saved");

        using var file_system = FileAccess.Open("user://Settings.Json", FileAccess.ModeFlags.Write);
        file_system.StoreString(saveJson);
        file_system.Close();

    }

    public static void LoadFile_Settings()
    {
        if (!FileAccess.FileExists("user://Settings.Json"))
        {
            return;
        }

        using var file_system = FileAccess.Open("user://Settings.Json", FileAccess.ModeFlags.Read);
        string Content_System = file_system.GetAsText();
        var data = Json.ParseString(Content_System).AsGodotDictionary();
        SettingsControls.Music_Volume = float.Parse((string)data["Music"]);
        SettingsControls.SXF_Volume = float.Parse((string)data["SXF"]);
        SettingsControls.Ambient_Volume = float.Parse((string)data["Ambient"]);
        SettingsControls.FullscreenToggle_on = bool.Parse((string)data["Fullscreen"]);

        if (SettingsControls.FullscreenToggle_on == true)
        {
            DisplayServer.WindowSetMode(DisplayServer.WindowMode.Fullscreen);

            SaveSystem.SaveToFile_Settings();
        }
        else
        {
            DisplayServer.WindowSetMode(DisplayServer.WindowMode.Windowed);

            SaveSystem.SaveToFile_Settings();
        }

        AudioServer.SetBusVolumeDb(AudioServer.GetBusIndex("Master"), SettingsControls.Music_Volume);
        AudioServer.SetBusVolumeDb(AudioServer.GetBusIndex("SXF"), SettingsControls.SXF_Volume);
        AudioServer.SetBusVolumeDb(AudioServer.GetBusIndex("Ambient"), SettingsControls.Ambient_Volume);


        GD.Print(Content_System);
    }

}
