using Godot;
using System;
using System.ComponentModel.Design;

public partial class Diagnosis_Box : Label
{
    // Called when the node enters the scene tree for the first time.
    bool a;
    bool b;
    bool c;
    bool d;
    bool e;
    bool f;
    bool g;
    bool h;
    public override void _Ready()
	{
		a = false;
        b = false;
        c = false;
        d = false;
        e = false;
        f = false;
        g = false;
        h = false;
	}
    private void _on_checkbox_1_pressed()
    {
        a = true;
    }
    private void _on_checkbox_2_pressed()
    {
        b = true;
    }
    private void _on_checkbox_3_pressed()
    {
        c = true;
    }
    private void _on_checkbox_4_pressed()
    {
        d = true;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
        if (a == true && b == false && c == false && d == false) {
            Text = "It could be this, \n mhm but it also could be some other things \n what other symptoms are there?";

        } else if (b == true && a == true && c == false && d == false) 
          {
            Text = "this narrows it down to x and y \n is that all?";
          }else if (c == true && b == true && a == true && d == false)
           {
             Text = "this narrows it down to y \n is that all?";
        }
        else
        {
            Text = "What do these Symptoms tell us??";
        }

    }
}
