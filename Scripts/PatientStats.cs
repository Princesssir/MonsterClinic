using Godot;
using System;

public class PatientStats
{
    public string PatientID { get; set; }
    public int Age { get; set; }
    public Color Tint { get; set; }

    public PatientStats()
    {
        var random = new Random();
        
        // Generate a random ID (001-999)
        int idNumber = random.Next(1, 1000);
        PatientID = idNumber.ToString("D3");
        
        Age = random.Next(18, 90);
        
        // Random tint for the profile picture
        Tint = new Color(
            (float)random.NextDouble(), 
            (float)random.NextDouble(), 
            (float)random.NextDouble()
        );
    }
}