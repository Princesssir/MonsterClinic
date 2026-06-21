using Godot;
using System;


public partial class FadeAnimation : Node2D
{
	private Tween tw_fade;
	public override void _Ready()
	{
        
       
    }

	public void Fades()
	{
        // creates a Tween
        tw_fade = GetTree().CreateTween();

        // get Timer
        var d = GetNode<Timer>("Delete_Timer");

        // condition for the animation
        if (GlobalData.Fading == false)
        {
            // get the ColorRect and set the new Color invisible
            var Colorrect_visibility = GetNode<ColorRect>("Fade");
            Colorrect_visibility.Color = new Color(Colorrect_visibility.Color.R, Colorrect_visibility.Color.G, Colorrect_visibility.Color.B, 0);

            // Tween affects the color rect, 1f -> from invisible to visible, 1f -> animation speed
            tw_fade.TweenProperty(Colorrect_visibility, "color:a", 1f, 1f);

            // smooth animation for the Tween
            tw_fade.SetTrans(Tween.TransitionType.Sine);
            tw_fade.SetEase(Tween.EaseType.Out);

            // Condition changes 
            GlobalData.Fading = true;

            // Timer get set to 3 sec, so long is the bed scene. Timer starts
            d.SetWaitTime(3.0);
            d.Start();
        }
        else
        {
            // get the ColorRect and set the new Color invisible
            var Colorrect_visibility = GetNode<ColorRect>("Fade");
            Colorrect_visibility.Color = new Color(Colorrect_visibility.Color.R, Colorrect_visibility.Color.G, Colorrect_visibility.Color.B, 1);

            // Tween affects the color rect, 1f -> from invisible to visible, 1f -> animation speed
            tw_fade.TweenProperty(Colorrect_visibility, "color:a", 0f, 1f);

            // smooth animation for the Tween
            tw_fade.SetTrans(Tween.TransitionType.Sine);
            tw_fade.SetEase(Tween.EaseType.Out);

            // Timer get set to 1 sec, so the player dont get locked into a 3 sec wait to click again
            d.SetWaitTime(1.0);
            d.Start();
        }
        

    }

    public void _on_delete_timer_timeout()
    {
        // delets itself
        QueueFree();
    }

    
}
