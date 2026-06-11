using Godot;
using System;

public partial class SpeechManager : Node
{
	[Export] Label SpeechBubble;

    public override void _Ready()
    {
        SpeechBubble.Hide();
    }

    public void SpeechText(string text)
	{
        SpeechBubble.Show();
        SpeechBubble.Text = text;
    }
}
